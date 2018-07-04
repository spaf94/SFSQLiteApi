namespace SFSQLiteApiTestApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonInitApi = new System.Windows.Forms.Button();
            this.textBoxDbName = new System.Windows.Forms.TextBox();
            this.labelDbName = new System.Windows.Forms.Label();
            this.buttonCreateDb = new System.Windows.Forms.Button();
            this.buttonCreateTable = new System.Windows.Forms.Button();
            this.buttonGetRowsTotal = new System.Windows.Forms.Button();
            this.buttonInsertRow = new System.Windows.Forms.Button();
            this.buttonUpdateRow = new System.Windows.Forms.Button();
            this.buttonDeleteRow = new System.Windows.Forms.Button();
            this.buttonSelectAllRows = new System.Windows.Forms.Button();
            this.buttonSelectOneRow = new System.Windows.Forms.Button();
            this.buttonCloseConnection = new System.Windows.Forms.Button();
            this.buttonGetColumnMaxValue = new System.Windows.Forms.Button();
            this.buttonActivateLogs = new System.Windows.Forms.Button();
            this.buttonDeactivateLogs = new System.Windows.Forms.Button();
            this.buttonGetKeyValueList = new System.Windows.Forms.Button();
            this.buttonGetKeyValueString = new System.Windows.Forms.Button();
            this.buttonGetTableName = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSFSQLiteConnection = new System.Windows.Forms.TabPage();
            this.buttonDropTable = new System.Windows.Forms.Button();
            this.buttonDeleteAll = new System.Windows.Forms.Button();
            this.buttonDeleteList = new System.Windows.Forms.Button();
            this.buttonUpdateList = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPageSFSQLiteTool = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPageSFSQLiteConnection.SuspendLayout();
            this.tabPageSFSQLiteTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonInitApi
            // 
            this.buttonInitApi.Location = new System.Drawing.Point(6, 6);
            this.buttonInitApi.Name = "buttonInitApi";
            this.buttonInitApi.Size = new System.Drawing.Size(95, 23);
            this.buttonInitApi.TabIndex = 0;
            this.buttonInitApi.Text = "1 - Initialize Api";
            this.buttonInitApi.UseVisualStyleBackColor = true;
            this.buttonInitApi.Click += new System.EventHandler(this.buttonInitApi_Click);
            // 
            // textBoxDbName
            // 
            this.textBoxDbName.Location = new System.Drawing.Point(96, 35);
            this.textBoxDbName.Name = "textBoxDbName";
            this.textBoxDbName.Size = new System.Drawing.Size(208, 20);
            this.textBoxDbName.TabIndex = 1;
            this.textBoxDbName.Text = "HelloDb";
            // 
            // labelDbName
            // 
            this.labelDbName.AutoSize = true;
            this.labelDbName.Location = new System.Drawing.Point(6, 38);
            this.labelDbName.Name = "labelDbName";
            this.labelDbName.Size = new System.Drawing.Size(84, 13);
            this.labelDbName.TabIndex = 2;
            this.labelDbName.Text = "Database Name";
            // 
            // buttonCreateDb
            // 
            this.buttonCreateDb.Location = new System.Drawing.Point(6, 61);
            this.buttonCreateDb.Name = "buttonCreateDb";
            this.buttonCreateDb.Size = new System.Drawing.Size(298, 23);
            this.buttonCreateDb.TabIndex = 3;
            this.buttonCreateDb.Text = "2 - Create Database and Open Connection";
            this.buttonCreateDb.UseVisualStyleBackColor = true;
            this.buttonCreateDb.Click += new System.EventHandler(this.buttonCreateDb_Click);
            // 
            // buttonCreateTable
            // 
            this.buttonCreateTable.Location = new System.Drawing.Point(6, 90);
            this.buttonCreateTable.Name = "buttonCreateTable";
            this.buttonCreateTable.Size = new System.Drawing.Size(298, 23);
            this.buttonCreateTable.TabIndex = 4;
            this.buttonCreateTable.Text = "3 - Create Table";
            this.buttonCreateTable.UseVisualStyleBackColor = true;
            this.buttonCreateTable.Click += new System.EventHandler(this.buttonCreateTable_Click);
            // 
            // buttonGetRowsTotal
            // 
            this.buttonGetRowsTotal.Location = new System.Drawing.Point(6, 119);
            this.buttonGetRowsTotal.Name = "buttonGetRowsTotal";
            this.buttonGetRowsTotal.Size = new System.Drawing.Size(298, 23);
            this.buttonGetRowsTotal.TabIndex = 5;
            this.buttonGetRowsTotal.Text = "4 - Get Rows Total";
            this.buttonGetRowsTotal.UseVisualStyleBackColor = true;
            this.buttonGetRowsTotal.Click += new System.EventHandler(this.buttonGetRowsTotal_Click);
            // 
            // buttonInsertRow
            // 
            this.buttonInsertRow.Location = new System.Drawing.Point(6, 148);
            this.buttonInsertRow.Name = "buttonInsertRow";
            this.buttonInsertRow.Size = new System.Drawing.Size(297, 23);
            this.buttonInsertRow.TabIndex = 6;
            this.buttonInsertRow.Text = "5 - Insert Row";
            this.buttonInsertRow.UseVisualStyleBackColor = true;
            this.buttonInsertRow.Click += new System.EventHandler(this.buttonInsertRow_Click);
            // 
            // buttonUpdateRow
            // 
            this.buttonUpdateRow.Location = new System.Drawing.Point(6, 177);
            this.buttonUpdateRow.Name = "buttonUpdateRow";
            this.buttonUpdateRow.Size = new System.Drawing.Size(297, 23);
            this.buttonUpdateRow.TabIndex = 7;
            this.buttonUpdateRow.Text = "6 - Update Row";
            this.buttonUpdateRow.UseVisualStyleBackColor = true;
            this.buttonUpdateRow.Click += new System.EventHandler(this.buttonUpdateRow_Click);
            // 
            // buttonDeleteRow
            // 
            this.buttonDeleteRow.Location = new System.Drawing.Point(6, 206);
            this.buttonDeleteRow.Name = "buttonDeleteRow";
            this.buttonDeleteRow.Size = new System.Drawing.Size(298, 23);
            this.buttonDeleteRow.TabIndex = 8;
            this.buttonDeleteRow.Text = "7 - Delete Row";
            this.buttonDeleteRow.UseVisualStyleBackColor = true;
            this.buttonDeleteRow.Click += new System.EventHandler(this.buttonDeleteRow_Click);
            // 
            // buttonSelectAllRows
            // 
            this.buttonSelectAllRows.Location = new System.Drawing.Point(6, 235);
            this.buttonSelectAllRows.Name = "buttonSelectAllRows";
            this.buttonSelectAllRows.Size = new System.Drawing.Size(298, 23);
            this.buttonSelectAllRows.TabIndex = 9;
            this.buttonSelectAllRows.Text = "8 - Select All Rows";
            this.buttonSelectAllRows.UseVisualStyleBackColor = true;
            this.buttonSelectAllRows.Click += new System.EventHandler(this.buttonSelectAllRows_Click);
            // 
            // buttonSelectOneRow
            // 
            this.buttonSelectOneRow.Location = new System.Drawing.Point(6, 264);
            this.buttonSelectOneRow.Name = "buttonSelectOneRow";
            this.buttonSelectOneRow.Size = new System.Drawing.Size(298, 23);
            this.buttonSelectOneRow.TabIndex = 10;
            this.buttonSelectOneRow.Text = "9 - Select One Row";
            this.buttonSelectOneRow.UseVisualStyleBackColor = true;
            this.buttonSelectOneRow.Click += new System.EventHandler(this.buttonSelectOneRow_Click);
            // 
            // buttonCloseConnection
            // 
            this.buttonCloseConnection.Location = new System.Drawing.Point(6, 322);
            this.buttonCloseConnection.Name = "buttonCloseConnection";
            this.buttonCloseConnection.Size = new System.Drawing.Size(298, 23);
            this.buttonCloseConnection.TabIndex = 11;
            this.buttonCloseConnection.Text = "11 - Close Connection";
            this.buttonCloseConnection.UseVisualStyleBackColor = true;
            this.buttonCloseConnection.Click += new System.EventHandler(this.buttonCloseConnection_Click);
            // 
            // buttonGetColumnMaxValue
            // 
            this.buttonGetColumnMaxValue.Location = new System.Drawing.Point(6, 293);
            this.buttonGetColumnMaxValue.Name = "buttonGetColumnMaxValue";
            this.buttonGetColumnMaxValue.Size = new System.Drawing.Size(298, 23);
            this.buttonGetColumnMaxValue.TabIndex = 12;
            this.buttonGetColumnMaxValue.Text = "10 - Get Column Max Value";
            this.buttonGetColumnMaxValue.UseVisualStyleBackColor = true;
            this.buttonGetColumnMaxValue.Click += new System.EventHandler(this.buttonGetColumnMaxValue_Click);
            // 
            // buttonActivateLogs
            // 
            this.buttonActivateLogs.Location = new System.Drawing.Point(107, 6);
            this.buttonActivateLogs.Name = "buttonActivateLogs";
            this.buttonActivateLogs.Size = new System.Drawing.Size(95, 23);
            this.buttonActivateLogs.TabIndex = 13;
            this.buttonActivateLogs.Text = "Activate Logs";
            this.buttonActivateLogs.UseVisualStyleBackColor = true;
            this.buttonActivateLogs.Click += new System.EventHandler(this.buttonActivateLogs_Click);
            // 
            // buttonDeactivateLogs
            // 
            this.buttonDeactivateLogs.Location = new System.Drawing.Point(208, 6);
            this.buttonDeactivateLogs.Name = "buttonDeactivateLogs";
            this.buttonDeactivateLogs.Size = new System.Drawing.Size(95, 23);
            this.buttonDeactivateLogs.TabIndex = 14;
            this.buttonDeactivateLogs.Text = "Deactivate Logs";
            this.buttonDeactivateLogs.UseVisualStyleBackColor = true;
            this.buttonDeactivateLogs.Click += new System.EventHandler(this.buttonDeactivateLogs_Click);
            // 
            // buttonGetKeyValueList
            // 
            this.buttonGetKeyValueList.Location = new System.Drawing.Point(6, 6);
            this.buttonGetKeyValueList.Name = "buttonGetKeyValueList";
            this.buttonGetKeyValueList.Size = new System.Drawing.Size(298, 23);
            this.buttonGetKeyValueList.TabIndex = 15;
            this.buttonGetKeyValueList.Text = "Get Key Value List";
            this.buttonGetKeyValueList.UseVisualStyleBackColor = true;
            this.buttonGetKeyValueList.Click += new System.EventHandler(this.buttonGetKeyValueList_Click);
            // 
            // buttonGetKeyValueString
            // 
            this.buttonGetKeyValueString.Location = new System.Drawing.Point(6, 35);
            this.buttonGetKeyValueString.Name = "buttonGetKeyValueString";
            this.buttonGetKeyValueString.Size = new System.Drawing.Size(298, 23);
            this.buttonGetKeyValueString.TabIndex = 16;
            this.buttonGetKeyValueString.Text = "Get Key Value String";
            this.buttonGetKeyValueString.UseVisualStyleBackColor = true;
            this.buttonGetKeyValueString.Click += new System.EventHandler(this.buttonGetKeyValueString_Click);
            // 
            // buttonGetTableName
            // 
            this.buttonGetTableName.Location = new System.Drawing.Point(6, 64);
            this.buttonGetTableName.Name = "buttonGetTableName";
            this.buttonGetTableName.Size = new System.Drawing.Size(298, 23);
            this.buttonGetTableName.TabIndex = 17;
            this.buttonGetTableName.Text = "Get Table Name";
            this.buttonGetTableName.UseVisualStyleBackColor = true;
            this.buttonGetTableName.Click += new System.EventHandler(this.buttonGetTableName_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSFSQLiteConnection);
            this.tabControl1.Controls.Add(this.tabPageSFSQLiteTool);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(626, 499);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPageSFSQLiteConnection
            // 
            this.tabPageSFSQLiteConnection.Controls.Add(this.buttonDropTable);
            this.tabPageSFSQLiteConnection.Controls.Add(this.buttonDeleteAll);
            this.tabPageSFSQLiteConnection.Controls.Add(this.buttonDeleteList);
            this.tabPageSFSQLiteConnection.Controls.Add(this.buttonUpdateList);
            this.tabPageSFSQLiteConnection.Controls.Add(this.button1);
            this.tabPageSFSQLiteConnection.Controls.Add(this.buttonDeactivateLogs);
            this.tabPageSFSQLiteConnection.Controls.Add(this.buttonInitApi);
            this.tabPageSFSQLiteConnection.Controls.Add(this.textBoxDbName);
            this.tabPageSFSQLiteConnection.Controls.Add(this.labelDbName);
            this.tabPageSFSQLiteConnection.Controls.Add(this.buttonCreateDb);
            this.tabPageSFSQLiteConnection.Controls.Add(this.buttonActivateLogs);
            this.tabPageSFSQLiteConnection.Controls.Add(this.buttonCreateTable);
            this.tabPageSFSQLiteConnection.Controls.Add(this.buttonGetColumnMaxValue);
            this.tabPageSFSQLiteConnection.Controls.Add(this.buttonGetRowsTotal);
            this.tabPageSFSQLiteConnection.Controls.Add(this.buttonCloseConnection);
            this.tabPageSFSQLiteConnection.Controls.Add(this.buttonInsertRow);
            this.tabPageSFSQLiteConnection.Controls.Add(this.buttonSelectOneRow);
            this.tabPageSFSQLiteConnection.Controls.Add(this.buttonUpdateRow);
            this.tabPageSFSQLiteConnection.Controls.Add(this.buttonSelectAllRows);
            this.tabPageSFSQLiteConnection.Controls.Add(this.buttonDeleteRow);
            this.tabPageSFSQLiteConnection.Location = new System.Drawing.Point(4, 22);
            this.tabPageSFSQLiteConnection.Name = "tabPageSFSQLiteConnection";
            this.tabPageSFSQLiteConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSFSQLiteConnection.Size = new System.Drawing.Size(618, 473);
            this.tabPageSFSQLiteConnection.TabIndex = 0;
            this.tabPageSFSQLiteConnection.Text = "SFSQLiteConnection";
            this.tabPageSFSQLiteConnection.UseVisualStyleBackColor = true;
            // 
            // buttonDropTable
            // 
            this.buttonDropTable.Location = new System.Drawing.Point(309, 177);
            this.buttonDropTable.Name = "buttonDropTable";
            this.buttonDropTable.Size = new System.Drawing.Size(298, 23);
            this.buttonDropTable.TabIndex = 19;
            this.buttonDropTable.Text = "16 - Drop Table";
            this.buttonDropTable.UseVisualStyleBackColor = true;
            this.buttonDropTable.Click += new System.EventHandler(this.buttonDropTable_Click);
            // 
            // buttonDeleteAll
            // 
            this.buttonDeleteAll.Location = new System.Drawing.Point(309, 148);
            this.buttonDeleteAll.Name = "buttonDeleteAll";
            this.buttonDeleteAll.Size = new System.Drawing.Size(298, 23);
            this.buttonDeleteAll.TabIndex = 18;
            this.buttonDeleteAll.Text = "15 - Delete All";
            this.buttonDeleteAll.UseVisualStyleBackColor = true;
            this.buttonDeleteAll.Click += new System.EventHandler(this.buttonDeleteAll_Click);
            // 
            // buttonDeleteList
            // 
            this.buttonDeleteList.Location = new System.Drawing.Point(309, 119);
            this.buttonDeleteList.Name = "buttonDeleteList";
            this.buttonDeleteList.Size = new System.Drawing.Size(298, 23);
            this.buttonDeleteList.TabIndex = 17;
            this.buttonDeleteList.Text = "14 - Delete List";
            this.buttonDeleteList.UseVisualStyleBackColor = true;
            this.buttonDeleteList.Click += new System.EventHandler(this.buttonDeleteList_Click);
            // 
            // buttonUpdateList
            // 
            this.buttonUpdateList.Location = new System.Drawing.Point(309, 90);
            this.buttonUpdateList.Name = "buttonUpdateList";
            this.buttonUpdateList.Size = new System.Drawing.Size(298, 23);
            this.buttonUpdateList.TabIndex = 16;
            this.buttonUpdateList.Text = "13 - Update List";
            this.buttonUpdateList.UseVisualStyleBackColor = true;
            this.buttonUpdateList.Click += new System.EventHandler(this.buttonUpdateList_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(309, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(298, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "12 - Insert List";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPageSFSQLiteTool
            // 
            this.tabPageSFSQLiteTool.Controls.Add(this.buttonGetKeyValueList);
            this.tabPageSFSQLiteTool.Controls.Add(this.buttonGetTableName);
            this.tabPageSFSQLiteTool.Controls.Add(this.buttonGetKeyValueString);
            this.tabPageSFSQLiteTool.Location = new System.Drawing.Point(4, 22);
            this.tabPageSFSQLiteTool.Name = "tabPageSFSQLiteTool";
            this.tabPageSFSQLiteTool.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSFSQLiteTool.Size = new System.Drawing.Size(618, 473);
            this.tabPageSFSQLiteTool.TabIndex = 1;
            this.tabPageSFSQLiteTool.Text = "SFSQLiteTool";
            this.tabPageSFSQLiteTool.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 520);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "SFSQLiteApi Test App";
            this.tabControl1.ResumeLayout(false);
            this.tabPageSFSQLiteConnection.ResumeLayout(false);
            this.tabPageSFSQLiteConnection.PerformLayout();
            this.tabPageSFSQLiteTool.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonInitApi;
        private System.Windows.Forms.TextBox textBoxDbName;
        private System.Windows.Forms.Label labelDbName;
        private System.Windows.Forms.Button buttonCreateDb;
        private System.Windows.Forms.Button buttonCreateTable;
        private System.Windows.Forms.Button buttonGetRowsTotal;
        private System.Windows.Forms.Button buttonInsertRow;
        private System.Windows.Forms.Button buttonUpdateRow;
        private System.Windows.Forms.Button buttonDeleteRow;
        private System.Windows.Forms.Button buttonSelectAllRows;
        private System.Windows.Forms.Button buttonSelectOneRow;
        private System.Windows.Forms.Button buttonCloseConnection;
        private System.Windows.Forms.Button buttonGetColumnMaxValue;
        private System.Windows.Forms.Button buttonActivateLogs;
        private System.Windows.Forms.Button buttonDeactivateLogs;
        private System.Windows.Forms.Button buttonGetKeyValueList;
        private System.Windows.Forms.Button buttonGetKeyValueString;
        private System.Windows.Forms.Button buttonGetTableName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSFSQLiteConnection;
        private System.Windows.Forms.TabPage tabPageSFSQLiteTool;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonUpdateList;
        private System.Windows.Forms.Button buttonDeleteList;
        private System.Windows.Forms.Button buttonDeleteAll;
        private System.Windows.Forms.Button buttonDropTable;
    }
}

