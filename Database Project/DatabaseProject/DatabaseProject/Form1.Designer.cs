namespace DatabaseProject
{
    partial class APMInventory
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.reserveTab = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.empNameComboBox = new System.Windows.Forms.ComboBox();
            this.removefromEventButton = new System.Windows.Forms.Button();
            this.addtoEventButton = new System.Windows.Forms.Button();
            this.itemSearchTextBox = new System.Windows.Forms.TextBox();
            this.itemSearchButton = new System.Windows.Forms.Button();
            this.reserveDataGridView = new System.Windows.Forms.DataGridView();
            this.submitButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.eventListBox = new System.Windows.Forms.ListBox();
            this.reserveDateCalendar = new System.Windows.Forms.MonthCalendar();
            this.eventTab = new System.Windows.Forms.TabPage();
            this.amountReturnedTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.partialResButton = new System.Windows.Forms.Button();
            this.fullResButton = new System.Windows.Forms.Button();
            this.byDateRadio = new System.Windows.Forms.RadioButton();
            this.byPersonRadio = new System.Windows.Forms.RadioButton();
            this.searchButton = new System.Windows.Forms.Button();
            this.lastTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.firstTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.deleteRequestButton = new System.Windows.Forms.Button();
            this.manageDataGridView = new System.Windows.Forms.DataGridView();
            this.manageDateCalendar = new System.Windows.Forms.MonthCalendar();
            this.adminTab = new System.Windows.Forms.TabPage();
            this.empPositionComboBox = new System.Windows.Forms.ComboBox();
            this.loadTableButton = new System.Windows.Forms.Button();
            this.empTableButton = new System.Windows.Forms.RadioButton();
            this.itemTableRadio = new System.Windows.Forms.RadioButton();
            this.changeEmpPosButton = new System.Windows.Forms.Button();
            this.removeEmpButton = new System.Windows.Forms.Button();
            this.addNewEmpButton = new System.Windows.Forms.Button();
            this.restockTextBox = new System.Windows.Forms.TextBox();
            this.restockButton = new System.Windows.Forms.Button();
            this.removeItemButton = new System.Windows.Forms.Button();
            this.addNewItemButton = new System.Windows.Forms.Button();
            this.adminDataGridView = new System.Windows.Forms.DataGridView();
            this.tabControl.SuspendLayout();
            this.reserveTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reserveDataGridView)).BeginInit();
            this.eventTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.manageDataGridView)).BeginInit();
            this.adminTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.reserveTab);
            this.tabControl.Controls.Add(this.eventTab);
            this.tabControl.Controls.Add(this.adminTab);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(813, 567);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabIndexChanged_Click);
            // 
            // reserveTab
            // 
            this.reserveTab.Controls.Add(this.splitContainer2);
            this.reserveTab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.reserveTab.Location = new System.Drawing.Point(4, 22);
            this.reserveTab.Name = "reserveTab";
            this.reserveTab.Padding = new System.Windows.Forms.Padding(3);
            this.reserveTab.Size = new System.Drawing.Size(805, 541);
            this.reserveTab.TabIndex = 0;
            this.reserveTab.Text = "Reserve Items";
            this.reserveTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.quantityTextBox);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.empNameComboBox);
            this.splitContainer2.Panel1.Controls.Add(this.removefromEventButton);
            this.splitContainer2.Panel1.Controls.Add(this.addtoEventButton);
            this.splitContainer2.Panel1.Controls.Add(this.itemSearchTextBox);
            this.splitContainer2.Panel1.Controls.Add(this.itemSearchButton);
            this.splitContainer2.Panel1.Controls.Add(this.reserveDataGridView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.submitButton);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.eventListBox);
            this.splitContainer2.Panel2.Controls.Add(this.reserveDateCalendar);
            this.splitContainer2.Size = new System.Drawing.Size(799, 535);
            this.splitContainer2.SplitterDistance = 546;
            this.splitContainer2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(432, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Quantity:";
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(482, 5);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(45, 20);
            this.quantityTextBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Employee Name:";
            // 
            // empNameComboBox
            // 
            this.empNameComboBox.FormattingEnabled = true;
            this.empNameComboBox.Location = new System.Drawing.Point(283, 5);
            this.empNameComboBox.Name = "empNameComboBox";
            this.empNameComboBox.Size = new System.Drawing.Size(141, 21);
            this.empNameComboBox.TabIndex = 8;
            // 
            // removefromEventButton
            // 
            this.removefromEventButton.Location = new System.Drawing.Point(505, 95);
            this.removefromEventButton.Name = "removefromEventButton";
            this.removefromEventButton.Size = new System.Drawing.Size(22, 22);
            this.removefromEventButton.TabIndex = 7;
            this.removefromEventButton.Text = "<";
            this.removefromEventButton.UseVisualStyleBackColor = true;
            this.removefromEventButton.Click += new System.EventHandler(this.removefromEventButton_Click);
            // 
            // addtoEventButton
            // 
            this.addtoEventButton.Location = new System.Drawing.Point(505, 47);
            this.addtoEventButton.Name = "addtoEventButton";
            this.addtoEventButton.Size = new System.Drawing.Size(22, 22);
            this.addtoEventButton.TabIndex = 6;
            this.addtoEventButton.Text = ">";
            this.addtoEventButton.UseVisualStyleBackColor = true;
            this.addtoEventButton.Click += new System.EventHandler(this.addtoEventButton_Click);
            // 
            // itemSearchTextBox
            // 
            this.itemSearchTextBox.Location = new System.Drawing.Point(3, 4);
            this.itemSearchTextBox.Name = "itemSearchTextBox";
            this.itemSearchTextBox.Size = new System.Drawing.Size(100, 20);
            this.itemSearchTextBox.TabIndex = 3;
            // 
            // itemSearchButton
            // 
            this.itemSearchButton.Location = new System.Drawing.Point(109, 4);
            this.itemSearchButton.Name = "itemSearchButton";
            this.itemSearchButton.Size = new System.Drawing.Size(75, 20);
            this.itemSearchButton.TabIndex = 4;
            this.itemSearchButton.Text = "Search";
            this.itemSearchButton.UseVisualStyleBackColor = true;
            this.itemSearchButton.Click += new System.EventHandler(this.itemSearchButton_Click);
            // 
            // reserveDataGridView
            // 
            this.reserveDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reserveDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.reserveDataGridView.Location = new System.Drawing.Point(3, 30);
            this.reserveDataGridView.Name = "reserveDataGridView";
            this.reserveDataGridView.Size = new System.Drawing.Size(481, 500);
            this.reserveDataGridView.TabIndex = 5;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(68, 327);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(102, 23);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = "Submit Event";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Reserve for Event";
            // 
            // eventListBox
            // 
            this.eventListBox.FormattingEnabled = true;
            this.eventListBox.Location = new System.Drawing.Point(9, 29);
            this.eventListBox.Name = "eventListBox";
            this.eventListBox.Size = new System.Drawing.Size(227, 290);
            this.eventListBox.TabIndex = 2;
            // 
            // reserveDateCalendar
            // 
            this.reserveDateCalendar.Location = new System.Drawing.Point(9, 362);
            this.reserveDateCalendar.Name = "reserveDateCalendar";
            this.reserveDateCalendar.TabIndex = 1;
            // 
            // eventTab
            // 
            this.eventTab.Controls.Add(this.amountReturnedTextBox);
            this.eventTab.Controls.Add(this.label6);
            this.eventTab.Controls.Add(this.partialResButton);
            this.eventTab.Controls.Add(this.fullResButton);
            this.eventTab.Controls.Add(this.byDateRadio);
            this.eventTab.Controls.Add(this.byPersonRadio);
            this.eventTab.Controls.Add(this.searchButton);
            this.eventTab.Controls.Add(this.lastTextBox);
            this.eventTab.Controls.Add(this.label5);
            this.eventTab.Controls.Add(this.firstTextBox);
            this.eventTab.Controls.Add(this.label4);
            this.eventTab.Controls.Add(this.deleteRequestButton);
            this.eventTab.Controls.Add(this.manageDataGridView);
            this.eventTab.Controls.Add(this.manageDateCalendar);
            this.eventTab.Location = new System.Drawing.Point(4, 22);
            this.eventTab.Name = "eventTab";
            this.eventTab.Padding = new System.Windows.Forms.Padding(3);
            this.eventTab.Size = new System.Drawing.Size(805, 541);
            this.eventTab.TabIndex = 1;
            this.eventTab.Text = "Manage Events";
            this.eventTab.UseVisualStyleBackColor = true;
            // 
            // amountReturnedTextBox
            // 
            this.amountReturnedTextBox.Location = new System.Drawing.Point(96, 379);
            this.amountReturnedTextBox.Name = "amountReturnedTextBox";
            this.amountReturnedTextBox.Size = new System.Drawing.Size(48, 20);
            this.amountReturnedTextBox.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 363);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Amount returned:";
            // 
            // partialResButton
            // 
            this.partialResButton.Location = new System.Drawing.Point(64, 337);
            this.partialResButton.Name = "partialResButton";
            this.partialResButton.Size = new System.Drawing.Size(111, 23);
            this.partialResButton.TabIndex = 11;
            this.partialResButton.Text = "Partial Reservation";
            this.partialResButton.UseVisualStyleBackColor = true;
            this.partialResButton.Click += new System.EventHandler(this.partialResButton_Click);
            // 
            // fullResButton
            // 
            this.fullResButton.Location = new System.Drawing.Point(64, 308);
            this.fullResButton.Name = "fullResButton";
            this.fullResButton.Size = new System.Drawing.Size(111, 23);
            this.fullResButton.TabIndex = 10;
            this.fullResButton.Text = "Full Reservation";
            this.fullResButton.UseVisualStyleBackColor = true;
            this.fullResButton.Click += new System.EventHandler(this.fullResButton_Click);
            // 
            // byDateRadio
            // 
            this.byDateRadio.AutoSize = true;
            this.byDateRadio.Location = new System.Drawing.Point(12, 256);
            this.byDateRadio.Name = "byDateRadio";
            this.byDateRadio.Size = new System.Drawing.Size(110, 17);
            this.byDateRadio.TabIndex = 9;
            this.byDateRadio.Text = "Search After Date";
            this.byDateRadio.UseVisualStyleBackColor = true;
            // 
            // byPersonRadio
            // 
            this.byPersonRadio.AutoSize = true;
            this.byPersonRadio.Checked = true;
            this.byPersonRadio.Location = new System.Drawing.Point(12, 232);
            this.byPersonRadio.Name = "byPersonRadio";
            this.byPersonRadio.Size = new System.Drawing.Size(110, 17);
            this.byPersonRadio.TabIndex = 8;
            this.byPersonRadio.TabStop = true;
            this.byPersonRadio.Text = "Search By Person";
            this.byPersonRadio.UseVisualStyleBackColor = true;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(139, 229);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(100, 44);
            this.searchButton.TabIndex = 7;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // lastTextBox
            // 
            this.lastTextBox.Location = new System.Drawing.Point(44, 35);
            this.lastTextBox.Name = "lastTextBox";
            this.lastTextBox.Size = new System.Drawing.Size(100, 20);
            this.lastTextBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Last:";
            // 
            // firstTextBox
            // 
            this.firstTextBox.Location = new System.Drawing.Point(44, 9);
            this.firstTextBox.Name = "firstTextBox";
            this.firstTextBox.Size = new System.Drawing.Size(100, 20);
            this.firstTextBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "First:";
            // 
            // deleteRequestButton
            // 
            this.deleteRequestButton.Location = new System.Drawing.Point(64, 512);
            this.deleteRequestButton.Name = "deleteRequestButton";
            this.deleteRequestButton.Size = new System.Drawing.Size(111, 23);
            this.deleteRequestButton.TabIndex = 2;
            this.deleteRequestButton.Text = "Delete Request";
            this.deleteRequestButton.UseVisualStyleBackColor = true;
            this.deleteRequestButton.Click += new System.EventHandler(this.deleteRequestButton_Click);
            // 
            // manageDataGridView
            // 
            this.manageDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.manageDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.manageDataGridView.Location = new System.Drawing.Point(251, 6);
            this.manageDataGridView.Name = "manageDataGridView";
            this.manageDataGridView.Size = new System.Drawing.Size(548, 529);
            this.manageDataGridView.TabIndex = 1;
            // 
            // manageDateCalendar
            // 
            this.manageDateCalendar.Location = new System.Drawing.Point(12, 60);
            this.manageDateCalendar.Name = "manageDateCalendar";
            this.manageDateCalendar.TabIndex = 0;
            // 
            // adminTab
            // 
            this.adminTab.Controls.Add(this.empPositionComboBox);
            this.adminTab.Controls.Add(this.loadTableButton);
            this.adminTab.Controls.Add(this.empTableButton);
            this.adminTab.Controls.Add(this.itemTableRadio);
            this.adminTab.Controls.Add(this.changeEmpPosButton);
            this.adminTab.Controls.Add(this.removeEmpButton);
            this.adminTab.Controls.Add(this.addNewEmpButton);
            this.adminTab.Controls.Add(this.restockTextBox);
            this.adminTab.Controls.Add(this.restockButton);
            this.adminTab.Controls.Add(this.removeItemButton);
            this.adminTab.Controls.Add(this.addNewItemButton);
            this.adminTab.Controls.Add(this.adminDataGridView);
            this.adminTab.Location = new System.Drawing.Point(4, 22);
            this.adminTab.Name = "adminTab";
            this.adminTab.Padding = new System.Windows.Forms.Padding(3);
            this.adminTab.Size = new System.Drawing.Size(805, 541);
            this.adminTab.TabIndex = 2;
            this.adminTab.Text = "Admin Controls";
            this.adminTab.UseVisualStyleBackColor = true;
            // 
            // empPositionComboBox
            // 
            this.empPositionComboBox.FormattingEnabled = true;
            this.empPositionComboBox.Location = new System.Drawing.Point(696, 167);
            this.empPositionComboBox.Name = "empPositionComboBox";
            this.empPositionComboBox.Size = new System.Drawing.Size(106, 21);
            this.empPositionComboBox.TabIndex = 13;
            this.empPositionComboBox.Visible = false;
            // 
            // loadTableButton
            // 
            this.loadTableButton.Location = new System.Drawing.Point(695, 304);
            this.loadTableButton.Name = "loadTableButton";
            this.loadTableButton.Size = new System.Drawing.Size(107, 23);
            this.loadTableButton.TabIndex = 12;
            this.loadTableButton.Text = "Load Table";
            this.loadTableButton.UseVisualStyleBackColor = true;
            this.loadTableButton.Click += new System.EventHandler(this.loadTableButton_Click);
            // 
            // empTableButton
            // 
            this.empTableButton.AutoSize = true;
            this.empTableButton.Location = new System.Drawing.Point(695, 280);
            this.empTableButton.Name = "empTableButton";
            this.empTableButton.Size = new System.Drawing.Size(101, 17);
            this.empTableButton.TabIndex = 11;
            this.empTableButton.Text = "Employee Table";
            this.empTableButton.UseVisualStyleBackColor = true;
            // 
            // itemTableRadio
            // 
            this.itemTableRadio.AutoSize = true;
            this.itemTableRadio.Checked = true;
            this.itemTableRadio.Location = new System.Drawing.Point(695, 257);
            this.itemTableRadio.Name = "itemTableRadio";
            this.itemTableRadio.Size = new System.Drawing.Size(75, 17);
            this.itemTableRadio.TabIndex = 10;
            this.itemTableRadio.TabStop = true;
            this.itemTableRadio.Text = "Item Table";
            this.itemTableRadio.UseVisualStyleBackColor = true;
            // 
            // changeEmpPosButton
            // 
            this.changeEmpPosButton.Location = new System.Drawing.Point(695, 137);
            this.changeEmpPosButton.Name = "changeEmpPosButton";
            this.changeEmpPosButton.Size = new System.Drawing.Size(107, 23);
            this.changeEmpPosButton.TabIndex = 9;
            this.changeEmpPosButton.Text = "Change Position";
            this.changeEmpPosButton.UseVisualStyleBackColor = true;
            this.changeEmpPosButton.Visible = false;
            this.changeEmpPosButton.Click += new System.EventHandler(this.changeEmpPosButton_Click);
            // 
            // removeEmpButton
            // 
            this.removeEmpButton.Location = new System.Drawing.Point(695, 111);
            this.removeEmpButton.Name = "removeEmpButton";
            this.removeEmpButton.Size = new System.Drawing.Size(107, 23);
            this.removeEmpButton.TabIndex = 8;
            this.removeEmpButton.Text = "Remove Employee";
            this.removeEmpButton.UseVisualStyleBackColor = true;
            this.removeEmpButton.Visible = false;
            this.removeEmpButton.Click += new System.EventHandler(this.removeEmpButton_Click);
            // 
            // addNewEmpButton
            // 
            this.addNewEmpButton.Location = new System.Drawing.Point(695, 85);
            this.addNewEmpButton.Name = "addNewEmpButton";
            this.addNewEmpButton.Size = new System.Drawing.Size(107, 23);
            this.addNewEmpButton.TabIndex = 7;
            this.addNewEmpButton.Text = "Add Employee";
            this.addNewEmpButton.UseVisualStyleBackColor = true;
            this.addNewEmpButton.Visible = false;
            this.addNewEmpButton.Click += new System.EventHandler(this.addNewEmpButton_Click);
            // 
            // restockTextBox
            // 
            this.restockTextBox.Location = new System.Drawing.Point(699, 486);
            this.restockTextBox.Name = "restockTextBox";
            this.restockTextBox.Size = new System.Drawing.Size(100, 20);
            this.restockTextBox.TabIndex = 6;
            this.restockTextBox.Visible = false;
            // 
            // restockButton
            // 
            this.restockButton.Location = new System.Drawing.Point(695, 512);
            this.restockButton.Name = "restockButton";
            this.restockButton.Size = new System.Drawing.Size(107, 23);
            this.restockButton.TabIndex = 5;
            this.restockButton.Text = "Amount Purchased";
            this.restockButton.UseVisualStyleBackColor = true;
            this.restockButton.Visible = false;
            this.restockButton.Click += new System.EventHandler(this.restockButton_Click);
            // 
            // removeItemButton
            // 
            this.removeItemButton.Location = new System.Drawing.Point(695, 30);
            this.removeItemButton.Name = "removeItemButton";
            this.removeItemButton.Size = new System.Drawing.Size(107, 23);
            this.removeItemButton.TabIndex = 4;
            this.removeItemButton.Text = "Remove Item";
            this.removeItemButton.UseVisualStyleBackColor = true;
            this.removeItemButton.Visible = false;
            this.removeItemButton.Click += new System.EventHandler(this.removeItemButton_Click);
            // 
            // addNewItemButton
            // 
            this.addNewItemButton.Location = new System.Drawing.Point(695, 4);
            this.addNewItemButton.Name = "addNewItemButton";
            this.addNewItemButton.Size = new System.Drawing.Size(107, 23);
            this.addNewItemButton.TabIndex = 3;
            this.addNewItemButton.Text = "Add New Item";
            this.addNewItemButton.UseVisualStyleBackColor = true;
            this.addNewItemButton.Visible = false;
            this.addNewItemButton.Click += new System.EventHandler(this.addNewItemButton_Click);
            // 
            // adminDataGridView
            // 
            this.adminDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adminDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.adminDataGridView.Location = new System.Drawing.Point(6, 6);
            this.adminDataGridView.Name = "adminDataGridView";
            this.adminDataGridView.Size = new System.Drawing.Size(683, 529);
            this.adminDataGridView.TabIndex = 2;
            // 
            // APMInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 591);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "APMInventory";
            this.Text = "APM Inventory";
            this.tabControl.ResumeLayout(false);
            this.reserveTab.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reserveDataGridView)).EndInit();
            this.eventTab.ResumeLayout(false);
            this.eventTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.manageDataGridView)).EndInit();
            this.adminTab.ResumeLayout(false);
            this.adminTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage reserveTab;
        private System.Windows.Forms.TabPage eventTab;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabPage adminTab;
        private System.Windows.Forms.TextBox itemSearchTextBox;
        private System.Windows.Forms.Button itemSearchButton;
        private System.Windows.Forms.DataGridView reserveDataGridView;
        private System.Windows.Forms.Button addtoEventButton;
        private System.Windows.Forms.Button removefromEventButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox empNameComboBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox eventListBox;
        private System.Windows.Forms.MonthCalendar reserveDateCalendar;
        private System.Windows.Forms.MonthCalendar manageDateCalendar;
        private System.Windows.Forms.DataGridView manageDataGridView;
        private System.Windows.Forms.TextBox firstTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button deleteRequestButton;
        private System.Windows.Forms.TextBox lastTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton byDateRadio;
        private System.Windows.Forms.RadioButton byPersonRadio;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button partialResButton;
        private System.Windows.Forms.Button fullResButton;
        private System.Windows.Forms.DataGridView adminDataGridView;
        private System.Windows.Forms.TextBox amountReturnedTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button removeItemButton;
        private System.Windows.Forms.Button addNewItemButton;
        private System.Windows.Forms.TextBox restockTextBox;
        private System.Windows.Forms.Button restockButton;
        private System.Windows.Forms.RadioButton empTableButton;
        private System.Windows.Forms.RadioButton itemTableRadio;
        private System.Windows.Forms.Button changeEmpPosButton;
        private System.Windows.Forms.Button removeEmpButton;
        private System.Windows.Forms.Button addNewEmpButton;
        private System.Windows.Forms.Button loadTableButton;
        private System.Windows.Forms.ComboBox empPositionComboBox;
    }
}

