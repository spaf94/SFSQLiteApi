using LoadDllAsEmbeddedRes;
using SFSQLiteApi.Utils;
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
        /// Ligação à API
        /// </summary>
        private SFSQLiteConnection Connection { get; set; }

        /// <summary>
        /// Nome da base de dados
        /// </summary>
        private string Database { get; set; }

        #endregion Members

        #region Constructors

        /// <summary>
        /// Cria nova conexão à API (Instanciação)
        /// </summary>
        /// <param name="db"></param>
        public SFSQLite(string db)
        {
            this.Database = db;
        }

        #endregion Constructors

        #region Public Static Methods

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
                else
                {
                    string fileName = string.Empty;
                    Stream stream = assembly.GetManifestResourceStream(resource);

                    if (resource.Contains(Constant.x64))
                    {
                        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Constant.x64);

                        if (!Directory.Exists(filePath))
                        {
                            Directory.CreateDirectory(filePath);
                        }

                        fileName = Path.Combine(filePath, Constant.SQLiteInteropDll);
                    }
                    else if (resource.Contains(Constant.x86))
                    {
                        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Constant.x86);

                        if (!Directory.Exists(filePath))
                        {
                            Directory.CreateDirectory(filePath);
                        }

                        fileName = Path.Combine(filePath, Constant.SQLiteInteropDll);
                    }

                    if (!File.Exists(fileName))
                    {
                        using (Stream file = File.Create(fileName))
                        {
                            Utility.CopyStream(stream, file);
                        }
                    }
                }
            }
        }

        #endregion Public Static Methods

        #region Public Methods

        /// <summary>
        /// Fecha ligação à base de dados e destroi objeto
        /// </summary>
        public void CloseConnection()
        {
            this.Connection.CloseDbConnection();
            this.Connection = null;
        }

        /// <summary>
        /// Cria nova tabela na base de dados com base no tipo de objeto T recebido
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void CreateTable<T>()
        {
            this.Connection.CreateTable<T>();
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
        /// Retorna total de linhas que existem na tabela do objeto T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public ulong GetRowsTotal<T>(string whereClause = "") where T : new()
        {
            return (this.Connection.GetRowsTotal<T>(whereClause));
        }

        /// <summary>
        /// Insere um novo registo na tabela do tipo do objeto passado como parametro
        /// </summary>
        /// <param name="insertObj"></param>
        /// <returns></returns>
        public int InsertRow(object insertObj)
        {
            return (this.Connection.InsertRow(insertObj));
        }

        /// <summary>
        /// Inicia ligação à base de dados
        /// </summary>
        public void OpenConnection()
        {
            this.Connection = new SFSQLiteConnection(this.Database);
        }

        /// <summary>
        /// Retorna lista de objetos T após um SELECT à base de dados
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereClause"></param>
        /// <returns></returns>
        public List<T> SelectAllRows<T>(string whereClause = "") where T : new()
        {
            return (this.Connection.SelectAllRows<T>(whereClause));
        }

        /// <summary>
        /// Retorna um objeto T após um SELECT à base de dados
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereClause"></param>
        /// <returns></returns>
        public T SelectOneRow<T>(string whereClause = "") where T : new()
        {
            return (this.Connection.SelectOneRow<T>(whereClause));
        }

        /// <summary>
        /// Atualiza registo na tabela do tipo do objeto passado como parametro
        /// </summary>
        /// <param name="updateObj"></param>
        /// <param name="whereClause"></param>
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