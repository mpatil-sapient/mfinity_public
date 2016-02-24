using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMappingValidationTool.Core.Models
{
    public class LogData
    {
        public string WorkSheet { get; set; }
        public string ColumnName { get; set; }
        public int RowNumber { get; set; }
        public string LogMessage { get; set; }
    }
}
