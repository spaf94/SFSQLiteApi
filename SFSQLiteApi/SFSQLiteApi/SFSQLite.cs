using LoadDllAsEmbeddedRes;
using SFSQLiteApi.Utils;
using SFSQLiteApi.Utils.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SFSQLiteApi
{
    public class SFSQLite
    {
        #region Members

        /// <summary>
        /// The connection
        /// </summary>
        private SFSQLiteConnection connection = null;

        #endregion Members

        #region Properties

        /// <summary>
        /// Gets or sets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        private SFSQLiteConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    throw new Exception("Connection not created. Use method OpenConnection().");
                }

                return connection;
            }
            set
            {
                connection = value;
            }
        }

        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        private string Database { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SFSQLite"/> class.
        /// </summary>
        /// <param name="db">The database.</param>
        public SFSQLite(string db)
        {
            this.Database = db;
        }

        #endregion Constructors

        #region Public Static Methods

        /// <summary>
        /// Activates the logs.
        /// </summary>
        public static void ActivateLogs()
        {
            APILog.ActivateLog();
        }

        /// <summary>
        /// Deactivates the logs.
        /// </summary>
        public static void DeactivateLogs()
        {
            APILog.DeactivateLog();
        }

        /// <summary>
        /// Inicializa API
        /// </summary>
        public static void InitializeApi()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string[] resourceList = assembly.GetManifestResourceNames();

            foreach (string resource in resourceList)
            {
                if (resource.Contains(Constant.SQLiteDll))
                {
                    EmbeddedAssembly.Load(resource, Constant.SQLiteDll);
                    AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
                }
                else if (resource.Contains(Constant.SFLogDll))
                {
                    EmbeddedAssembly.Load(resource, Constant.SFLogDll);
                    AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
                }
                else
                {
                    string fileName = string.Empty;
                    Stream stream = assembly.GetManifestResourceStream(resource);

                    if (resource.Contains(Constant.SQLiteInteropDllGzX64))
                    {
                        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Constant.x64);

                        if (!Directory.Exists(filePath))
                        {
                            Directory.CreateDirectory(filePath);
                        }

                        fileName = Path.Combine(filePath, Constant.SQLiteInteropDllGzX64);
                    }
                    else if (resource.Contains(Constant.SQLiteInteropDllGzX86))
                    {
                        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Constant.x86);

                        if (!Directory.Exists(filePath))
                        {
                            Directory.CreateDirectory(filePath);
                        }

                        fileName = Path.Combine(filePath, Constant.SQLiteInteropDllGzX86);
                    }

                    if (!File.Exists(fileName))
                    {
                        using (Stream file = File.Create(fileName))
                        {
                            Utility.CopyStream(stream, file);
                        }

                        Utility.DecompressGZip(fileName, Constant.SQLiteInteropDll);
                        File.Delete(fileName);
                    }
                }
            }
        }

        #endregion Public Static Methods

        #region Public Methods

        /// <summary>
        /// Closes the connection.
        /// </summary>
        public void CloseConnection()
        {
            this.Connection.CloseDbConnection();
            this.Connection = null;
        }

        /// <summary>
        /// Creates the table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void CreateTable<T>()
        {
            this.Connection.CreateTable<T>();
        }

        /// <summary>
        /// Deletes all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool DeleteAll<T>()
        {
            return (this.Connection.DeleteAll<T>());
        }

        /// <summary>
        /// Deletes the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectList">The object list.</param>
        /// <returns></returns>
        public bool DeleteList<T>(List<T> objectList)
        {
            return (this.Connection.DeleteList<T>(objectList));
        }

        /// <summary>
        /// Deletes the row.
        /// </summary>
        /// <param name="deleteObj">The delete object.</param>
        /// <returns></returns>
        public int DeleteRow(object deleteObj)
        {
            return (this.Connection.DeleteRow(deleteObj));
        }

        /// <summary>
        /// Drops the table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void DropTable<T>()
        {
            this.Connection.DropTable<T>();
        }

        /// <summary>
        /// Gets the column maximum value.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        public object GetColumnMaxValue<T>(string columnName)
        {
            return (this.Connection.GetColumnMaxValue<T>(columnName));
        }

        /// <summary>
        /// Gets the rows total.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        public int GetRowsTotal<T>(string whereClause = "") where T : new()
        {
            return (this.Connection.GetRowsTotal<T>(whereClause));
        }

        /// <summary>
        /// Inserts the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectList">The object list.</param>
        /// <returns></returns>
        public bool InsertList<T>(List<T> objectList)
        {
            return (this.Connection.InsertList<T>(objectList));
        }

        /// <summary>
        /// Inserts the row.
        /// </summary>
        /// <param name="insertObj">The insert object.</param>
        /// <returns></returns>
        public int InsertRow(object insertObj)
        {
            return (this.Connection.InsertRow(insertObj));
        }

        /// <summary>
        /// Opens the connection.
        /// </summary>
        public void OpenConnection()
        {
            this.Connection = new SFSQLiteConnection(this.Database);
        }

        /// <summary>
        /// Selects all rows.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        public List<T> SelectAllRows<T>(string whereClause = "") where T : new()
        {
            return (this.Connection.SelectAllRows<T>(whereClause));
        }

        /// <summary>
        /// Selects the one row.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        public T SelectOneRow<T>(string whereClause = "") where T : new()
        {
            return (this.Connection.SelectOneRow<T>(whereClause));
        }

        /// <summary>
        /// Updates the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectList">The object list.</param>
        /// <returns></returns>
        public bool UpdateList<T>(List<T> objectList)
        {
            return (this.Connection.UpdateList<T>(objectList));
        }

        /// <summary>
        /// Updates the row.
        /// </summary>
        /// <param name="updateObj">The update object.</param>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        public int UpdateRow(object updateObj, string whereClause = "")
        {
            return (this.Connection.UpdateRow(updateObj, whereClause));
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Handles the AssemblyResolve event of the CurrentDomain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="ResolveEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return EmbeddedAssembly.Get(args.Name);
        }

        #endregion Private Methods
    }
}