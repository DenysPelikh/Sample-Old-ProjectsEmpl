using System;

namespace PrEmpWin.Views
{
    partial class EmployeeForm
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
            this.employeesGrid = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonthlyAverageSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckFromDatabase = new System.Windows.Forms.CheckBox();
            this.CheckFromFile = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.checkFirstFive = new System.Windows.Forms.CheckBox();
            this.checkLastThree = new System.Windows.Forms.CheckBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.employeesGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // employeesGrid
            // 
            this.employeesGrid.AllowUserToAddRows = false;
            this.employeesGrid.AllowUserToDeleteRows = false;
            this.employeesGrid.ColumnHeadersHeight = 30;
            this.employeesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.EmployeeName,
            this.MonthlyAverageSalary,
            this.From});
            this.employeesGrid.Location = new System.Drawing.Point(12, 12);
            this.employeesGrid.Name = "employeesGrid";
            this.employeesGrid.ReadOnly = true;
            this.employeesGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.employeesGrid.Size = new System.Drawing.Size(409, 250);
            this.employeesGrid.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 20;
            // 
            // EmployeeName
            // 
            this.EmployeeName.DataPropertyName = "EmployeeName";
            this.EmployeeName.HeaderText = "EmployeeName";
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.ReadOnly = true;
            // 
            // MonthlyAverageSalary
            // 
            this.MonthlyAverageSalary.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MonthlyAverageSalary.DataPropertyName = "MonthlyAverageSalary";
            this.MonthlyAverageSalary.HeaderText = "MonthlyAverageSalary";
            this.MonthlyAverageSalary.Name = "MonthlyAverageSalary";
            this.MonthlyAverageSalary.ReadOnly = true;
            this.MonthlyAverageSalary.Width = 138;
            // 
            // From
            // 
            this.From.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.From.DataPropertyName = "From";
            this.From.HeaderText = "From";
            this.From.Name = "From";
            this.From.ReadOnly = true;
            // 
            // CheckFromDatabase
            // 
            this.CheckFromDatabase.AutoSize = true;
            this.CheckFromDatabase.Location = new System.Drawing.Point(6, 19);
            this.CheckFromDatabase.Name = "CheckFromDatabase";
            this.CheckFromDatabase.Size = new System.Drawing.Size(91, 17);
            this.CheckFromDatabase.TabIndex = 5;
            this.CheckFromDatabase.Text = "Load from DB";
            this.CheckFromDatabase.UseVisualStyleBackColor = true;
            this.CheckFromDatabase.CheckedChanged += new System.EventHandler(this.CheckFromDatabase_CheckedChanged);
            // 
            // CheckFromFile
            // 
            this.CheckFromFile.AutoSize = true;
            this.CheckFromFile.Location = new System.Drawing.Point(6, 42);
            this.CheckFromFile.Name = "CheckFromFile";
            this.CheckFromFile.Size = new System.Drawing.Size(89, 17);
            this.CheckFromFile.TabIndex = 6;
            this.CheckFromFile.Text = "Load from file";
            this.CheckFromFile.UseVisualStyleBackColor = true;
            this.CheckFromFile.CheckedChanged += new System.EventHandler(this.CheckFromFile_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CheckFromFile);
            this.groupBox1.Controls.Add(this.CheckFromDatabase);
            this.groupBox1.Location = new System.Drawing.Point(12, 271);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(106, 73);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(346, 284);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 8;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // checkFirstFive
            // 
            this.checkFirstFive.AutoSize = true;
            this.checkFirstFive.Location = new System.Drawing.Point(134, 284);
            this.checkFirstFive.Name = "checkFirstFive";
            this.checkFirstFive.Size = new System.Drawing.Size(118, 17);
            this.checkFirstFive.TabIndex = 9;
            this.checkFirstFive.Text = "First five employees";
            this.checkFirstFive.UseVisualStyleBackColor = true;
            this.checkFirstFive.CheckedChanged += new System.EventHandler(this.checkFirstFive_CheckedChanged);
            // 
            // checkLastThree
            // 
            this.checkLastThree.AutoSize = true;
            this.checkLastThree.Location = new System.Drawing.Point(134, 307);
            this.checkLastThree.Name = "checkLastThree";
            this.checkLastThree.Size = new System.Drawing.Size(73, 17);
            this.checkLastThree.TabIndex = 10;
            this.checkLastThree.Text = "Last three";
            this.checkLastThree.UseVisualStyleBackColor = true;
            this.checkLastThree.CheckedChanged += new System.EventHandler(this.checkLastThree_CheckedChanged);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(132, 339);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 11;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 392);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.checkLastThree);
            this.Controls.Add(this.checkFirstFive);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.employeesGrid);
            this.Name = "EmployeeForm";
            this.Text = "Employee";
            ((System.ComponentModel.ISupportInitialize)(this.employeesGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView employeesGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonthlyAverageSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn From;
        private System.Windows.Forms.CheckBox CheckFromDatabase;
        private System.Windows.Forms.CheckBox CheckFromFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.CheckBox checkFirstFive;
        private System.Windows.Forms.CheckBox checkLastThree;
        private System.Windows.Forms.Button buttonDelete;
    }
}