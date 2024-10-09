using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Asn1.Crmf;
using MyTimeNamespace; //my class for time functions

class MySQL
{
    //private string connectionString;
    private string commentReason = "Bitte begründen!";

    // A general method to execute SQL queries and bind the results to a DataGridView
    public void ExecuteCustomQuery(string connectionString,string query, DataGridView dataGridView)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            try
            {
                conn.Open();

                // Use SqlCommand to execute the query
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Execute the query and fetch the result using SqlDataAdapter
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Bind the result to the passed DataGridView
                    dataGridView.DataSource = dataTable;

                    //////////////////////////////////////////////////////////////
                    // Special formatting - Start
                    // COLUMNS
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        // Format DateTime columns to show seconds and adjust width
                        if (column.ValueType == typeof(DateTime))
                        {
                            // Set the format to display DateTime with seconds
                            column.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                            // Set column width to fit the entire date/time string
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Auto-size based on content
                        }
                    }
                    // ROWS
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {

                        if (!row.IsNewRow) // Check if the row is not a new row (to avoid unnecessary operations on the new row template)
                        {
                            // Adjust color for comments - Turn commentReason red 
                            //if (row.Cells["Comment"].Value?.ToString() == commentReason)
                            //{
                            //    row.Cells["Comment"].Style.BackColor = System.Drawing.Color.Red;
                            //}
                            // Check if the "texthere" column exists and has a value

                            // Adjust color for ProgStatus
                            if (row.Cells["ProgStatus"].Value?.ToString() == "3")
                            {
                                row.Cells["ProgStatus"].Style.BackColor = System.Drawing.Color.Green;
                            }
                            else row.Cells["ProgStatus"].Style.BackColor = System.Drawing.Color.Red;
                        }
                    }
                    // Check if the DataGridView has a column named "Comment" <-- Code above was sometimes giving errors!
                    if (dataGridView.Columns.Contains("Comment"))
                    {
                        // Get the index of the "texthere" column
                        int columnIndex = dataGridView.Columns["Comment"].Index;

                        // Iterate over the rows in the DataGridView
                        foreach (DataGridViewRow row in dataGridView.Rows)
                        {
                            // Ensure the row is not the new row template
                            if (!row.IsNewRow)
                            {
                                // Check if the value in the "Comment" column is commentReason
                                if (row.Cells[columnIndex].Value?.ToString() == commentReason)
                                {
                                    // Set the background color to red
                                    row.Cells[columnIndex].Style.BackColor = System.Drawing.Color.Red;
                                }
                            }
                        }
                    }


                    // Special formatting - Ende
                    //////////////////////////////////////////////////////////////
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    public void DeleteEntry(string connectionString, int selectedId, string selectedDatabankFilter, DataGridView dataGridView)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            try
            {
                conn.Open();

                string query = "DELETE FROM " + selectedDatabankFilter + " WHERE EventID = @EventID";
                SqlCommand cmd = new SqlCommand(query, conn);

                // Add the Id parameter
                cmd.Parameters.AddWithValue("@EventID", selectedId);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("EventID deleted successfully.");
                }
                else
                {
                    MessageBox.Show("No event found with the provided EventID.");
                }

                // Optionally refresh the DataGridView after deletion
                //btnReadAllSQLEntries_Click(sender, e);
                //ExecuteCustomQuery(connectionString, query, dataGridView); // has still problems
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }

    public void insertMachineStatus(string connectionString, string machineNo, bool debug, int breakTime, string progStatus, string lastUpdate, string insertTime)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            try
            {
                conn.Open();

                string query = "INSERT INTO MachineStatus (Machine, ProgStatus, LastUpdate, InsertTime, Comment) VALUES(@Machine, @ProgStatus, @LastUpdate, @InsertTime, @Comment)";
                SqlCommand cmd = new SqlCommand(query, conn);

                // Adding parameters
                cmd.Parameters.AddWithValue("@Machine", machineNo);
                cmd.Parameters.AddWithValue("@ProgStatus", progStatus);
                cmd.Parameters.AddWithValue("@LastUpdate", MyTime.convertTimeForSQL(lastUpdate));
                cmd.Parameters.AddWithValue("@InsertTime", MyTime.convertTimeForSQL(insertTime));

                string comment = "";
                if (progStatus == "3") comment = "Running";
                else if (progStatus != "3")
                {
                    if (MyTime.CalculateTimeDifferenceInSeconds(insertTime, lastUpdate) > breakTime)
                    {
                        comment = commentReason;
                    }
                    else comment = "Kleine Unterbrechung";
                }

                cmd.Parameters.AddWithValue("@Comment", comment);

                // Add the system time to the InsertTime column
                //cmd.Parameters.AddWithValue("@InsertTime", DateTime.Now);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (debug == true)
                {
                    if (rowsAffected > 0) MessageBox.Show("Data Inserted Successfully!");
                    else MessageBox.Show("No data inserted.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
