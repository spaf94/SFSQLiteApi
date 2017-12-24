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
            this.SuspendLayout();
            // 
            // buttonInitApi
            // 
            this.buttonInitApi.Location = new System.Drawing.Point(13, 13);
            this.buttonInitApi.Name = "buttonInitApi";
            this.buttonInitApi.Size = new System.Drawing.Size(267, 23);
            this.buttonInitApi.TabIndex = 0;
            this.buttonInitApi.Text = "1 - Initialize Api";
            this.buttonInitApi.UseVisualStyleBackColor = true;
            this.buttonInitApi.Click += new System.EventHandler(this.buttonInitApi_Click);
            // 
            // textBoxDbName
            // 
            this.textBoxDbName.Location = new System.Drawing.Point(102, 43);
            this.textBoxDbName.Name = "textBoxDbName";
            this.textBoxDbName.Size = new System.Drawing.Size(178, 20);
            this.textBoxDbName.TabIndex = 1;
            this.textBoxDbName.Text = "HelloDb";
            // 
            // labelDbName
            // 
            this.labelDbName.AutoSize = true;
            this.labelDbName.Location = new System.Drawing.Point(12, 46);
            this.labelDbName.Name = "labelDbName";
            this.labelDbName.Size = new System.Drawing.Size(84, 13);
            this.labelDbName.TabIndex = 2;
            this.labelDbName.Text = "Database Name";
            // 
            // buttonCreateDb
            // 
            this.buttonCreateDb.Location = new System.Drawing.Point(12, 69);
            this.buttonCreateDb.Name = "buttonCreateDb";
            this.buttonCreateDb.Size = new System.Drawing.Size(267, 23);
            this.buttonCreateDb.TabIndex = 3;
            this.buttonCreateDb.Text = "2 - Create Database and Open Connection";
            this.buttonCreateDb.UseVisualStyleBackColor = true;
            this.buttonCreateDb.Click += new System.EventHandler(this.buttonCreateDb_Click);
            // 
            // buttonCreateTable
            // 
            this.buttonCreateTable.Location = new System.Drawing.Point(12, 98);
            this.buttonCreateTable.Name = "buttonCreateTable";
            this.buttonCreateTable.Size = new System.Drawing.Size(267, 23);
            this.buttonCreateTable.TabIndex = 4;
            this.buttonCreateTable.Text = "3 - Create Table";
            this.buttonCreateTable.UseVisualStyleBackColor = true;
            this.buttonCreateTable.Click += new System.EventHandler(this.buttonCreateTable_Click);
            // 
            // buttonGetRowsTotal
            // 
            this.buttonGetRowsTotal.Location = new System.Drawing.Point(12, 127);
            this.buttonGetRowsTotal.Name = "buttonGetRowsTotal";
            this.buttonGetRowsTotal.Size = new System.Drawing.Size(267, 23);
            this.buttonGetRowsTotal.TabIndex = 5;
            this.buttonGetRowsTotal.Text = "4 - Get Rows Total";
            this.buttonGetRowsTotal.UseVisualStyleBackColor = true;
            this.buttonGetRowsTotal.Click += new System.EventHandler(this.buttonGetRowsTotal_Click);
            // 
            // buttonInsertRow
            // 
            this.buttonInsertRow.Location = new System.Drawing.Point(13, 156);
            this.buttonInsertRow.Name = "buttonInsertRow";
            this.buttonInsertRow.Size = new System.Drawing.Size(267, 23);
            this.buttonInsertRow.TabIndex = 6;
            this.buttonInsertRow.Text = "5 - Insert Row";
            this.buttonInsertRow.UseVisualStyleBackColor = true;
            this.buttonInsertRow.Click += new System.EventHandler(this.buttonInsertRow_Click);
            // 
            // buttonUpdateRow
            // 
            this.buttonUpdateRow.Location = new System.Drawing.Point(13, 185);
            this.buttonUpdateRow.Name = "buttonUpdateRow";
            this.buttonUpdateRow.Size = new System.Drawing.Size(267, 23);
            this.buttonUpdateRow.TabIndex = 7;
            this.buttonUpdateRow.Text = "6 - Update Row";
            this.buttonUpdateRow.UseVisualStyleBackColor = true;
            this.buttonUpdateRow.Click += new System.EventHandler(this.buttonUpdateRow_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.buttonUpdateRow);
            this.Controls.Add(this.buttonInsertRow);
            this.Controls.Add(this.buttonGetRowsTotal);
            this.Controls.Add(this.buttonCreateTable);
            this.Controls.Add(this.buttonCreateDb);
            this.Controls.Add(this.labelDbName);
            this.Controls.Add(this.textBoxDbName);
            this.Controls.Add(this.buttonInitApi);
            this.Name = "MainForm";
            this.Text = "SFSQLiteApi Test App";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

