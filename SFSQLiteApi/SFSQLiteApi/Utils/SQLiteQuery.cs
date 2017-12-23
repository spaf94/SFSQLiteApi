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
                SFLog.ConsoleWriteLine(sqlQuery);

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
                SFLog.ConsoleWriteLine(sqlQuery);

                return command.ExecuteReader();
            }
        }

        /// <summary>
        /// Inserts the update byte array.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="byteArrayColumn">The byte array column.</param>
        /// <param name="byteArray">The byte array.</param>
        /// <param name="connection">The connection.</param>
        /// <returns></returns>
        public static int InsertUpdateByteArray(
            string tableName,
            string byteArrayColumn,
            byte[] byteArray,
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

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = byteArrayQuery.ToString();
                    command.Prepare();
                    command.Parameters.Add("@img", DbType.Binary, byteArray.Length);
                    command.Parameters["@img"].Value = byteArray;

                    SFLog.ConsoleWriteLine(command.CommandText);

                    return command.ExecuteNonQuery();
                }
            }

            return 0;
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