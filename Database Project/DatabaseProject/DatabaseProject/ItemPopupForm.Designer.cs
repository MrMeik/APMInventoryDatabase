namespace DatabaseProject
{
    partial class ItemPopupForm
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
            this.itemNameTextBox = new System.Windows.Forms.TextBox();
            this.itemQuantityTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.itemOptimalTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.itemColorTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.itemLocationComboBox = new System.Windows.Forms.ComboBox();
            this.itemTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.itemDescTextBox = new System.Windows.Forms.TextBox();
            this.generateItemButton = new System.Windows.Forms.Button();
            this.itemExpDateTime = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Name:";
            // 
            // itemNameTextBox
            // 
            this.itemNameTextBox.Location = new System.Drawing.Point(80, 6);
            this.itemNameTextBox.MaxLength = 50;
            this.itemNameTextBox.Name = "itemNameTextBox";
            this.itemNameTextBox.Size = new System.Drawing.Size(271, 20);
            this.itemNameTextBox.TabIndex = 1;
            // 
            // itemQuantityTextBox
            // 
            this.itemQuantityTextBox.Location = new System.Drawing.Point(91, 32);
            this.itemQuantityTextBox.MaxLength = 4;
            this.itemQuantityTextBox.Name = "itemQuantityTextBox";
            this.itemQuantityTextBox.Size = new System.Drawing.Size(56, 20);
            this.itemQuantityTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Item Quantity:";
            // 
            // itemOptimalTextBox
            // 
            this.itemOptimalTextBox.Location = new System.Drawing.Point(295, 35);
            this.itemOptimalTextBox.MaxLength = 4;
            this.itemOptimalTextBox.Name = "itemOptimalTextBox";
            this.itemOptimalTextBox.Size = new System.Drawing.Size(56, 20);
            this.itemOptimalTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Restock to Amount:";
            // 
            // itemColorTextBox
            // 
            this.itemColorTextBox.Location = new System.Drawing.Point(76, 59);
            this.itemColorTextBox.MaxLength = 15;
            this.itemColorTextBox.Name = "itemColorTextBox";
            this.itemColorTextBox.Size = new System.Drawing.Size(56, 20);
            this.itemColorTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Item Color:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(150, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Location:";
            // 
            // itemLocationComboBox
            // 
            this.itemLocationComboBox.FormattingEnabled = true;
            this.itemLocationComboBox.Location = new System.Drawing.Point(207, 61);
            this.itemLocationComboBox.Name = "itemLocationComboBox";
            this.itemLocationComboBox.Size = new System.Drawing.Size(143, 21);
            this.itemLocationComboBox.TabIndex = 9;
            // 
            // itemTypeComboBox
            // 
            this.itemTypeComboBox.FormattingEnabled = true;
            this.itemTypeComboBox.Location = new System.Drawing.Point(76, 88);
            this.itemTypeComboBox.Name = "itemTypeComboBox";
            this.itemTypeComboBox.Size = new System.Drawing.Size(274, 21);
            this.itemTypeComboBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Item Type:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Description:";
            // 
            // itemDescTextBox
            // 
            this.itemDescTextBox.Location = new System.Drawing.Point(91, 143);
            this.itemDescTextBox.MaxLength = 100;
            this.itemDescTextBox.Multiline = true;
            this.itemDescTextBox.Name = "itemDescTextBox";
            this.itemDescTextBox.Size = new System.Drawing.Size(259, 82);
            this.itemDescTextBox.TabIndex = 13;
            // 
            // generateItemButton
            // 
            this.generateItemButton.Location = new System.Drawing.Point(12, 162);
            this.generateItemButton.Name = "generateItemButton";
            this.generateItemButton.Size = new System.Drawing.Size(73, 58);
            this.generateItemButton.TabIndex = 14;
            this.generateItemButton.Text = "Create Item";
            this.generateItemButton.UseVisualStyleBackColor = true;
            this.generateItemButton.Click += new System.EventHandler(this.generateItemButton_Click);
            // 
            // itemExpDateTime
            // 
            this.itemExpDateTime.Location = new System.Drawing.Point(151, 115);
            this.itemExpDateTime.Name = "itemExpDateTime";
            this.itemExpDateTime.Size = new System.Drawing.Size(200, 20);
            this.itemExpDateTime.TabIndex = 15;
            // 
            // ItemPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 232);
            this.Controls.Add(this.itemExpDateTime);
            this.Controls.Add(this.generateItemButton);
            this.Controls.Add(this.itemDescTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.itemTypeComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.itemLocationComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.itemColorTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.itemOptimalTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.itemQuantityTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.itemNameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "ItemPopupForm";
            this.Text = "Add New Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox itemNameTextBox;
        private System.Windows.Forms.TextBox itemQuantityTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox itemOptimalTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox itemColorTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox itemLocationComboBox;
        private System.Windows.Forms.ComboBox itemTypeComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox itemDescTextBox;
        private System.Windows.Forms.Button generateItemButton;
        private System.Windows.Forms.DateTimePicker itemExpDateTime;
    }
}