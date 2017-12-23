using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SFSQLiteApi.Utils
{
    internal static class Utility
    {
        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;

            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }

        public static object GetValue(List<string> photoColumns, List<byte[]> photoList, PropertyInfo property, object value)
        {
            if (property.PropertyType.IsByteArray())
            {
                photoColumns.Add(property.Name);
                photoList.Add((byte[])value);
                return 0;
            }

            if (property.PropertyType.IsBool())
            {
                return (Convert.ToInt16(value));
            }

            if ((value == null) && property.PropertyType.IsString())
            {
                return (string.Empty);
            }

            return value;
        }
    }
}
