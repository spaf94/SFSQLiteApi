using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace SFSQLiteApi.Utils
{
    internal static class PropertyInfoExtension
    {
        /// <summary>
        /// Determines whether [is data member].
        /// </summary>
        /// <param name="property">The property.</param>
        /// <returns>
        ///   <c>true</c> if [is data member] [the specified property]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDataMember(this PropertyInfo property)
        {
            return (property.GetCustomAttributes(true).OfType<DataMemberAttribute>().Count() > 0);
        }

        /// <summary>
        /// Determines whether this instance is key.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <returns>
        ///   <c>true</c> if the specified property is key; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsKey(this PropertyInfo property)
        {
            return (property.GetCustomAttributes(true).OfType<KeyAttribute>().Count() > 0);
        }
    }
}