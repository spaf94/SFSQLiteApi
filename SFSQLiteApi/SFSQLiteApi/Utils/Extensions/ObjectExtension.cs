using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SFSQLiteApi.Utils
{
    internal static class ObjectExtension
    {
        /// <summary>
        /// Haves the content.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool HaveContent(this object value)
        {
            if (value == null)
            {
                return false;
            }

            return (!string.IsNullOrWhiteSpace(value.ToString()));
        }

        /// <summary>
        /// Gets the property information list.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static List<PropertyInfo> GetPropertyInfoList(this object obj)
        {
            return (obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.IsDataMember()).ToList());
        }

        /// <summary>
        /// Gets the key list.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static List<PropertyInfo> GetKeyList(this object obj)
        {
            return (obj.GetType()
                       .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                       .Where(x => x.IsDataMember() && x.IsKey())
                       .ToList());
        }

        /// <summary>
        /// Gets the key string.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static string GetKeyString(this object obj)
        {
            string keyString = null;
            var keyList = obj.GetKeyList();

            if (keyList != null && keyList.Count > 0)
            {
                foreach (PropertyInfo propertyInfo in keyList)
                {
                    keyString += string.Format(" {0}='{1}' AND", propertyInfo.Name, propertyInfo.GetValue(obj, null));
                }

                keyString = keyString.Remove((keyString.Length - 3), 3);
            }

            return keyString;
        }

        /// <summary>
        /// Gets the property information name list.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static List<string> GetPropertyInfoNameList(this object obj)
        {
            return (obj.GetType()
                       .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                       .Where(x => x.IsDataMember())
                       .Select(x => x.Name)
                       .ToList());
        }

        /// <summary>
        /// Gets the byte array columns.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static List<string> GetByteArrayColumns(this object obj)
        {
            return (obj.GetType()
                       .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                       .Where(x => x.IsDataMember() && x.PropertyType.IsByteArray())
                       .Select(x => x.Name)
                       .ToList());
        }

        /// <summary>
        /// Gets the byte array list.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static List<PropertyInfo> GetByteArrayList(this object obj)
        {
            return (obj.GetType()
                       .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                       .Where(x => x.IsDataMember() && x.PropertyType.IsByteArray())
                       .ToList());
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static string GetName(this object obj)
        {
            return (obj.GetType().Name);
        }

        /// <summary>
        /// Gets the columns.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static string GetColumns(this object obj)
        {
            string columns = null;
            var propertyInfoNameList = obj.GetPropertyInfoNameList();

            for (int i = 0; i < propertyInfoNameList.Count; i++)
            {
                columns += propertyInfoNameList[i] + ",";
            }

            columns = columns.Remove((columns.Length - 1), 1);

            return columns;
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static string GetValues(this object obj)
        {
            string values = null;
            object value = null;
            var propertyInfoList = obj.GetPropertyInfoList();

            foreach (PropertyInfo propertyInfo in propertyInfoList)
            {
                if (propertyInfo.PropertyType.IsByteArray())
                    value = string.Empty;
                else
                    value = propertyInfo.GetValue(obj, null);

                if (value == null)
                {
                    if (propertyInfo.PropertyType.IsString())
                        values += "'',";
                    else
                        values += "NULL,";
                }
                else
                {
                    if (propertyInfo.PropertyType.IsFloatingPoint())
                        value = value.ToString().Replace(",", ".");

                    values += string.Format("'{0}',", value);
                }
            }

            values = values.Remove((values.Length - 1), 1);

            return values;
        }

        /// <summary>
        /// Gets the byte array values.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static List<byte[]> GetByteArrayValues(this object obj)
        {
            List<byte[]> byteArrayValues = null;
            byte[] byteArray = null;
            var propertyInfoList = obj.GetByteArrayList();

            if (propertyInfoList != null && propertyInfoList.Count > 0)
            {
                byteArrayValues = new List<byte[]>();

                foreach (PropertyInfo propertyInfo in propertyInfoList)
                {
                    byteArray = (byte[])propertyInfo.GetValue(obj, null);
                    byteArrayValues.Add(byteArray);
                }
            }

            return byteArrayValues;
        }

        /// <summary>
        /// Gets the byte array values.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static List<byte[]> GetByteArrayValues(this object obj, int size)
        {
            if (size == 0)
            {
                return null;
            }
            else
            {
                return obj.GetByteArrayValues();
            }
        }
    }
}