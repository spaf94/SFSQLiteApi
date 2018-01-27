using SFSQLiteApi.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SFSQLiteApi
{
    public static class SFSQLiteTool
    {
        #region Public Methods

        /// <summary>
        /// Gets the key value list.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static List<object> GetKeyValueList(object obj)
        {
            List<object> keyValueList = new List<object>();
            var propertyList = GetPropertyKeyList(obj);

            foreach (PropertyInfo property in propertyList)
            {
                object value = property.GetValue(obj, null);
                keyValueList.Add(value);
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
            var propertyList = GetPropertyKeyList(obj);

            foreach (PropertyInfo property in propertyList)
            {
                object value = property.GetValue(obj, null);
                sbKeyValues.Append(value.ToString());
                sbKeyValues.Append(", ");
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

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Gets the property key list.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns></returns>
        private static List<PropertyInfo> GetPropertyKeyList(object obj)
        {
            var propertyList = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
            return (propertyList.Where(x => x.IsKey()).ToList());
        }

        #endregion Private Methods
    }
}