using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMappingValidationTool.DataAccess.Reader
{
    public class ExcelReader
    {

        public DataSet ReadDataSet(String filePath)
        {
            DataSet result = new DataSet();
            try
            {
                FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

                //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                try
                {
                    //4. DataSet - Create column names from first row
                    excelReader.IsFirstRowAsColumnNames = true;
                    result = excelReader.AsDataSet();

                    ////5. Data Reader methods
                    //while (excelReader.Read())
                    //{
                    //    //excelReader.GetInt32(0);
                    //}

                    //6. Free resources (IExcelDataReader is IDisposable)
                }
                finally
                {
                    excelReader.Close();
                }

            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

    }
}
