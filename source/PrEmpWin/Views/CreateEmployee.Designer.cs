namespace PrEmpWin.Views
{
    partial class CreateEmployee
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.editPanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkDatabase = new System.Windows.Forms.CheckBox();
            this.checkFile = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioHourlyPayment = new System.Windows.Forms.RadioButton();
            this.radioFixedPayment = new System.Windows.Forms.RadioButton();
            this.lblPayment = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.editPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(10, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(90, 10);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(120, 20);
            this.txtName.TabIndex = 2;
            // 
            // txtPayment
            // 
            this.txtPayment.Location = new System.Drawing.Point(90, 40);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(120, 20);
            this.txtPayment.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(262, 248);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // editPanel
            // 
            this.editPanel.Controls.Add(this.richTextBox1);
            this.editPanel.Controls.Add(this.groupBox2);
            this.editPanel.Controls.Add(this.groupBox1);
            this.editPanel.Controls.Add(this.btnSave);
            this.editPanel.Controls.Add(this.lblPayment);
            this.editPanel.Controls.Add(this.txtPayment);
            this.editPanel.Controls.Add(this.txtName);
            this.editPanel.Controls.Add(this.lblName);
            this.editPanel.Location = new System.Drawing.Point(12, 12);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(353, 287);
            this.editPanel.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkDatabase);
            this.groupBox2.Controls.Add(this.checkFile);
            this.groupBox2.Location = new System.Drawing.Point(10, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(110, 90);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Write to";
            // 
            // checkDatabase
            // 
            this.checkDatabase.Location = new System.Drawing.Point(6, 19);
            this.checkDatabase.Name = "checkDatabase";
            this.checkDatabase.Size = new System.Drawing.Size(72, 17);
            this.checkDatabase.TabIndex = 13;
            this.checkDatabase.Text = "Database";
            this.checkDatabase.UseVisualStyleBackColor = true;
            // 
            // checkFile
            // 
            this.checkFile.Location = new System.Drawing.Point(6, 42);
            this.checkFile.Name = "checkFile";
            this.checkFile.Size = new System.Drawing.Size(42, 17);
            this.checkFile.TabIndex = 14;
            this.checkFile.Text = "File";
            this.checkFile.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioHourlyPayment);
            this.groupBox1.Controls.Add(this.radioFixedPayment);
            this.groupBox1.Location = new System.Drawing.Point(10, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(110, 90);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment type";
            // 
            // radioHourlyPayment
            // 
            this.radioHourlyPayment.Location = new System.Drawing.Point(6, 42);
            this.radioHourlyPayment.Name = "radioHourlyPayment";
            this.radioHourlyPayment.Size = new System.Drawing.Size(98, 17);
            this.radioHourlyPayment.TabIndex = 13;
            this.radioHourlyPayment.TabStop = true;
            this.radioHourlyPayment.Text = "Hourly payment";
            this.radioHourlyPayment.UseVisualStyleBackColor = true;
            // 
            // radioFixedPayment
            // 
            this.radioFixedPayment.Location = new System.Drawing.Point(6, 19);
            this.radioFixedPayment.Name = "radioFixedPayment";
            this.radioFixedPayment.Size = new System.Drawing.Size(93, 17);
            this.radioFixedPayment.TabIndex = 12;
            this.radioFixedPayment.TabStop = true;
            this.radioFixedPayment.Text = "Fixed payment";
            this.radioFixedPayment.UseVisualStyleBackColor = true;
            // 
            // lblPayment
            // 
            this.lblPayment.Location = new System.Drawing.Point(10, 40);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(51, 13);
            this.lblPayment.TabIndex = 9;
            this.lblPayment.Text = "Payment:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(139, 88);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(198, 122);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // CreateEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 312);
            this.Controls.Add(this.editPanel);
            this.Name = "CreateEmployee";
            this.Text = "CreateEmployee";
            this.editPanel.ResumeLayout(false);
            this.editPanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel editPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioHourlyPayment;
        private System.Windows.Forms.RadioButton radioFixedPayment;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkDatabase;
        private System.Windows.Forms.CheckBox checkFile;
        private System.Windows.Forms.RichTextBox richTextBox1;

    }
}