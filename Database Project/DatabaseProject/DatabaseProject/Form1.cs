using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace DatabaseProject
{

    public partial class APMInventory : Form
    {
        SqlConnection sqlcon;
        List<Commit> unsavedWork;

        #region HELPER FUNCTIONS

        //Pass non query SQL commands into function, returns number of rows affected
        private int nonQuerySQL(string sql) 
        {
            int rows = 0;
            sqlcon.Open();

            try
            {
                SqlCommand command = new SqlCommand(sql,sqlcon);
                rows = command.ExecuteNonQuery();
            } catch (Exception ex)
            {
                sqlcon.Close();
                throw new Exception("Something went wrong. Log: " + ex.Message + " SQL: " + sql);
                //MessageBox.Show("Something went wrong. Log: " + ex.Message + " SQL: " + sql);
            }

            sqlcon.Close();
            return rows; 
        }

        //Used to call SQL Queries, returns a data table containing the results
        private DataTable QuerySQL(string sql)
        {
            try
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand(sql, sqlcon);
                SqlDataReader data = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(data);
                sqlcon.Close();

                return dt;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message + " Log: " + sql);
            }
        }

        //Returns an List of items from column and table specified
        private List<string> pullColumnFrom(string column, string table)
        {
            List<string> arr = new List<string>();
            string getColumn =
                "SELECT " + column + " FROM " + table + ";";
            DataTable dataTable = QuerySQL(getColumn);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                arr.Add(dataTable.Rows[i].ItemArray[0].ToString());
            }

            return arr;
        }

        //Pass in a value to look up the ID equivalent to the value. Can only be used for 
        //Values that are unique
        private string IDlookup(string valueColumn, string value)
        {
            string table = "";
            string id = "";
            if (valueColumn == "WORKER_TITLE") { table = "WORKER_CLASS"; id = "WORKER_ID"; }
            else if (valueColumn == "LOCATION_NAME") { table = "LOCATION"; id = "LOCATION_ID"; }
            else if (valueColumn == "TYPE_DESC") { table = "ITEM_CLASS"; id = "ITEM_TYPE"; }

            DataTable dt = QuerySQL($"SELECT {id} FROM {table} WHERE {valueColumn} = '{value}';");

            return dt.Rows[0].ItemArray[0].ToString();
        }

        #endregion

        public APMInventory()
        {
            InitializeComponent();

            //string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = \""+ Application.StartupPath + "\\InventoryDB.mdf\"; Integrated Security = True";
            string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = \"C:\\Users\\Mike-Laptop\\Desktop\\Database Project\\DatabaseProject\\DatabaseProject\\InventoryDB.mdf\"; Integrated Security = True";
            sqlcon = new SqlConnection(connectionString);
            reloadEmployeeNameComboBox();
            unsavedWork = new List<Commit>();
           
            //nonQuerySQL("INSERT INTO CHECKOUT VALUES ('40000009', '2', ")
        }

        private void tabIndexChanged_Click(object sender, EventArgs e)
        {
            quantityTextBox.Text = "";
            firstTextBox.Text = "";
            lastTextBox.Text = "";
            amountReturnedTextBox.Text = "";
            restockTextBox.Text = "";

            adminDataGridView.DataSource = null;
            manageDataGridView.DataSource = null;
            reserveDataGridView.DataSource = null;
        }

        #region TAB 1 EVENTS

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (unsavedWork.Count > 0)
            {
                string requestString = "Are you sure you would like to close. You have unsaved work:\n";
                for(int i = 0; i < unsavedWork.Count; i++)
                {
                    requestString += unsavedWork[i].ToString() + "\n";
                }
                DialogResult res = MessageBox.Show(requestString,"Unsaved Work", MessageBoxButtons.YesNo);

                e.Cancel = (res == DialogResult.No);
                
            }
            
        }

        private void reloadEmployeeNameComboBox()
        {
            DataTable dt = QuerySQL("SELECT EMP_ID, FIRST_NAME, LAST_NAME " +
                "FROM EMPLOYEE " +
                "ORDER BY LAST_NAME, FIRST_NAME;");

            int total = dt.Rows.Count;

            empNameComboBox.Items.Clear();
            for (int i = 0; i < total; i++)
            {
                object[] row = dt.Rows[i].ItemArray;
                empNameComboBox.Items.Add(new Employee(row[0].ToString(), row[1].ToString(), row[2].ToString()));
            }

        }

        //Search for an item name from the DB
        //Inputs:   itemSearchTextBox       - Used to gather item name
        //Outputs:  reserveDataGridView     - put resulting table here 
        //Output sort by is determined by sortByComboBox
        private void itemSearchButton_Click(object sender, EventArgs e)
        {
            string input = "%" + itemSearchTextBox.Text + "%";
            string sql =
                   "SELECT ITEM_NAME AS 'Item', TYPE_DESC AS 'Type', ITEM_QUANTITY AS 'Stock', LOCATION_NAME AS 'Location', ITEM_DESC AS 'Description', ITEM_COLOR AS 'Color', ITEM_EXPIRATION AS 'Expiration', ITEM_ID " +
                   "FROM ITEM, LOCATION, ITEM_CLASS " +
                   "WHERE ITEM.LOCATION_ID = LOCATION.LOCATION_ID " +
                   "AND ITEM.ITEM_TYPE = ITEM_CLASS.ITEM_TYPE " +
                   $"AND ITEM_NAME LIKE '{input}'" +
                   "ORDER BY TYPE_DESC;";

            reserveDataGridView.DataSource = QuerySQL(sql);
            reserveDataGridView.Columns[reserveDataGridView.Columns.Count - 1].Visible = false;
            reserveDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            reserveDataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

        }


        //Adds currently selected item from inventory to eventListBox for later committing
        //Creates item object using the inputs given and places the created item into 
        //Inputs:   reserveDataGridView     - used to gather item to be added
        //          quantityTextBox         - amount to be reserved
        //          reserveDateCalendar     - date to be reserved for
        //Outputs:  eventListBox            - place item and about in here 
        //
        //Example:
        //Item i = new Item("10000000", "Test Item", 10, DateTime.Today);
        //eventListBox.Items.Add(i);  
        private void addtoEventButton_Click(object sender, EventArgs e)
        {
            string itemid = "";
            string itemName = "";
            if (reserveDataGridView.SelectedRows.Count == 1)
            {
                itemid = reserveDataGridView.SelectedRows[0].Cells[reserveDataGridView.SelectedRows[0].Cells.Count - 1].Value.ToString();
                itemName = reserveDataGridView.SelectedRows[0].Cells[0].Value.ToString();
                if(itemid == "" || itemName == "")
                {
                    MessageBox.Show("Error, item not selected");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Item selection is incorrect. Please select a row heading");
                return;
            }

            string empid = "";
            try
            {
                empid = ((Employee)empNameComboBox.SelectedItem).primaryKey;
            } catch (Exception ex)
            {
                MessageBox.Show("Please select an employee.");
                return;
            }

            int quantity = 0;
            try { quantity = int.Parse(quantityTextBox.Text); }
            catch (Exception ex)
            {
                MessageBox.Show("Problem with input quantity: " + ex.Message);
            }

            DateTime date = reserveDateCalendar.SelectionStart;
            if (date.Date <= DateTime.Now.Date.AddDays(7))
            {
                MessageBox.Show("Date too close to process. Please select something at least a week out.");
                return;
            }
            Item i = new Item(itemid, itemName, quantity, date);
            if (eventListBox.Items.Contains(i))
            {
                MessageBox.Show("An item can only be reserved once per event");
                return;
            }
            eventListBox.Items.Add(i);
            unsavedWork.Add(new Commit(empid, i));

            quantityTextBox.Text = "";
        }


        //Removes currecntly selected item from eventListBox
        //Inputs:   eventListBox            - get index of current item and delete
        private void removefromEventButton_Click(object sender, EventArgs e)
        {
            if(eventListBox.SelectedItems.Count != 0)
            {
                List<Commit> unsavedRemove = new List<Commit>();
                List<Item> eventRemove = new List<Item>();
                for(int i = 0; i < eventListBox.SelectedItems.Count; i++)
                {
                    for(int j = 0; j < unsavedWork.Count; j++)
                    {
                        if(unsavedWork[j].itemID == ((Item)eventListBox.SelectedItems[i]).primaryKey)
                        {
                            unsavedRemove.Add(unsavedWork[j]);
                            eventRemove.Add((Item)eventListBox.SelectedItems[i]);
                        }
                    }
                }

                foreach(Item i in eventRemove) eventListBox.Items.Remove(i);
                foreach (Commit c in unsavedRemove) unsavedWork.Remove(c);
            }
            
        }

        //Adds and commits the items selected to the checkout table. The list should then be cleared 
        //Inputs:   eventListBox            - take items to be reserved from here uses PK to identify 
        //Ouputs:   none
        private void submitButton_Click(object sender, EventArgs e)
        {
            int position = 0;
            int count = eventListBox.Items.Count;
            List<string> log = new List<string>();
            for(int i = 0; i < count; i++)
            {
                try
                {
                    nonQuerySQL(unsavedWork[position].getSQL());

                    unsavedWork.RemoveAt(position);
                    eventListBox.Items.RemoveAt(position);

                } catch(Exception ex)
                {
                    log.Add(unsavedWork[position].itemName);
                    position++;
                }
                
            }

            if (log.Count > 0) MessageBox.Show("Some items could not be saved due to conflicts");
            //eventListBox.Items.Clear();
            //unsavedWork.Clear();
        }

        #endregion

        #region TAB 2 EVENTS

        private void removeCheckoutByID(string empID, string itemID)
        {
            string sql = "DELETE FROM CHECKOUT " +
                $"WHERE EMP_ID = '{empID}' " +
                $"AND ITEM_ID = '{itemID}';";

            nonQuerySQL(sql);
        }

        string tab2LastSQLReload;

        private void loadTab2TableBySQL(string sql)
        {
            manageDataGridView.DataSource = QuerySQL(sql);
            int coltot = manageDataGridView.Columns.Count;
            manageDataGridView.Columns[coltot - 1].Visible = false;
            manageDataGridView.Columns[coltot - 2].Visible = false;
            tab2LastSQLReload = sql;

        }

        //Searches the database and returns all results matching the search criteria in manageDataGridView
        //Inputs:   byPersonRadio           - Radio button option used to search by person using last name and first name
        //          byDateRadio             - Radio button option used to search by date selected 
        //          manageDateCalendar      - Date to search on
        //          firstTextBox            - first name of employee
        //          lastTextBox             - last name of employee
        //Outputs:  manageDataGridView      - the output grid to list results
        private void searchButton_Click(object sender, EventArgs e)
        {
            if (byPersonRadio.Checked)
            {
                string sql =
                    "SELECT ITEM_NAME AS 'Item Name', REQ_QUANTITY AS 'Request', FIRST_NAME AS 'First Name', LAST_NAME AS 'Last Name', REQ_DATE AS 'Date', CHECKOUT.EMP_ID, CHECKOUT.ITEM_ID " +
                    "FROM CHECKOUT, EMPLOYEE, ITEM " +
                    "WHERE CHECKOUT.ITEM_ID = ITEM.ITEM_ID " +
                    "AND CHECKOUT.EMP_ID = EMPLOYEE.EMP_ID ";
                if (firstTextBox.Text != "") sql += $"AND FIRST_NAME = '{firstTextBox.Text}' ";
                if (lastTextBox.Text != "") sql += $"AND LAST_NAME = '{lastTextBox.Text}' ";
                sql += "ORDER BY LAST_NAME, FIRST_NAME;";

                loadTab2TableBySQL(sql);
               
            }
            else
            {
                string sql =
                    "SELECT ITEM_NAME AS 'Item Name', REQ_QUANTITY AS 'Request', REQ_DATE AS 'Date', FIRST_NAME AS 'First Name', LAST_NAME AS 'Last Name', CHECKOUT.EMP_ID, CHECKOUT.ITEM_ID " +
                    "FROM CHECKOUT, EMPLOYEE, ITEM " +
                    "WHERE CHECKOUT.ITEM_ID = ITEM.ITEM_ID " +
                    "AND CHECKOUT.EMP_ID = EMPLOYEE.EMP_ID " +
                    $"AND REQ_DATE >= '{manageDateCalendar.SelectionStart}'" +
                    "ORDER BY REQ_DATE;";

                loadTab2TableBySQL(sql);
            }
        }


        //For the selected reservation from the database, resolves the outstanding request and updates the total in the item qantity. 
        //The request should them be removed from the list 
        //Inputs:   manageDataGridView      - The request selected is the one to be updated 
        //Outputs:  none
        private void fullResButton_Click(object sender, EventArgs e)
        {
            if (manageDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row");
                return;
            }
            DataGridViewRow r = manageDataGridView.SelectedRows[0];
            try
            {
                string itemid = r.Cells[r.Cells.Count - 1].Value.ToString();
                string empid = r.Cells[r.Cells.Count - 2].Value.ToString();
                string sql = "UPDATE ITEM " +
                    "SET ITEM_QUANTITY = ITEM_QUANTITY - (SELECT REQ_QUANTITY " +
                                                        "FROM CHECKOUT " +
                                                        $"WHERE EMP_ID = '{empid}' " +
                                                        $"AND ITEM_ID = '{itemid}') " +
                    $"WHERE ITEM_ID = '{itemid}'";
                nonQuerySQL(sql);

                sql = $"IF (SELECT ITEM_QUANTITY FROM ITEM WHERE ITEM_ID = '{itemid}') < 0 " +
                    "BEGIN " +
                    "UPDATE ITEM " +
                    "SET ITEM_QUANTITY = '0' " +
                    $"WHERE ITEM_ID = '{itemid}' " +
                    $"END;";

                nonQuerySQL(sql);
                removeCheckoutByID(empid, itemid);
                loadTab2TableBySQL(tab2LastSQLReload);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please selected a proper row. Log: " + ex.Message);
                return;
            }
        }


        //For the selected reservation from the database, resolves the outstanding request and updates the total in the item qantity. 
        //This option is for when the total used at the program was less than requested
        //The request should them be removed from the list 
        //Inputs:   manageDataGridView      - The request selected is the one to be updated 
        //          amountReturnedTextBox   - The amount that was leftover and returned. This box should be cleared after reading
        //Outputs:  none
        //Notes:    Formula for new total   - OldItemQantity = OldItemQantity - AmountRequsted + AmountReturned
        private void partialResButton_Click(object sender, EventArgs e)
        {
            if (manageDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row");
                return;
            }
            DataGridViewRow r = manageDataGridView.SelectedRows[0];
            try
            {
                string itemid = r.Cells[r.Cells.Count - 1].Value.ToString();
                string empid = r.Cells[r.Cells.Count - 2].Value.ToString();
                int requestedAmount = int.Parse(QuerySQL("SELECT REQ_QUANTITY FROM CHECKOUT " +
                    $"WHERE EMP_ID = '{empid}'" +
                    $"AND ITEM_ID = '{itemid}';").Rows[0].ItemArray[0].ToString());

                int returned = int.Parse(amountReturnedTextBox.Text);
                if (returned < 0) throw new FormatException("The value entered is negative");
                int delta = requestedAmount - returned;
                if (delta < 0) throw new FormatException("The amount returned is more than requested");

                

                string sql = "UPDATE ITEM " +
                    $"SET ITEM_QUANTITY = ITEM_QUANTITY - '{delta}' " + 
                    $"WHERE ITEM_ID = '{itemid}'";
                nonQuerySQL(sql);

                sql = $"IF (SELECT ITEM_QUANTITY FROM ITEM WHERE ITEM_ID = '{itemid}') < 0 " +
                    "BEGIN " +
                    "UPDATE ITEM " +
                    "SET ITEM_QUANTITY = '0' " +
                    $"WHERE ITEM_ID = '{itemid}' " +
                    $"END;";

                nonQuerySQL(sql);

                removeCheckoutByID(empid, itemid);

                loadTab2TableBySQL(tab2LastSQLReload);

            }catch (FormatException ex)
            {
                MessageBox.Show("There was an issue: " + ex.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please selected a proper row. Log: " + ex.Message);
                return;
            } 
        }

        //Removes selected request without updating total
        //Inputs:   manageDataGridView      - request to be removed
        //Outputs:  none
        private void deleteRequestButton_Click(object sender, EventArgs e)
        {
            if (manageDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row");
                return;
            }
            DataGridViewRow r = manageDataGridView.SelectedRows[0];
            try
            {
                string itemid = r.Cells[r.Cells.Count - 1].Value.ToString();
                string empid = r.Cells[r.Cells.Count - 2].Value.ToString();
                removeCheckoutByID(empid, itemid);
                loadTab2TableBySQL(tab2LastSQLReload);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please selected a proper row. Log: " + ex.Message);
                return;
            }
        }

        #endregion

        #region TAB 3 EVENTS

        private void loadTab3EmployeeTable()
        {
            string sql =
                "SELECT FIRST_NAME AS 'First Name', LAST_NAME AS 'Last Name', WORKER_TITLE AS 'Job Title', EMP_ID " +
                "FROM EMPLOYEE, WORKER_CLASS " +
                "WHERE EMPLOYEE.WORKER_ID = WORKER_CLASS.WORKER_ID " +
                "ORDER BY LAST_NAME, FIRST_NAME";
            adminDataGridView.DataSource = QuerySQL(sql);
            int coltot = adminDataGridView.Columns.Count;
            adminDataGridView.Columns[coltot - 1].Visible = false;
        }

        private void loadTab3ItemTable()
        {
            //string sql =
            //    "SELECT ITEM_NAME, TYPE_DESC, ITEM_QUANTITY, ITEM_OPTIMAL, (SELECT SUM(REQ_QUANTITY) FROM CHECKOUT WHERE CHECKOUT.ITEM_ID = ITEM.ITEM_ID) AS 'Requested' , LOCATION_NAME, ITEM_DESC, ITEM_COLOR, ITEM_EXPIRATION, ITEM.ITEM_ID " +
            //    "FROM ITEM, LOCATION, ITEM_CLASS, CHECKOUT " +
            //    "WHERE ITEM.LOCATION_ID = LOCATION.LOCATION_ID " +
            //    "AND ITEM.ITEM_TYPE = ITEM_CLASS.ITEM_TYPE " +
            //    "AND ITEM.ITEM_ID = CHECKOUT.ITEM_ID " +
            //    "ORDER BY TYPE_DESC;";
            string sql =
                "SELECT ITEM_NAME AS 'Name', TYPE_DESC AS 'Type', ITEM_QUANTITY AS 'Stock', ITEM_OPTIMAL AS 'Optimal', " +
                "SUM(REQ_QUANTITY) AS 'Requested', " +
                "LOCATION_NAME AS 'Location', ITEM_DESC AS 'Description', ITEM_COLOR AS 'Color', ITEM_EXPIRATION AS 'Expiration', ITEM.ITEM_ID " +
                "FROM LOCATION, ITEM_CLASS, ITEM " +
                "LEFT JOIN CHECKOUT ON CHECKOUT.ITEM_ID = ITEM.ITEM_ID " +
                "WHERE ITEM.LOCATION_ID = LOCATION.LOCATION_ID " +
                "AND ITEM.ITEM_TYPE = ITEM_CLASS.ITEM_TYPE " +
                "GROUP BY ITEM.ITEM_ID , ITEM_NAME, TYPE_DESC, ITEM_QUANTITY, ITEM_OPTIMAL, LOCATION_NAME, ITEM_DESC, ITEM_COLOR, ITEM_EXPIRATION " +
                "ORDER BY TYPE_DESC;";


            adminDataGridView.DataSource = QuerySQL(sql);
            int coltot = adminDataGridView.Columns.Count;
            adminDataGridView.Columns[coltot - 1].Visible = false;
            for(int i = 0; i < adminDataGridView.Columns.Count; i++) adminDataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            
            if (adminDataGridView.Rows.Count > 0)
            {
                for(int i = 0; i < adminDataGridView.Rows.Count; i++)
                {
                    try
                    {
                        int optimal = int.Parse(adminDataGridView.Rows[i].Cells[3].Value.ToString());
                        int quantity = int.Parse(adminDataGridView.Rows[i].Cells[2].Value.ToString());
                        if(quantity < optimal)
                        {
                            for(int j = 0; j < adminDataGridView.Rows[i].Cells.Count; j++)
                            {
                                DataGridViewCellStyle style = new DataGridViewCellStyle();
                                style.BackColor = Color.IndianRed;
                                adminDataGridView.Rows[i].Cells[j].Style = style;
                            }
                        }
                    } catch { }

                    try
                    {
                        string id = adminDataGridView.Rows[i].Cells[adminDataGridView.Rows[i].Cells.Count - 1].Value.ToString();
                        int total = int.Parse(QuerySQL($"SELECT SUM(REQ_QUANTITY) FROM CHECKOUT WHERE ITEM_ID = '{id}'").Rows[0].ItemArray[0].ToString());

                        if (total > int.Parse(adminDataGridView.Rows[i].Cells[2].Value.ToString()))
                        {
                            for (int j = 0; j < adminDataGridView.Rows[i].Cells.Count; j++)
                            {
                                DataGridViewCellStyle style = new DataGridViewCellStyle();
                                style.BackColor = Color.Yellow;
                                adminDataGridView.Rows[i].Cells[j].Style = style;
                            }
                        }
                    } catch { }
                }
            }
        }

        //Loads table according to selected radio
        //Inputs:   itemTableRadio          - load item table
        //          empTableRadio           - load employee table
        //          addNewItemButton        - Is hidden when in employee table
        //          removeItemButton        - Is hidden when in employee table
        //          addNewEmployeeButton    - Is hidden when in item table
        //          removeEmployeeButton    - Is hidden when in item table
        //          changeEmployeeButton    - Is hidden when in item table
        //          empPositionComboBox     - Is hidden when in item table
        //Outputs:  adminDataGridView       - table to put table into
        //Notes:    additional functions    - Hides and unhides the buttons associated with the current table loaded. 
        //                                    Also repopulates the empPositionComboBox with the positions listen in the worker_class table
        private void loadTableButton_Click(object sender, EventArgs e)
        {
            if (itemTableRadio.Checked)
            {
                addNewItemButton.Visible = true;
                removeItemButton.Visible = true;
                restockTextBox.Visible = true;
                restockButton.Visible = true;

                addNewEmpButton.Visible = false;
                removeEmpButton.Visible = false;
                changeEmpPosButton.Visible = false;
                empPositionComboBox.Visible = false;


                //Loads Table
                loadTab3ItemTable();

            }
            else
            {
                addNewItemButton.Visible = false;
                removeItemButton.Visible = false;
                restockTextBox.Visible = false;
                restockButton.Visible = false;

                addNewEmpButton.Visible = true;
                removeEmpButton.Visible = true;
                changeEmpPosButton.Visible = true;
                empPositionComboBox.Visible = true;

                //Populates Combo Box
                empPositionComboBox.Items.Clear();
                foreach (string s in pullColumnFrom("WORKER_TITLE", "WORKER_CLASS"))
                {
                    empPositionComboBox.Items.Add(s);
                }
                empPositionComboBox.SelectedIndex = 0;

                loadTab3EmployeeTable();

            }
        }


        //Restocks the item selected by the quantity bought
        //Inputs:   restockTextBox          - quantity of item bought
        //          adminDataGridView       - item selected is to be updated
        //Outputs:  none
        private void restockButton_Click(object sender, EventArgs e)
        {
            if (adminDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row");
                return;
            }
            DataGridViewRow r = adminDataGridView.SelectedRows[0];

            try
            {
                string val = r.Cells[r.Cells.Count - 1].Value.ToString();
                int add = int.Parse(restockTextBox.Text);
                string sql = $"UPDATE ITEM SET ITEM_QUANTITY = ITEM_QUANTITY + '{add}' WHERE ITEM_ID = '{val}';";
                nonQuerySQL(sql);
            }
            catch (NullReferenceException ex) {
                MessageBox.Show("Please selected a proper row. Log: " + ex.Message);
                return;
            } catch (Exception ex)
            {
                MessageBox.Show("Restock value incorrect. Log: " + ex.Message);
            }

            loadTab3ItemTable();

            
        }

        //Creates a pop up form to populate the data to make a new item 
        private void addNewItemButton_Click(object sender, EventArgs e)
        {
            string[] locationList = pullColumnFrom("LOCATION_NAME", "LOCATION").ToArray();
            string[] typeList = pullColumnFrom("TYPE_DESC", "ITEM_CLASS").ToArray();
            ItemPopupForm getInput = new ItemPopupForm(locationList, typeList);
            if (getInput.ShowDialog() == DialogResult.OK)
            {
                string type = IDlookup("TYPE_DESC", getInput.type);
                string loc = IDlookup("LOCATION_NAME", getInput.location);

                //String builder for value input
                string first = "INSERT INTO ITEM (ITEM_NAME, ITEM_TYPE, ITEM_QUANTITY, LOCATION_ID";
                string last = $" VALUES ('{getInput.itemName}', '{type}', '{getInput.quantity}', '{loc}'";

                if (getInput.color != "") { first += ", ITEM_COLOR"; last += $", '{getInput.color}'"; }
                if (getInput.description != "") { first += ", ITEM_DESC"; last += $", '{getInput.description}'"; }
                if (getInput.expiration.Date != DateTime.Now.Date) { first += ", ITEM_EXPIRATION"; last += $", '{getInput.expiration}'"; }
                if (getInput.idealQuantity > 0) { first += ", ITEM_OPTIMAL"; last += $", '{getInput.idealQuantity}'"; }

                string sql = first + ") " + last + ");";

                nonQuerySQL(sql);
                loadTab3ItemTable();
            }
        }

        //Removes selected item from database
        //Inputs:   adminDataGridView       - Deletes item from database
        //Outputs:  none
        private void removeItemButton_Click(object sender, EventArgs e)
        {
            if(adminDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row");
                return;
            }
            DataGridViewRow r = adminDataGridView.SelectedRows[0];

            try
            {
                string val = r.Cells[r.Cells.Count - 1].Value.ToString();
                string sql = $"DELETE FROM ITEM WHERE ITEM_ID = '{val}';";
                nonQuerySQL(sql);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Please selected a proper row. Log: " + ex.Message);
                return;
            }
            loadTab3ItemTable();
        }


        //Creates a pop up form to populate the data to make a new employee 
        private void addNewEmpButton_Click(object sender, EventArgs e)
        {
            string[] positionList = pullColumnFrom("WORKER_TITLE", "WORKER_CLASS").ToArray();
            EmployeePopupForm getInput = new EmployeePopupForm(positionList);
            if (getInput.ShowDialog() == DialogResult.OK)
            {
                string id = IDlookup("WORKER_TITLE", getInput.position);
                //Create new employee using firstName, lastName, position
                string sql = "INSERT INTO EMPLOYEE (FIRST_NAME, LAST_NAME, WORKER_ID) " +
                    $"VALUES ('{getInput.firstName}', '{getInput.lastName}', '{id}');";
                
                nonQuerySQL(sql);
                loadTab3EmployeeTable();
                reloadEmployeeNameComboBox();
            }
        }


        //Removes selected employee from database
        //Inputs:   adminDataGridView       - Deletes employee from database
        //Outputs:  none
        private void removeEmpButton_Click(object sender, EventArgs e)
        {
            if (adminDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row");
                return;
            }
            foreach (DataGridViewRow r in adminDataGridView.SelectedRows)
            {
                try
                {
                    string val = r.Cells[r.Cells.Count - 1].Value.ToString();
                    try
                    {
                        string totalSQL = $"SELECT COUNT(EMP_ID) FROM CHECKOUT WHERE EMP_ID = '{val}'";
                        int total = int.Parse(QuerySQL(totalSQL).Rows[0].ItemArray[0].ToString());
                        DialogResult res = MessageBox.Show("Are you sure you would like to remove this employee? They currently have " + total + " outstanding requests that will be deleted.", "Are you sure?", MessageBoxButtons.YesNo);
                        if (res == DialogResult.No) continue ;
                        else
                        {
                            string delSQL = $"DELETE FROM CHECKOUT WHERE EMP_ID = '{val}'";
                            nonQuerySQL(delSQL);
                        }
                    }
                    catch { }
                    string sql = $"DELETE FROM EMPLOYEE WHERE EMP_ID = '{val}';";
                    nonQuerySQL(sql);
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Please selected a proper row. Log: " + ex.Message);
                    return;
                }

            }
            loadTab3EmployeeTable();
            reloadEmployeeNameComboBox();
        }

        //Changes selected employee position to selection from comboBox
        //Inputs:   empPositionComboBox     - Position to change to
        //          adminDataGridView       - Employee to update
        //Outputs:  none
        private void changeEmpPosButton_Click(object sender, EventArgs e)
        {
            if(adminDataGridView.SelectedRows.Count == 1)
            {
                string val = adminDataGridView.SelectedRows[0].Cells[adminDataGridView.SelectedRows[0].Cells.Count - 1].Value.ToString();
                string newPos = IDlookup("WORKER_TITLE", empPositionComboBox.GetItemText(empPositionComboBox.SelectedItem));
                string sql = 
                    "UPDATE EMPLOYEE " +
                    $"SET WORKER_ID = '{newPos}' " +
                    $"WHERE EMP_ID = '{val}';";
                nonQuerySQL(sql);
                loadTab3EmployeeTable();
            }
        }

        #endregion


    }

    public class Commit
    {
        public readonly string empID;
        public readonly string itemID;
        public readonly string itemName;
        public readonly int quantity;
        public readonly DateTime date;

        public Commit(string e, string i, string n, int q, DateTime d)
        {
            empID = e;
            itemID = i;
            itemName = n;
            quantity = q;
            date = d;
        }

        public Commit(string e, Item i)
        {
            empID = e;
            itemID = i.primaryKey;
            itemName = i.itemName;
            quantity = i.quantity;
            date = i.date;
        }

        public string getSQL()
        {
            return "INSERT INTO CHECKOUT " +
                $"VALUES ('{empID}', '{itemID}', '{date}', '{quantity}');";
        }

        public override string ToString()
        {
            return $"{itemName}({quantity}) for {date.ToShortDateString()}";
        }


    }

    public class Employee
    {
        public readonly string primaryKey;
        public readonly string firstName;
        public readonly string lastName;

        public Employee(string pk, string f, string l)
        {
            primaryKey = pk;
            firstName = f;
            lastName = l;
        }

        public override string ToString()
        {
            return $"{lastName}, {firstName}";
        }
    }

    public class Item
    {
        public readonly string primaryKey;
        public readonly string itemName;
        public readonly int quantity;
        public readonly DateTime date;

        public Item(string PK, string i, int q, DateTime d)
        {
            primaryKey = PK;
            itemName = i;
            quantity = q;
            date = d;
        }

        public override bool Equals(object obj)
        {
            try
            {
                Item other = (Item)obj;
                return primaryKey == other.primaryKey && date.Date == other.date.Date;
            }
            catch { }
            return false;
        }

        public override String ToString()
        {
            return itemName + ": " + quantity + " (" + date.ToShortDateString() + ")";
        }
    }

}
