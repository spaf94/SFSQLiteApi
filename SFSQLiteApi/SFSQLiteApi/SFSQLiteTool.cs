using SFSQLiteApi.Utils;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SFSQLiteApi
{
    public static class SFSQLiteTool
    {
        /// <summary>
        /// Gets the key value list.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static List<object> GetKeyValueList(object obj)
        {
            List<object> keyValueList = new List<object>();
            Type objectType = obj.GetType();
            var propertyList = objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo property in propertyList)
            {
                if (property.IsKey())
                {
                    object value = property.GetValue(obj, null);
                    keyValueList.Add(value);
                }
            }

            return keyValueList;
        }

        /// <summary>
        /// Gets the key value string.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static string GetKeyValueString(object obj)
        {
            StringBuilder sbKeyValues = new StringBuilder();
            Type objectType = obj.GetType();
            var propertyList = objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo property in propertyList)
            {
                if (property.IsKey())
                {
                    object value = property.GetValue(obj, null);
                    sbKeyValues.Append(value.ToString());
                    sbKeyValues.Append(", ");
                }
            }

            sbKeyValues.Remove((sbKeyValues.Length - 2), 2);

            return sbKeyValues.ToString();
        }

        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static string GetTableName(object obj)
        {
            if (obj != null)
            {
                return (obj.GetType().Name);
            }

            return (string.Empty);
        }
    }
}