using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSQLiteApi.Utils
{
    public static class SQLiteQuery
    {
        /// <summary>
        /// Executa uma query (insert/update/delete) na base de dados
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <param name="connection"></param>
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
        /// Inserir/atualizar byte array em base de dados
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="byteArrayColumn"></param>
        /// <param name="byteArray"></param>
        /// <param name="connection"></param>
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

        public static SQLiteDataReader ExecuteReader(string sqlQuery, SQLiteConnection connection)
        {
            using (var command = new SQLiteCommand(sqlQuery, connection))
            {
                SFLog.ConsoleWriteLine(sqlQuery);

                return command.ExecuteReader();
            }            
        }

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
