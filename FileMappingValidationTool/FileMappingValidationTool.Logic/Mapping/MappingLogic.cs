using FileMappingValidationTool.DataAccess.Reader;
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
            StringBuilder str = new StringBuilder();
            int rowCount;
            
            //read the sheet/table names and columns names from config and use that to validate duplicates
            rowCount = _sourceDS.Tables["RM"].Rows.Count;
            if (Convert.ToInt16(_sourceDS.Tables["RM"].Rows[rowCount - 1][0]) != rowCount)
                str.AppendFormat("{0} : {1} : {2}", "RM", "RM ID", "ID count dont match, please check IDs");

            return str.ToString();
        }
    }
}
