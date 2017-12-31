using SFSQLiteApi;
using SFSQLiteApiTestApp.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace SFSQLiteApiTestApp
{
    public partial class MainForm : Form
    {
        #region Members

        //Global object SFSQLite to use in all app
        private SFSQLite DbTest = null;

        #endregion Members

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion Constructor

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

        #region 2 - Create Database and Open Connection

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

        #endregion 2 - Create Database and Open Connection

        #region 3 - Create Table

        private void buttonCreateTable_Click(object sender, EventArgs e)
        {
            try
            {
                //Creates the Person table according to the properties and attributes of the object
                this.DbTest.CreateTable<Person>();
                MessageBox.Show("OK");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        #endregion 3 - Create Table

        #region 4 - Get Rows Total

        private void buttonGetRowsTotal_Click(object sender, EventArgs e)
        {
            int totalA = 0;
            int totalB = 0;
            string where = string.Empty;

            //Count rows without where statement
            totalA = (int)this.DbTest.GetRowsTotal<Person>();

            //Count rows with where statement
            where = "PersonId > 5";
            totalB = (int)this.DbTest.GetRowsTotal<Person>(where);

            MessageBox.Show(string.Format("Total without where: {0} \n Total with where: {1}", totalA, totalB));
        }

        #endregion 4 - Get Rows Total

        #region 5 - Insert Row

        private void buttonInsertRow_Click(object sender, EventArgs e)
        {
            //For example, gets a new a Id
            int newId = (int)this.DbTest.GetColumnMaxValue<Person>("PersonId") + 1;

            //Creates a new object Person and fill the properties values
            Person person = new Person();
            person.PersonId = newId;
            person.Name = "Person Name " + newId;
            person.Address = "Person Address " + newId;
            person.BirthDate = DateTime.Now.AddYears(-newId);
            person.IsValid = true;

            //Checks if the object exists in the database
            string where = "PersonId = " + newId;

            if (this.DbTest.GetRowsTotal<Person>(where) == 0)
            {
                //If not exists, insert the object in the database
                if (this.DbTest.InsertRow(person) > 0)
                {
                    MessageBox.Show("INSERT OK");
                }
                else
                {
                    MessageBox.Show("INSERT ERROR");
                }
            }
        }

        #endregion 5 - Insert Row

        #region 6 - Update Row

        private void buttonUpdateRow_Click(object sender, EventArgs e)
        {
            //For example, lets update the the person 1
            Person person = new Person();
            person.PersonId = 1; //PersonId 1
            person.Name = "Updated Name";
            person.Address = "Updated Address";
            person.BirthDate = new DateTime(1994, 6, 24);
            person.IsValid = false;

            string where = string.Format("PersonId={0}", person.PersonId);

            //Checks if the object exists in the database
            if (this.DbTest.GetRowsTotal<Person>(where) > 0)
            {
                //If exists, update the object in the database
                if (this.DbTest.UpdateRow(person) > 0)
                {
                    MessageBox.Show("UPDATE OK");
                }
                else
                {
                    MessageBox.Show("UPDATE ERROR");
                }
            }
            else
            {
                MessageBox.Show(string.Format("Person {0} don't exists in the database!", person.PersonId));
            }
        }

        #endregion 6 - Update Row

        #region 7 - Delete Row

        private void buttonDeleteRow_Click(object sender, EventArgs e)
        {
            //For example, lets delete the the person 1
            Person person = new Person();
            person.PersonId = 1; //PersonId 1

            /*
            person.Name = "Updated Name";
            person.Address = "Updated Address";
            person.BirthDate = new DateTime(1994, 6, 24);
            person.IsValid = false;
            */

            string where = string.Format("PersonId={0}", person.PersonId);

            //Delete the object from the database
            if (this.DbTest.DeleteRow(person) > 0)
            {
                MessageBox.Show("DELETE OK");
            }
            else
            {
                MessageBox.Show("ERROR OR OBJECT NOT FOUND");
            }
        }

        #endregion 7 - Delete Row

        #region 8 - Select All Rows

        private void buttonSelectAllRows_Click(object sender, EventArgs e)
        {
            //Select all persons from database without where clause
            var personList = this.DbTest.SelectAllRows<Person>();
            this.ShowPersonListInfo(personList);

            //Select all persons from database with where statement
            string where = "PersonId > 3";
            personList = this.DbTest.SelectAllRows<Person>(where);
            this.ShowPersonListInfo(personList);
        }

        #endregion 8 - Select All Rows

        #region 9 - Select One Row

        private void buttonSelectOneRow_Click(object sender, EventArgs e)
        {
            //Selects the person id 3 from database
            string where = "PersonId = 3";
            var person = this.DbTest.SelectOneRow<Person>(where);
            this.ShowPersonInfo(person);
        }

        #endregion 9 - Select One Row

        #region 10 - Get Column Max Value

        private void buttonGetColumnMaxValue_Click(object sender, EventArgs e)
        {
            //Gets max PersonId - Necessary the cast to Int32 type
            int maxPersonId = (int)this.DbTest.GetColumnMaxValue<Person>("PersonId");
            //Gets max BirthDate - necessary the cast to DateTime type
            DateTime maxBirthDate = (DateTime)this.DbTest.GetColumnMaxValue<Person>("BirthDate");

            MessageBox.Show(string.Format("Max PersonId: {0} | Max BirthDate: {1}", maxPersonId, maxBirthDate));
        }

        #endregion 10 - Get Column Max Value

        #region 11 - Close Connection

        private void buttonCloseConnection_Click(object sender, EventArgs e)
        {
            this.DbTest.CloseConnection();
            MessageBox.Show("OK");
        }

        #endregion 11 - Close Connection

        #region Util Methods

        /// <summary>
        /// Shows the person information.
        /// </summary>
        /// <param name="person">The person.</param>
        private void ShowPersonInfo(Person person)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            MessageBox.Show(jss.Serialize(person));
        }

        /// <summary>
        /// Shows the person list information.
        /// </summary>
        /// <param name="personList">The person list.</param>
        private void ShowPersonListInfo(List<Person> personList)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            StringBuilder sbPersonList = new StringBuilder();

            foreach (Person person in personList)
            {
                string aux = jss.Serialize(person);
                sbPersonList.AppendLine(aux);
                sbPersonList.AppendLine();
            }

            MessageBox.Show(sbPersonList.ToString());
        }

        #endregion Util Methods
    }
}