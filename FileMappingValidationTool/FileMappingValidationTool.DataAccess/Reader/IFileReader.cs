using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMappingValidationTool.DataAccess.Reader
{
    public interface IFileReader
    {
        DataSet ReadDataSet(String filePath);
    }
}
