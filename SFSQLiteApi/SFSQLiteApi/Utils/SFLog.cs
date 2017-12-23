using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SFSQLiteApi.Utils
{
    internal static class SFLog
    {
        /// <summary>
        /// Escreve mensagem de log para a consola
        /// </summary>
        /// <param name="message"></param>
        public static void ConsoleWriteLine(string message)
        {
            Console.WriteLine(string.Format(StringFormat.LogMessage, message));
        }

        /// <summary>
        /// Writes the error.
        /// </summary>
        public static void WriteError(object objClass, string method, string error)
        {
            string msg = string.Format("{0} | {1} | {2} | {3}", DateTime.Now, objClass, method, error);
            WriteToConsole(msg);
        }

        /// <summary>
        /// Writes to file.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        private static void WriteToFile(string msg)
        {
            File.WriteAllText(null, msg);
        }

        private static void WriteToConsole(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
