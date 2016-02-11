using FileMappingValidationTool.Logic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FileMappingValidationTool.Logic.Extensions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

namespace FileMappingValidationTool.Logic.Validation
{
    public class ValidationHelper
    {
        public BusinessValidations ValidationRules { get; set; }

        public ValidationHelper()
        {
            ValidationRules = new BusinessValidations();
        }

        public void FetchValidationRules()
        {
            XmlSerializer reader = new XmlSerializer(typeof(BusinessValidations));
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"BusinessRules\ValidationList.xml");
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            ValidationRules = (BusinessValidations)reader.Deserialize(file);
            file.Close();
        }

        public string ValidateRules(DataTable dataTable)
        {
            return WorksheetValidation(dataTable).ToString();
        }

        private string WorksheetValidation(DataTable sourceTable)
        {
            StringBuilder str = new StringBuilder();

            var rmRules = ValidationRules.Worksheets.Where(a => a.Name == sourceTable.TableName).FirstOrDefault();

            if (rmRules == null)
            { return string.Empty; }

            foreach (var validation in rmRules.Validations)
            {
                switch (validation.Type)
                {
                    case ValidationTypeEnum.ZeroCheck:
                        str.Append(sourceTable.ZeroValueCheck(validation.Field));
                        break;
                    case ValidationTypeEnum.PossibleValueCheck:
                        str.Append(sourceTable.ValueCheck(validation.Field, validation.Values));
                        break;
                    default:
                        break;
                }
            }
            
            return str.ToString();
        }
    }
}
