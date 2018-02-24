using SFSQLiteApi.Utils;
using SFSQLiteApi.Utils.DataModel;
using SFSQLiteApi.Utils.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SFSQLiteApi
{
    internal class SFSQLiteConnection
    {
        #region Members

        /// <summary>
        /// Gets or sets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        private SQLiteConnection Connection { get; set; }

        #endregion Members

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SFSQLiteConnection"/> class.
        /// </summary>
        /// <param name="db">The database.</param>
        public SFSQLiteConnection(string db)
        {
            //Create database if not exists
            this.CreateDatabase(db);
            //Connects to database
            this.OpenDbConnection(db);
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Closes the database connection.
        /// </summary>
        /// <returns></returns>
        public bool CloseDbConnection()
        {
            bool result = true;

            try
            {
                if (this.Connection.State != ConnectionState.Closed)
                {
                    this.Connection.Close();
                }
            }
            catch (Exception exception)
            {
                APILog.Error(this, "CloseDbConnection", exception);
                result = false;
            }
            finally
            {
                this.Connection.Dispose();
                this.Connection = null;
            }

            return result;
        }

        /// <summary>
        /// Creates the table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void CreateTable<T>()
        {
            try
            {
                int aux = 1;
                List<string> keyColumnList = new List<string>();

                var objectType = typeof(T);
                var propertyList = objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                StringBuilder sbCreateTable = new StringBuilder();
                sbCreateTable.Append("CREATE TABLE IF NOT EXISTS ");
                sbCreateTable.Append(objectType.Name);
                sbCreateTable.Append("(");

                foreach (var property in propertyList)
                {
                    if (property.IsDataMember())
                    {
                        if (property.IsKey())
                        {
                            keyColumnList.Add(property.Name);
                        }

                        sbCreateTable.Append(property.Name);
                        sbCreateTable.Append(" ");
                        sbCreateTable.Append(property.PropertyType.ToSQLiteDataType());

                        if (property.PropertyType.IsNull())
                        {
                            sbCreateTable.Append(" NULL");
                        }
                        else
                        {
                            sbCreateTable.Append(" NOT NULL");
                        }

                        sbCreateTable.Append(",");
                    }
                }

                if (keyColumnList.Count > 0)
                {
                    sbCreateTable.Append("PRIMARY KEY (");

                    foreach (string key in keyColumnList)
                    {
                        sbCreateTable.Append(key);

                        if (aux < keyColumnList.Count)
                        {
                            sbCreateTable.Append(",");
                        }

                        aux++;
                    }

                    sbCreateTable.Append("));");
                }
                else
                {
                    sbCreateTable.Remove((sbCreateTable.Length - 1), 1);
                    sbCreateTable.Append(");");
                }

                SQLiteQuery.ExecuteNonQuery(sbCreateTable.ToString(), this.Connection);
            }
            catch (Exception exception)
            {
                APILog.Error(this, "CreateTable", exception);
            }
        }

        /// <summary>
        /// Deletes the row.
        /// </summary>
        /// <param name="deleteObj">The delete object.</param>
        /// <returns></returns>
        public int DeleteRow(object deleteObj)
        {
            int aux = 1;
            var keyColumnList = new List<string>();

            var objectType = deleteObj.GetType();
            var propertyList = objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            StringBuilder deleteQuery = new StringBuilder();
            deleteQuery.Append("DELETE FROM ");
            deleteQuery.Append(objectType.Name);
            deleteQuery.Append(" WHERE ");
            aux = 1;

            foreach (var property in propertyList.Where(x => x.IsDataMember() && x.IsKey()))
            {
                keyColumnList.Add(property.Name);
            }

            foreach (string key in keyColumnList)
            {
                PropertyInfo property = propertyList.FirstOrDefault(x => x.Name == key);

                if (property != null)
                {
                    deleteQuery.Append(key);
                    deleteQuery.Append("=");
                    deleteQuery.Append("'");
                    deleteQuery.Append(property.GetValue(deleteObj, null));
                    deleteQuery.Append("'");
                }

                if (aux < keyColumnList.Count)
                {
                    deleteQuery.Append(" AND ");
                }

                aux++;
            }

            return (SQLiteQuery.ExecuteNonQuery(deleteQuery.ToString(), this.Connection));
        }

        /// <summary>
        /// Gets the column maximum value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        public object GetColumnMaxValue<T>(string columnName)
        {
            object returnValue = null;
            SQLiteDataReader reader = null;

            try
            {
                Type type = typeof(T);
                var propertyList = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                string sqlQuery = SQLiteQuery.MaxFromTable(type.Name, columnName);
                reader = SQLiteQuery.ExecuteReader(sqlQuery, this.Connection);

                while (reader.Read())
                {
                    returnValue = reader[Constant.MaxValue].ToString();
                }

                var property = propertyList.FirstOrDefault(x => x.Name == columnName);

                if (property != null)
                {
                    if (string.IsNullOrWhiteSpace(returnValue.ToString()))
                    {
                        if (property.PropertyType.IsNumber())
                        {
                            returnValue = 0;
                        }
                        else if (property.PropertyType.IsDateTime())
                        {
                            returnValue = DateTime.MinValue;
                        }
                    }

                    returnValue = Convert.ChangeType(returnValue, property.PropertyType);
                }
            }
            catch (Exception exception)
            {
                APILog.Error(this, "GetColumnMaxValue", exception);
            }
            finally
            {
                reader.Close();
                reader = null;
            }

            return returnValue;
        }

        /// <summary>
        /// Gets the rows total.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        public int GetRowsTotal<T>(string whereClause = "") where T : new()
        {
            int returnValue = 0;
            SQLiteDataReader reader = null;

            try
            {
                var objectType = typeof(T);
                var properties = objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                string sqlQuery = SQLiteQuery.CountTotal(objectType.Name, whereClause);
                reader = SQLiteQuery.ExecuteReader(sqlQuery, this.Connection);

                while (reader.Read())
                {
                    returnValue = Convert.ToInt32(reader[Constant.TotalCount]);
                }
            }
            catch (Exception exception)
            {
                APILog.Error(this, "GetRowsTotal", exception);
            }
            finally
            {
                reader.Close();
                reader = null;
            }

            return returnValue;
        }

        /// <summary>
        /// Inserts the row.
        /// </summary>
        /// <param name="insertObj">The insert object.</param>
        /// <returns></returns>
        public int InsertRow(object obj)
        {
            int result = 0;
            InsertObject insertObject = null;
            string sqlInsert = null;

            try
            {
                insertObject = new InsertObject(obj);
                sqlInsert = string.Format(StringFormat.SqlInsert, insertObject.Table, insertObject.Columns, insertObject.Values);

                result = SQLiteQuery.ExecuteNonQuery(sqlInsert, this.Connection);

                if (result > 0)
                {
                    this.HandleByteArrayList(insertObject.Table, insertObject.ByteArrayColumns, insertObject.ByteArrayValues, insertObject.KeyString);
                }
            }
            catch (Exception exception)
            {
                APILog.Error(this, "InsertRow", exception);
            }
            finally
            {
                insertObject = null;
                sqlInsert = null;
            }

            return result;
        }

        /// <summary>
        /// Selects all rows.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        public List<T> SelectAllRows<T>(string whereClause = "") where T : new()
        {
            var objectList = new List<T>();
            SQLiteDataReader reader = null;

            try
            {
                var objectType = typeof(T);
                var properties = objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                string sqlQuery = SQLiteQuery.SelectAllFrom(objectType.Name, whereClause);
                reader = SQLiteQuery.ExecuteReader(sqlQuery, this.Connection);

                while (reader.Read())
                {
                    var newObject = new T();

                    foreach (var property in properties)
                    {
                        if (property.IsDataMember())
                        {
                            if (reader[property.Name].HaveContent())
                            {
                                Type type = property.PropertyType;
                                TypeExtension.GetDataType(type, out type);

                                object propertyValue = reader[property.Name];
                                dynamic changedObject = Convert.ChangeType(propertyValue, type);
                                property.SetValue(newObject, changedObject, null);
                            }
                        }
                    }

                    objectList.Add(newObject);
                }
            }
            catch (Exception exception)
            {
                APILog.Error(this, "SelectAllRows", exception);
            }
            finally
            {
                reader.Close();
                reader = null;
            }

            return objectList;
        }

        /// <summary>
        /// Selects the one row.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        public T SelectOneRow<T>(string whereClause = "") where T : new()
        {
            var objectList = this.SelectAllRows<T>(whereClause);

            return (objectList.FirstOrDefault());
        }

        /// <summary>
        /// Updates the row.
        /// </summary>
        /// <param name="updateObj">The update object.</param>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        public int UpdateRow(object updateObj, string whereClause = "")
        {
            int aux = 1;
            var keyColumnList = new List<string>();
            var byteArrayColumnList = new List<string>();
            var byteArrayList = new List<byte[]>();

            var objectType = updateObj.GetType();
            var propertyList = objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            int propertiesCount = propertyList.Length;

            StringBuilder updateQuery = new StringBuilder();
            updateQuery.Append("UPDATE ");
            updateQuery.Append(objectType.Name);
            updateQuery.Append(" SET ");

            foreach (var property in propertyList)
            {
                if (property.IsDataMember())
                {
                    if (property.IsKey())
                    {
                        keyColumnList.Add(property.Name);
                    }

                    updateQuery.Append(property.Name);
                    updateQuery.Append("=");

                    object value = property.GetValue(updateObj, null);
                    value = Utility.GetValue(byteArrayColumnList, byteArrayList, property, value);

                    if (value == null)
                    {
                        updateQuery.Append("NULL");
                    }
                    else
                    {
                        updateQuery.Append("'");
                        updateQuery.Append(value.ToString());
                        updateQuery.Append("'");
                    }

                    if (aux < propertiesCount)
                    {
                        updateQuery.Append(",");
                    }
                }

                aux++;
            }

            if (updateQuery.ToString().EndsWith(","))
            {
                updateQuery.Remove((updateQuery.Length - 1), 1);
            }

            updateQuery.Append(" WHERE ");
            aux = 1;

            if (string.IsNullOrWhiteSpace(whereClause))
            {
                foreach (string key in keyColumnList)
                {
                    PropertyInfo property = propertyList.FirstOrDefault(x => x.Name == key);

                    if (property != null)
                    {
                        updateQuery.Append(key);
                        updateQuery.Append("=");
                        updateQuery.Append("'");
                        updateQuery.Append(property.GetValue(updateObj, null));
                        updateQuery.Append("'");
                    }

                    if (aux < keyColumnList.Count)
                    {
                        updateQuery.Append(" AND ");
                    }

                    aux++;
                }
            }
            else
            {
                updateQuery.Append(whereClause);
            }

            int result = SQLiteQuery.ExecuteNonQuery(updateQuery.ToString(), this.Connection);

            if (result > 0)
            {
                this.HandleByteArrayList(objectType.Name, byteArrayColumnList, byteArrayList, null);
            }

            return result;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Creates the database.
        /// </summary>
        /// <param name="db">The database.</param>
        private void CreateDatabase(string db)
        {
            db = Path.ChangeExtension(db, Constant.SQLite);

            if (!File.Exists(db))
            {
                SQLiteConnection.CreateFile(db);
            }
        }

        /// <summary>
        /// Handles the byte array list.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="byteArrayColumnList">The byte array column list.</param>
        /// <param name="byteArrayList">The byte array list.</param>
        /// <param name="where">The where.</param>
        private void HandleByteArrayList(string tableName, List<string> byteArrayColumnList, List<byte[]> byteArrayList, string where)
        {
            for (int i = 0; i < byteArrayColumnList.Count; i++)
            {
                SQLiteQuery.InsertUpdateByteArray(tableName, byteArrayColumnList[i], byteArrayList[i], where, this.Connection);
            }
        }

        /// <summary>
        /// Opens the database connection.
        /// </summary>
        /// <param name="db">The database.</param>
        private void OpenDbConnection(string db)
        {
            string connectionString = string.Format(StringFormat.ConnectionString, db);
            this.Connection = new SQLiteConnection(connectionString);

            if (this.Connection.State != ConnectionState.Open)
            {
                this.Connection.Open();
            }
        }

        #endregion Private Methods
    }
}