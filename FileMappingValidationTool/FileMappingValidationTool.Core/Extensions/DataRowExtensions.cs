using FileMappingValidationTool.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMappingValidationTool.Core.Extensions
{
    public static class DataRowExtensions
    {
        public static bool ParseField(this DataRow row, string columnName, DataTypeEnum dataType)
        {
            bool isValidValue = false;
            switch (dataType)
            {
                case DataTypeEnum.Date:
                    isValidValue = !row.Field<DateTime?>(columnName).HasValue;
                    break;
                case DataTypeEnum.Int:
                    break;
                case DataTypeEnum.Double:
                    break;
                default:
                    break;
            }

            return isValidValue;
        }
    }
}
