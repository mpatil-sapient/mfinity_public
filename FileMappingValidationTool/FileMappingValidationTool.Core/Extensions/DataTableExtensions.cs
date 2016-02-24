using FileMappingValidationTool.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FileMappingValidationTool.Core.Extensions
{
    public static class DataTableExtensions
    {
        public static List<LogData> ZeroValueCheck(this DataTable dataTable, string columnName)
        {
            var logs = new List<LogData>();
            var diceWithZeros = dataTable.Rows.Cast<DataRow>().Where(a => (a.Field<double?>(columnName).HasValue && a.Field<double?>(columnName).Value == 0));
            if (diceWithZeros != null)
            {
                foreach (var row in diceWithZeros)
                {
                    logs.Add(new LogData
                    {
                        WorkSheet = dataTable.TableName,
                        ColumnName = columnName,
                        RowNumber = dataTable.Rows.IndexOf(row) + 2,
                        LogMessage = columnName + " value cannot be 0"
                    });
                    //str.AppendFormat("{0} : {1} : Row {2} : {3}{4}", dataTable.TableName, columnName, dataTable.Rows.IndexOf(row) + 2,
                    //            columnName, " value cannot be 0\n");
                }
            }
            return logs;
        }

        public static List<LogData> NullValueCheck(this DataTable dataTable, string columnName)
        {
            var logs = new List<LogData>();
            var invalidRows = dataTable.Rows.Cast<DataRow>().Where(a => a.Field<object>(columnName) == null);
            foreach (var row in invalidRows)
            {
                logs.Add(new LogData
                {
                    WorkSheet = dataTable.TableName,
                    ColumnName = columnName,
                    RowNumber = dataTable.Rows.IndexOf(row) + 2,
                    LogMessage = columnName + " value cannot be null"
                });
                //("{0} : {1} : Row {2} : {3}{4}", dataTable.TableName, columnName, dataTable.Rows.IndexOf(row) + 2,
                //            columnName, " value cannot be null\n");
            }

            return logs;
        }

        public static List<LogData> DataTypeCheck(this DataTable dataTable, string columnName
            , DataTypeEnum dataType, string DataTypeField, DataTable referenceTable, string referenceDataTypeField, string referenceCompareField)
        {
            var logs = new List<LogData>();
            var typeSpecificData = referenceTable.Rows.Cast<DataRow>().Where(a => a.Field<string>(referenceCompareField) == dataType.ToString())
                .Select(b => b.Field<string>(referenceDataTypeField));

            var invalidRows = dataTable.Rows.Cast<DataRow>().Where(a => typeSpecificData.Contains(a.Field<string>(DataTypeField), StringComparer.CurrentCultureIgnoreCase)
                && a.ParseField(columnName, dataType));
            foreach (var row in invalidRows)
            {
                logs.Add(new LogData
                {
                    WorkSheet = dataTable.TableName,
                    ColumnName = columnName,
                    RowNumber = dataTable.Rows.IndexOf(row) + 2,
                    LogMessage = columnName + " value is not correct format"
                });
                //str.AppendFormat("{0} : {1} : Row {2} : {3}{4}", dataTable.TableName, columnName, dataTable.Rows.IndexOf(row) + 2,
                //            columnName, " value is not correct format.\n");
            }

            return logs;
        }

        public static List<LogData> ValueCheck(this DataTable dataTable, string columnName, List<string> values)
        {
            var logs = new List<LogData>();
            var invalidrows = dataTable.Rows.Cast<DataRow>().Where(a => !values.Contains(a.Field<string>(columnName), StringComparer.CurrentCultureIgnoreCase));
            if (invalidrows != null)
            {
                foreach (var row in invalidrows)
                {
                    logs.Add(new LogData
                    {
                        WorkSheet = dataTable.TableName,
                        ColumnName = columnName,
                        RowNumber = dataTable.Rows.IndexOf(row) + 2,
                        LogMessage = row.Field<string>(columnName) + " is incorrect.Possible values are " + string.Join(",", values)
                    });
                    //str.AppendFormat("{0} : {1} : Row {2} : {3}", dataTable.TableName, columnName, dataTable.Rows.IndexOf(row) + 2,
                    //            row.Field<string>(columnName) + " is incorrect.Possible values are " + string.Join(",", values) + " \n");
                }
            }

            return logs;
        }

        public static List<LogData> ConditionalCheck(this DataTable dataTable, string conditonField, List<string> conditionFieldValues, List<KeyValue> KeyValues)
        {
            var logs = new List<LogData>();
            var conditionalRows = dataTable.Rows.Cast<DataRow>().Where(a => conditionFieldValues.Contains(a.Field<string>(conditonField), StringComparer.CurrentCultureIgnoreCase));
            if (conditionalRows != null)
            {
                foreach (var row in conditionalRows)
                {
                    var invalidColumns = KeyValues.Where(a => (Convert.ToString(row.Field<object>(a.Name)) ?? string.Empty) != a.Value);
                    foreach (var column in invalidColumns)
                    {
                        logs.Add(new LogData
                        {
                            WorkSheet = dataTable.TableName,
                            ColumnName = column.Name,
                            RowNumber = dataTable.Rows.IndexOf(row) + 2,
                            LogMessage = Convert.ToString(row.Field<object>(column.Name)) + " value is incorrect."
                        });
                        //str.AppendFormat("{0} : {1} : Row {2} : {3}", dataTable.TableName, column.Name, dataTable.Rows.IndexOf(row) + 2,
                        //            Convert.ToString(row.Field<object>(column.Name)) + " is incorrect.\n");
                    }
                }
            }
            return logs;
        }

        public static List<LogData> GroupCheck(this DataTable dataTable, string basefield, List<string> ignoreFields)
        {
            var logs = new List<LogData>();
            ignoreFields.ForEach(a => dataTable.Columns.Remove(a));

            //var selectedColumnsDataTable = dataTable.Columns.con;

            //var groupedData = selectedColumnsDataTable.Rows.Cast<DataRow>().GroupBy(a=>a.Field<string>(basefield)).Co;
            //var groupedData = from row in selectedColumnsDataTable.AsEnumerable()
            //                  group row by row.Field<double>(basefield) into groups
            //                  orderby groups.Key
            //                  select new
            //                  {
            //                      Name = groups.Key,
            //                      CountOfClients = groups.Count()
            //                  };

            //foreach (var data in groupedData)
            //{
            //    if (data.CountOfClients > 1)
            //    {
            //        logs.Add(new LogData
            //        {
            //            WorkSheet = dataTable.TableName,
            //            ColumnName = basefield,
            //            RowNumber = 0,
            //            LogMessage = "Common data is not matching for " + data.Name + " " + basefield
            //        });
            //    }
            //    //str.AppendFormat("{0} : {1} : Row {2} : {3}", dataTable.TableName, column.Name, dataTable.Rows.IndexOf(row) + 2,
            //    //                Convert.ToString(row.Field<object>(column.Name)) + " is incorrect.\n");
            //}

            return logs;
        }

        public static List<LogData> ReferenceCheck(this DataTable dataTable, string field, DataTable referenceTable, string referenceField)
        {
            var logs = new List<LogData>();
            if (referenceTable != null)
            {
                var ValuesNotInRefs = dataTable.AsEnumerable().Select(a => Convert.ToString(a.Field<object>(field)))
                    .Except(referenceTable.AsEnumerable().Select(a => Convert.ToString(a.Field<object>(referenceField))));

                if (ValuesNotInRefs.Count() > 0)
                {
                    var inValidRows = (from row in dataTable.AsEnumerable()
                                       join id in ValuesNotInRefs
                                             on Convert.ToString(row.Field<object>(field)) equals id
                                       select row).CopyToDataTable();

                    foreach (var row in inValidRows.Rows.Cast<DataRow>())
                    {
                        logs.Add(new LogData
                        {
                            WorkSheet = dataTable.TableName,
                            ColumnName = field,
                            RowNumber = dataTable.Rows.IndexOf(row) + 2,
                            LogMessage = Convert.ToString(row.Field<object>(field)) + " is not available in reference sheet."
                        });
                        //str.AppendFormat("{0} : {1} : Row {2} : {3}", dataTable.TableName, field, dataTable.Rows.IndexOf(row) + 2,
                        //            Convert.ToString(row.Field<object>(field)) + " is not available in reference sheet.\n");
                    }
                }
            }
            return logs;
        }

        public static List<LogData> CountMatchCheck(this DataTable dataTable)
        {
            var logs = new List<LogData>();
            var rowCount = dataTable.Rows.Count;

            //validate only if this isnt a reference sheet
            if (!dataTable.TableName.StartsWith("ref", StringComparison.CurrentCultureIgnoreCase))
            {
                //assumes that the first column in each sheet is the unique identifier, needs to be validated for all tabs
                if (dataTable.Columns[0].DataType == typeof(System.Double) && Convert.ToInt64(dataTable.Rows[rowCount - 1][0]) != rowCount)
                {
                    logs.Add(new LogData
                    {
                        WorkSheet = dataTable.TableName,
                        ColumnName = dataTable.Columns[0].ColumnName,
                        RowNumber = 0,
                        LogMessage = "ID count dont match, please check IDs"
                    });
                }
                //str.AppendFormat("{0} : {1} : {2}", dataTable.TableName, dataTable.Columns[0].ColumnName,
                //    "ID count dont match, please check IDs\n");
            }
            return logs;
        }
    }
}
