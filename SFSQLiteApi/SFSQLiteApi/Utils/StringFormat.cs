namespace SFSQLiteApi.Utils
{
    internal static class StringFormat
    {
        /// <summary>
        /// The connection string
        /// </summary>
        public static string ConnectionString = "Data Source={0}.sqlite;Version=3;";

        /// <summary>
        /// The log message
        /// </summary>
        public static string LogMessage = "[SFSQLiteApi] ==> {0} ";

        /// <summary>
        /// The SQL insert
        /// </summary>
        public static string SqlInsert = "INSERT INTO {0}({1}) VALUES({2})";
    }
}