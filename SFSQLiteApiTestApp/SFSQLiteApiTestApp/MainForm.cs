using SFSQLiteApi;
using System;
using System.Windows.Forms;

namespace SFSQLiteApiTestApp
{
    public partial class MainForm : Form
    {
        #region Members

        //Global object SFSQLite to use in all app
        private SFSQLite DbTest = null;

        #endregion Members

        public MainForm()
        {
            InitializeComponent();
        }

        #region 1 - Initialize Api

        private void buttonInitApi_Click(object sender, EventArgs e)
        {
            try
            {
                SFSQLite.InitializeApi();
                MessageBox.Show("OK");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        #endregion 1 - Initialize Api

        #region 2 - Create Database

        private void buttonCreateDb_Click(object sender, EventArgs e)
        {
            try
            {
                DbTest = new SFSQLite(textBoxDbName.Text);
                DbTest.OpenConnection();
                MessageBox.Show("OK");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        #endregion 2 - Create Database
    }
}