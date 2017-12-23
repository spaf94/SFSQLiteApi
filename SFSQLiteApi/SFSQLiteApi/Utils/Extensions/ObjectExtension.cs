using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSQLiteApi.Utils
{
    internal static class ObjectExtension
    {
        /// <summary>
        /// Retorna se um objeto tem conteúdo
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool HaveContent(this object value)
        {
            if (value == null)
            {
                return false;
            }

            return (!string.IsNullOrWhiteSpace(value.ToString()));
        }
    }
}
