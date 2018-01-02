using System;

namespace SFSQLiteApi.Utils.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed class TableKeyAttribute : Attribute
    {
        public TableKeyAttribute()
        {
        }
    }
}