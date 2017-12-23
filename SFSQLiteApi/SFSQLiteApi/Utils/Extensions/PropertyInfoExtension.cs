using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SFSQLiteApi.Utils
{
    internal static class PropertyInfoExtension
    {
        public static bool IsKey(this PropertyInfo property)
        {
            return (property.GetCustomAttributes(true).OfType<KeyAttribute>().Count() > 0);
        }

        public static bool IsDataMember(this PropertyInfo property)
        {
            return (property.GetCustomAttributes(true).OfType<DataMemberAttribute>().Count() > 0);
        }
    }
}
