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
    public partial class ItemPopupForm : Form
    {
        public string itemName;
        public int quantity;
        public int idealQuantity;
        public DateTime expiration;
        public string color;
        public string location;
        public string type;
        public string description;

        public ItemPopupForm(string[] locationList, string[] typeList)
        {
            InitializeComponent();
            itemLocationComboBox.Items.AddRange(locationList);
            itemTypeComboBox.Items.AddRange(typeList);
            itemLocationComboBox.SelectedIndex = 0;
            itemTypeComboBox.SelectedIndex = 0;
        }

        private void generateItemButton_Click(object sender, EventArgs e)
        {
            try
            {
                itemName = itemNameTextBox.Text;
                quantity = int.Parse(itemQuantityTextBox.Text);
                if (itemOptimalTextBox.Text == "") idealQuantity = 0; 
                else idealQuantity = int.Parse(itemOptimalTextBox.Text);
                expiration = itemExpDateTime.Value;
                color = itemColorTextBox.Text;
                location = itemLocationComboBox.GetItemText(itemLocationComboBox.SelectedItem);
                type = itemTypeComboBox.GetItemText(itemTypeComboBox.SelectedItem);
                description = itemDescTextBox.Text;

                if (itemName == "") throw new FormatException("the item name may not be blank");
                if (quantity < 0) throw new FormatException("set a valid quantity amount");
            } catch (FormatException ex)
            {
                MessageBox.Show("Missing or incorrect options. Please modify value. Log: " + ex.Message);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
