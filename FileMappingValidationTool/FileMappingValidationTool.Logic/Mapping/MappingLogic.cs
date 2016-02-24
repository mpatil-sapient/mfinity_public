using FileMappingValidationTool.DataAccess.Reader;
using FileMappingValidationTool.Logic.Validation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMappingValidationTool.Logic.Mapping
{
    public class MappingLogic : IMappingLogic
    {
        DataSet _sourceDS, _destDS;

        IFileReader reader = new ExcelReader();

        public void Load(string sourceFile, string destinationFile)
        {
            _sourceDS = reader.ReadDataSet(sourceFile);
            _destDS = reader.ReadDataSet(destinationFile);
        }

        public void Map()
        {

        }

        public string ValidateSource()
        {
            return string.Empty;
            //StringBuilder str = new StringBuilder();
            //int rowCount;

            //var tabelCollection = _sourceDS.Tables.Cast<DataTable>();
            //        //.Where(a => !a.TableName.StartsWith("ref", StringComparison.CurrentCultureIgnoreCase));

            //var validationhelper = new ValidationHelper();
            //validationhelper.FetchValidationRules(tabelCollection.ToList());

            ////read the sheet/table names and columns names from config and use that to validate duplicates
            //foreach (DataTable sourceTable in tabelCollection)
            //{
            //    str.Append(validationhelper.ValidateRules(sourceTable));
            //    rowCount = sourceTable.Rows.Count;
                
            //    //validate only if this isnt a reference sheet
            //    if(!sourceTable.TableName.StartsWith("ref", StringComparison.CurrentCultureIgnoreCase))
            //    {
            //        //assumes that the first column in each sheet is the unique identifier, needs to be validated for all tabs
            //        if (sourceTable.Columns[0].DataType == typeof(System.Double) && Convert.ToInt64(sourceTable.Rows[rowCount - 1][0]) != rowCount)
            //            str.AppendFormat("{0} : {1} : {2}", sourceTable.TableName, sourceTable.Columns[0].ColumnName,
            //                "ID count dont match, please check IDs\n");
            //    }
            //}
            //return str.ToString();
        }
    }
}
