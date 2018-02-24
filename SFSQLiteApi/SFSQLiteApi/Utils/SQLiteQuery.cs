using SFSQLiteApi.Utils.Log;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace SFSQLiteApi.Utils
{
    public static class SQLiteQuery
    {
        /// <summary>
        /// Counts the total.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        public static string CountTotal(string tableName, string whereClause = "")
        {
            if (string.IsNullOrWhiteSpace(whereClause))
            {
                return (string.Format("SELECT COUNT(*) AS '{0}' FROM {1}", Constant.TotalCount, tableName));
            }
            else
            {
                return (string.Format("SELECT COUNT(*) AS '{0}' FROM {1} WHERE {2}",
                                      Constant.TotalCount,
                                      tableName,
                                      whereClause));
            }
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <param name="connection">The connection.</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sqlQuery, SQLiteConnection connection)
        {
            using (var command = new SQLiteCommand(sqlQuery, connection))
            {
                APILog.Debug(typeof(SQLiteQuery), "ExecuteNonQuery", sqlQuery);

                return command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <param name="connection">The connection.</param>
        /// <returns></returns>
        public static SQLiteDataReader ExecuteReader(string sqlQuery, SQLiteConnection connection)
        {
            using (var command = new SQLiteCommand(sqlQuery, connection))
            {
                APILog.Debug(typeof(SQLiteQuery), "ExecuteReader", sqlQuery);

                return command.ExecuteReader();
            }
        }

        /// <summary>
        /// Inserts the update byte array.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="byteArrayColumn">The byte array column.</param>
        /// <param name="byteArray">The byte array.</param>
        /// <param name="where">The where.</param>
        /// <param name="connection">The connection.</param>
        /// <returns></returns>
        public static int InsertUpdateByteArray(
            string tableName,
            string byteArrayColumn,
            byte[] byteArray,
            string where,
            SQLiteConnection connection)
        {
            if (byteArray != null)
            {
                StringBuilder byteArrayQuery = new StringBuilder();
                byteArrayQuery.Append("UPDATE ");
                byteArrayQuery.Append(tableName);
                byteArrayQuery.Append(" SET ");
                byteArrayQuery.Append(byteArrayColumn);
                byteArrayQuery.Append("=@img");
                byteArrayQuery.Append(" WHERE");
                byteArrayQuery.Append(where);

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = byteArrayQuery.ToString();
                    command.Prepare();
                    command.Parameters.Add("@img", DbType.Binary, byteArray.Length);
                    command.Parameters["@img"].Value = byteArray;

                    return command.ExecuteNonQuery();
                }
            }

            return 0;
        }

        /// <summary>
        /// Maximums from table.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        public static string MaxFromTable(string tableName, string columnName)
        {
            return (string.Format("SELECT MAX({0}) AS '{1}' FROM {2}", columnName, Constant.MaxValue, tableName));
        }

        /// <summary>
        /// Selects all from.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        public static string SelectAllFrom(string tableName, string whereClause = "")
        {
            if (string.IsNullOrWhiteSpace(whereClause))
            {
                return (string.Format("SELECT * FROM {0}", tableName));
            }
            else
            {
                return (string.Format("SELECT * FROM {0} WHERE {1}", tableName, whereClause));
            }
        }
    }
}