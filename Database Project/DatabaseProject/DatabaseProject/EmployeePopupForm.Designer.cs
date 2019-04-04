namespace DatabaseProject
{
    partial class EmployeePopupForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.firstTextBox = new System.Windows.Forms.TextBox();
            this.lastTextBox = new System.Windows.Forms.TextBox();
            this.titleComboBox = new System.Windows.Forms.ComboBox();
            this.createEmpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Worker Title:";
            // 
            // firstTextBox
            // 
            this.firstTextBox.Location = new System.Drawing.Point(79, 10);
            this.firstTextBox.Name = "firstTextBox";
            this.firstTextBox.Size = new System.Drawing.Size(177, 20);
            this.firstTextBox.TabIndex = 3;
            // 
            // lastTextBox
            // 
            this.lastTextBox.Location = new System.Drawing.Point(79, 32);
            this.lastTextBox.Name = "lastTextBox";
            this.lastTextBox.Size = new System.Drawing.Size(177, 20);
            this.lastTextBox.TabIndex = 4;
            // 
            // titleComboBox
            // 
            this.titleComboBox.FormattingEnabled = true;
            this.titleComboBox.Location = new System.Drawing.Point(79, 54);
            this.titleComboBox.Name = "titleComboBox";
            this.titleComboBox.Size = new System.Drawing.Size(177, 21);
            this.titleComboBox.TabIndex = 5;
            // 
            // createEmpButton
            // 
            this.createEmpButton.Location = new System.Drawing.Point(146, 81);
            this.createEmpButton.Name = "createEmpButton";
            this.createEmpButton.Size = new System.Drawing.Size(110, 23);
            this.createEmpButton.TabIndex = 6;
            this.createEmpButton.Text = "Create Employee";
            this.createEmpButton.UseVisualStyleBackColor = true;
            this.createEmpButton.Click += new System.EventHandler(this.createEmpButton_Click);
            // 
            // EmployeePopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 121);
            this.Controls.Add(this.createEmpButton);
            this.Controls.Add(this.titleComboBox);
            this.Controls.Add(this.lastTextBox);
            this.Controls.Add(this.firstTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EmployeePopupForm";
            this.Text = "Add New Employee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox firstTextBox;
        private System.Windows.Forms.TextBox lastTextBox;
        private System.Windows.Forms.ComboBox titleComboBox;
        private System.Windows.Forms.Button createEmpButton;
    }
}