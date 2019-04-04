using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseProject
{
    public partial class EmployeePopupForm : Form
    {
        public string firstName;
        public string lastName;
        public string position;
        public EmployeePopupForm(string[] positionType)
        {
            InitializeComponent();
            titleComboBox.Items.AddRange(positionType);
            titleComboBox.SelectedIndex = 0;

        }

        private void createEmpButton_Click(object sender, EventArgs e)
        {
            try
            {
                firstName = firstTextBox.Text;
                lastName = lastTextBox.Text;
                position = titleComboBox.GetItemText(titleComboBox.SelectedItem);

                if (firstName == "") throw new FormatException("first name cant be blank");
                if (lastName == "") throw new FormatException("last name cant be blank");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Missing or incorrect options. Please modify value. Log: " + ex.Message);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
