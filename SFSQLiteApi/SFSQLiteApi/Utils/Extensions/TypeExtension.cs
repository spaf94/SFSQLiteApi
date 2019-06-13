using System;

namespace SFSQLiteApi.Utils
{
    public static class TypeExtension
    {
        #region Members

        private const string Blob = "BLOB";
        private const string ByteArray = "Byte[]";
        private const string Integer = "INTEGER";
        private const string Numeric = "NUMERIC";
        private const string Real = "REAL";
        private const string Text = "TEXT";

        #endregion Members

        #region Public Methods

        /// <summary>
        /// Gets the type of the data.
        /// </summary>
        /// <param name="inType">Type of the in.</param>
        /// <param name="outType">Type of the out.</param>
        public static void GetDataType(Type inType, out Type outType)
        {
            outType = inType;

            if (inType.IsNull())
            {
                outType = Nullable.GetUnderlyingType(inType);
            }
        }

        /// <summary>
        /// Determines whether this instance is bool.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   <c>true</c> if the specified type is bool; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsBool(this Type type)
        {
            GetDataType(type, out type);
            return (Type.GetTypeCode(type) == TypeCode.Boolean);
        }

        /// <summary>
        /// Determines whether [is byte array].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   <c>true</c> if [is byte array] [the specified type]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsByteArray(this Type type)
        {
            return (type.Name == ByteArray);
        }

        /// <summary>
        /// Determines whether [is date time].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   <c>true</c> if [is date time] [the specified type]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDateTime(this Type type)
        {
            GetDataType(type, out type);
            return (Type.GetTypeCode(type) == TypeCode.DateTime);
        }

        /// <summary>
        /// Determines whether this instance is null.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   <c>true</c> if the specified type is null; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNull(this Type type)
        {
            return (Nullable.GetUnderlyingType(type) != null);
        }

        /// <summary>
        /// Determines whether this instance is number.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   <c>true</c> if the specified type is number; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNumber(this Type type)
        {
            GetDataType(type, out type);
            TypeCode typeCode = Type.GetTypeCode(type);

            switch (typeCode)
            {
                case TypeCode.Byte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;

                default:
                    return false;
            }
        }

        /// <summary>
        /// Determines whether this instance is string.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   <c>true</c> if the specified type is string; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsString(this Type type)
        {
            GetDataType(type, out type);
            return (Type.GetTypeCode(type) == TypeCode.String);
        }

        /// <summary>
        /// To the type of the sq lite data.
        /// </summary>
        /// <param name="type">The type.</param>
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
        /// Determines whether [is floating point].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   <c>true</c> if [is floating point] [the specified type]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFloatingPoint(this Type type)
        {
            GetDataType(type, out type);
            TypeCode typeCode = Type.GetTypeCode(type);

            switch (typeCode)
            {
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;

                default:
                    return false;
            }
        }

        #endregion Public Methods
    }
}