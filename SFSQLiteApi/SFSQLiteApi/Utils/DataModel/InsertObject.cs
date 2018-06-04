using System.Collections.Generic;

namespace SFSQLiteApi.Utils.DataModel
{
    internal class InsertObject
    {
        #region Properties

        /// <summary>
        /// Gets or sets the byte array columns.
        /// </summary>
        /// <value>
        /// The byte array columns.
        /// </value>
        public List<string> ByteArrayColumns { get; set; }

        /// <summary>
        /// Gets or sets the byte array values.
        /// </summary>
        /// <value>
        /// The byte array values.
        /// </value>
        public List<byte[]> ByteArrayValues { get; set; }

        /// <summary>
        /// Gets or sets the columns.
        /// </summary>
        /// <value>
        /// The columns.
        /// </value>
        public string Columns { get; set; }

        /// <summary>
        /// Gets or sets the key string.
        /// </summary>
        /// <value>
        /// The key string.
        /// </value>
        public string KeyString { get; set; }

        /// <summary>
        /// Gets or sets the table.
        /// </summary>
        /// <value>
        /// The table.
        /// </value>
        public string Table { get; set; }

        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        /// <value>
        /// The values.
        /// </value>
        public string Values { get; set; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Creates the instance.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        internal static InsertObject CreateInstance(object obj)
        {
            string table = obj.GetName();
            InsertObject insertObject = null;

            if (Cache.InsertObjectList.ContainsKey(table))
            {
                insertObject = Cache.InsertObjectList[table];
                insertObject.Values = obj.GetValues();
                insertObject.ByteArrayValues = obj.GetByteArrayValues(insertObject.ByteArrayColumns.Count);
                insertObject.KeyString = obj.GetKeyString();
            }
            else
            {
                insertObject = new InsertObject();
                insertObject.Table = table;
                insertObject.Columns = obj.GetColumns();
                insertObject.Values = obj.GetValues();
                insertObject.ByteArrayColumns = obj.GetByteArrayColumns();
                insertObject.ByteArrayValues = obj.GetByteArrayValues(insertObject.ByteArrayColumns.Count);
                insertObject.KeyString = obj.GetKeyString();

                Cache.InsertObjectList.Add(insertObject.Table, insertObject);
            }

            return insertObject;
        }

        #endregion
    }
}