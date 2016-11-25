using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace KasperskyTest.FrameWork.Utils
{
    public class ExcelReader
    {
        private static OleDbConnection _oleDbConnection;
        private static DataTable _schemaTable;
        private static OleDbDataAdapter _oleDbDataAdapter;
        private static DataSet _dataSet;

        public static void LoadFile(string filename)
        {
            string connection = $"Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=\"Excel 8.0;HDR=NO\"; Data Source={filename}";
            _oleDbConnection = new OleDbConnection(connection);
            _oleDbConnection.Open();
            _schemaTable = _oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string sheet = (string)_schemaTable?.Rows[0].ItemArray[2];
            string select = $"SELECT * FROM [{sheet}]";
            _oleDbDataAdapter = new OleDbDataAdapter(select, _oleDbConnection);
            _dataSet = new DataSet("EXCEL");
            _oleDbDataAdapter.Fill(_dataSet);
            _oleDbConnection.Close();
        }

        /// <summary>
        /// return match from first row of column
        /// </summary>
        /// <param name="column">column name</param>
        /// <returns>first match</returns>
        public static string GetValue(string column)
        {
            string value = "";
            //Rows[0] - first row with columns names
            var columnNameArray = _dataSet.Tables[0].Rows[0].ItemArray;
            for (int columnIndex = 0; columnIndex < columnNameArray.Length; columnIndex++)
            {
                if (columnNameArray[columnIndex].ToString().Equals(column))
                {
                    //1 - match from 1 row
                    var itemArray = _dataSet.Tables[0].Rows[1].ItemArray;
                    value = itemArray[columnIndex].ToString();
                }
            }
            return value;
        }

        /// <summary>
        /// return all matches from column
        /// </summary>
        /// <param name="column">column name</param>
        /// <returns>matches</returns>
        public static List<string> GetValues(string column)
        {
            List<string> values = new List<string>();
            //Rows[0] - first row with columns names
            var columnNameArray = _dataSet.Tables[0].Rows[0].ItemArray;
            for (int columnIndex = 0; columnIndex < columnNameArray.Length; columnIndex++)
            {
                if (columnNameArray[columnIndex].ToString().Equals(column))
                {
                    //rowIndex = 1, because we don't need first row with columns names
                    for (int rowIndex = 1; rowIndex < _dataSet.Tables[0].Rows.Count; rowIndex++)
                    {
                        var itemArray = _dataSet.Tables[0].Rows[rowIndex].ItemArray;
                        if (!values.Contains(itemArray[columnIndex].ToString()))
                        {
                            values.Add(itemArray[columnIndex].ToString());
                        }
                    }
                }
            }
            return values;
        }

        /// <summary>
        /// return matches from column where (column, value) 
        /// </summary>
        /// <param name="column">column name</param>
        /// <param name="whereColumn">column name where</param>
        /// <param name="whereValue">value where</param>
        /// <returns>matches</returns>
        public static List<string> GetValuesWhere(string column, string whereColumn, string whereValue)
        {
            List<string> values = new List<string>();
            //Rows[0] - first row with columns names
            var columnNameArray = _dataSet.Tables[0].Rows[0].ItemArray;
            for (int whereColumnIndex = 0; whereColumnIndex < columnNameArray.Length; whereColumnIndex++)
            {
                if (columnNameArray[whereColumnIndex].ToString().Equals(whereColumn))
                {
                    //rowIndex = 1, because we don't need first row with columns names
                    for (int rowIndex = 1; rowIndex < _dataSet.Tables[0].Rows.Count; rowIndex++)
                    {
                        var valueArray = _dataSet.Tables[0].Rows[rowIndex].ItemArray;
                        if (valueArray[whereColumnIndex].ToString().Normalize().Equals(whereValue.Normalize()))
                        {
                            for (int columnIndex = 0; columnIndex < columnNameArray.Length; columnIndex++)
                            {
                                if (columnNameArray[columnIndex].ToString().Equals(column))
                                {
                                    values.Add(valueArray[columnIndex].ToString());
                                }
                            }
                        }
                    }
                }
            }
            return values;
        }
    }
}
