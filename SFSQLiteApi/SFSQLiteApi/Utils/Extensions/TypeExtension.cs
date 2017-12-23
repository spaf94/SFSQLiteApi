using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSQLiteApi.Utils
{
    public static class TypeExtension
    {
        #region Members

        private const string Numeric = "NUMERIC";
        private const string Integer = "INTEGER";
        private const string Text = "TEXT";
        private const string Real = "REAL";
        private const string Blob = "BLOB";
        private const string ByteArray = "Byte[]";

        #endregion

        /// <summary>
        /// Converte um tipo de dados para o tipo de dados SQLite em string
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string ToSQLiteDataType(this Type type)
        {
            GetDataType(type, out type);
            TypeCode typeCode = Type.GetTypeCode(type);

            switch (typeCode)
            {
                case TypeCode.Boolean:
                    return Numeric;

                case TypeCode.Byte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return Integer;

                case TypeCode.Char:
                case TypeCode.DateTime:
                case TypeCode.String:
                    return Text;

                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return Real;
            }

            return Blob;
        }

        /// <summary>
        /// Obter tipo de dados principal no caso de permitir nulos
        /// </summary>
        /// <param name="inType"></param>
        /// <param name="outType"></param>
        public static void GetDataType(Type inType, out Type outType)
        {
            outType = inType;

            if (inType.IsNull())
            {
                outType = Nullable.GetUnderlyingType(inType);
            }
        }

        /// <summary>
        /// Retorna se um tipo de dados permite nulos
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNull(this Type type)
        {
            return (Nullable.GetUnderlyingType(type) != null);
        }

        /// <summary>
        /// Retorna se um tipo de dados é um booleano
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsBool(this Type type)
        {
            GetDataType(type, out type);
            return (Type.GetTypeCode(type) == TypeCode.Boolean);
        }

        /// <summary>
        /// Retorna se um tipo de dados é um array de bytes
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsByteArray(this Type type)
        {
            return (type.Name == ByteArray);
        }

        /// <summary>
        /// Retorna se um tipo de dados é uma string
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsString(this Type type)
        {
            GetDataType(type, out type);
            return (Type.GetTypeCode(type) == TypeCode.String);
        }
    }
}
