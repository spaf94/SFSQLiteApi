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

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="InsertObject"/> class.
        /// </summary>
        /// <param name="obj">The object.</param>
        public InsertObject(object obj)
        {
            this.Table = obj.GetName();
            this.Columns = obj.GetColumns();
            this.Values = obj.GetValues();
            this.ByteArrayColumns = obj.GetByteArrayColumns();
            this.ByteArrayValues = obj.GetByteArrayValues();
            this.KeyString = obj.GetKeyString();
        }

        #endregion Constructor
    }
}