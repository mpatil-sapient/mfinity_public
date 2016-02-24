using FileMappingValidationTool.Core.Extensions;
using FileMappingValidationTool.Core.Models;
using FileMappingValidationTool.DataAccess.Reader;
using FileMappingValidationTool.Logic.Models;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace FileMappingValidationTool.Logic.Validation
{
    public class ExcelValidationHelper : IValidationHelper
    {
        public BusinessValidations ValidationRules { get; set; }
        public List<DataTable> tableCollection { get; set; }

        IFileReader reader = new ExcelReader();

        public ExcelValidationHelper()
        {
            ValidationRules = new BusinessValidations();
            tableCollection = new List<DataTable>();
        }

        public void Load(string sourceFile, string validationTemplateFile)
        {
            var dataset = reader.ReadDataSet(sourceFile);
            tableCollection = dataset.Tables.Cast<DataTable>().ToList();
            LoadValidationRules(validationTemplateFile);
        }

        public List<LogData> ValidateRules()
        {
            var logData = new List<LogData>();
            foreach (DataTable sourceTable in tableCollection)
            {
                logData.AddRange(sourceTable.CountMatchCheck());
                logData.AddRange(WorksheetValidation(sourceTable));
            }

            return logData;
        }

        private void LoadValidationRules(string validationTemplateFile)
        {
            var reader = new XmlSerializer(typeof(BusinessValidations));
            using (StreamReader file = new StreamReader(validationTemplateFile))
            {
                ValidationRules = (BusinessValidations)reader.Deserialize(file);
            }
        }

        private List<LogData> WorksheetValidation(DataTable sourceTable)
        {
            var logData = new List<LogData>();
            var rmRules = ValidationRules.Worksheets.Where(a => a.Name == sourceTable.TableName).FirstOrDefault();

            if (rmRules == null)
            { return logData; }

            foreach (var validation in rmRules.Validations)
            {
                switch (validation.Type)
                {
                    case ValidationTypeEnum.NullCheck:
                        logData.AddRange(sourceTable.NullValueCheck(validation.Field));
                        break;
                    case ValidationTypeEnum.DataTypeCheck:
                        var dataTypeReferenceTable = tableCollection.Where(a => a.TableName == validation.ReferenceTable).FirstOrDefault();
                        logData.AddRange(sourceTable.DataTypeCheck(validation.Field, validation.DataType, validation.DataTypeField, dataTypeReferenceTable, validation.ReferenceDataTypeField, validation.ReferenceCompareField));
                        break;
                    case ValidationTypeEnum.ZeroCheck:
                        logData.AddRange(sourceTable.ZeroValueCheck(validation.Field));
                        break;
                    case ValidationTypeEnum.PossibleValueCheck:
                        logData.AddRange(sourceTable.ValueCheck(validation.Field, validation.Values));
                        break;
                    case ValidationTypeEnum.ConditionalCheck:
                        logData.AddRange(sourceTable.ConditionalCheck(validation.Field, validation.Values, validation.ConditionBasedKeyValues));
                        break;
                    case ValidationTypeEnum.ReferenceValueCheck:
                        var referenceTable = tableCollection.Where(a => a.TableName == validation.ReferenceTable).FirstOrDefault();
                        logData.AddRange(sourceTable.ReferenceCheck(validation.Field, referenceTable, validation.ReferenceField));
                        break;
                    case ValidationTypeEnum.GroupCheck:
                        logData.AddRange(sourceTable.GroupCheck(validation.Field, validation.IgnoreFields));
                        break;
                    default:
                        break;
                }
            }

            return logData;
        }
    }
}
