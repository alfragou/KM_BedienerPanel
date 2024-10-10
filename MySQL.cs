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
    private string commentReason = "Bitte begründen!";
    private string connectionString;

    public MySQL(string connectionString)
    {
        this.connectionString = connectionString;
    }

    // A general method to execute SQL queries and bind the results to a DataGridView
    public void ExecuteCustomQuery(string query, DataGridView dataGridView)
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
                    dataAdapter.Fill(dataTable); // Fill the DataTable with data from the database

                    // Bind the result to the passed DataGridView
                    dataGridView.DataSource = dataTable;

                    // Special Format
                    dataGridViewSpecialFormat(dataGridView);
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

    public DataTable LoadData(string tableName, DataGridView dataGridView)
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter($"SELECT * FROM {tableName}", conn);
                //dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;

                // Apply special formatting
                dataGridViewSpecialFormat(dataGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }
        return dataTable;
    }

    public void SaveData(DataTable dataTable, string selectedTable)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            // Start a transaction to ensure all updates are applied together
            SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    // Check if the row has been modified
                    if (row.RowState == DataRowState.Modified)
                    {
                        // Update logic
                        UpdateRow(row, conn, transaction, selectedTable);
                    }
                    // Check if the row is new (Added)
                    else if (row.RowState == DataRowState.Added)
                    {
                        // Insert logic
                        InsertRow(row, conn, transaction, selectedTable);
                    }
                }

                // Commit transaction
                transaction.Commit();
                MessageBox.Show("Changes saved successfully!");
                dataTable.AcceptChanges();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Error saving changes: " + ex.Message);
            }
        }
    }

    private void UpdateRow(DataRow row, SqlConnection conn, SqlTransaction transaction, string selectedTable)
    {
        string selectedDatabankFilter = selectedTable;
        string productionDataMsg = "Machine = @Machine, ProgStatus = @ProgStatus, ProgPfadName = @ProgPfadName, LineContent = @LineContent, ToolIdent = @ToolIdent, Overrid = @Overrid, MFunktion = @MFunktion, OpMode = @OpMode, VorschubSpdl = @VorschubSpdl, Comment = @Comment, InsertTime = @InsertTime WHERE EventID = @EventID"; // Update for ProductionData
        string machineStatusMsg = "Machine = @Machine, ProgStatus = @ProgStatus, LastUpdate = @LastUpdate, InsertTime = @InsertTime, Comment = @Comment WHERE EventID = @EventID"; // Update for MachineStatus
        string sqlMsg = "";
        if (selectedDatabankFilter == "ProductionData")
        {
            sqlMsg = productionDataMsg;
        }
        else if (selectedDatabankFilter == "MachineStatus")
        {
            sqlMsg = machineStatusMsg;
        }

        string query = "UPDATE " + selectedDatabankFilter + " SET " + sqlMsg;
        using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
        {
            // Add parameters from the DataTable row
            cmd.Parameters.AddWithValue("@EventID", row["EventID"]);
            cmd.Parameters.AddWithValue("@Machine", row["Machine"]);
            cmd.Parameters.AddWithValue("@ProgStatus", row["ProgStatus"]);
            cmd.Parameters.AddWithValue("@InsertTime", row["InsertTime"]);
            cmd.Parameters.AddWithValue("@Comment", row["Comment"]);

            if (selectedDatabankFilter == "ProductionData")
            {
                cmd.Parameters.AddWithValue("@ProgPfadName", row["ProgPfadName"]);
                cmd.Parameters.AddWithValue("@LineContent", row["LineContent"]);
                cmd.Parameters.AddWithValue("@ToolIdent", row["ToolIdent"]);
                cmd.Parameters.AddWithValue("@Overrid", row["Overrid"]);
                cmd.Parameters.AddWithValue("@MFunktion", row["MFunktion"]);
                cmd.Parameters.AddWithValue("@OpMode", row["OpMode"]);
                cmd.Parameters.AddWithValue("@VorschubSpdl", row["VorschubSpdl"]);
            }
            else if (selectedDatabankFilter == "MachineStatus")
            {
                cmd.Parameters.AddWithValue("@LastUpdate", row["LastUpdate"]);
            }
            // Show the query for debugging purposes
            string debugQuery = cmd.CommandText
                .Replace("@Machine", row["Machine"].ToString())
                .Replace("@ProgStatus", row["ProgStatus"].ToString())
                .Replace("@InsertTime", row["InsertTime"].ToString())
                 .Replace("@Comment", row["Comment"].ToString());
            MessageBox.Show("Executing Query: " + debugQuery);
            cmd.ExecuteNonQuery();
        }
    }

    private void InsertRow(DataRow row, SqlConnection conn, SqlTransaction transaction, string selectedTable)
    {
        string selectedDatabankFilter = selectedTable;

        // Prepare Query
        string productionDataMsg = "Machine, ProgStatus, ProgPfadName, LineContent, ToolIdent, Overrid, MFunktion, OpMode, VorschubSpdl, Comment, InsertTime) VALUES(@Machine, @ProgStatus, @ProgPfadName, @LineContent, @ToolIdent, @Overrid, @MFunktion, @OpMode, @VorschubSpdl, @Comment,  @InsertTime";
        string machineStatusMsg = "Machine, ProgStatus, LastUpdate, InsertTime, Comment) VALUES(@Machine, @ProgStatus, @LastUpdate, @InsertTime, @Comment";
        string sqlMsg = "";
        if (selectedDatabankFilter == "ProductionData")
        {
            sqlMsg = productionDataMsg;
        }
        else if (selectedDatabankFilter == "MachineStatus")
        {
            sqlMsg = machineStatusMsg;
        }

        // Insert new row into the database 
        string query = "INSERT INTO " + selectedDatabankFilter + " (" + sqlMsg + ")";
        using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
        {
            // Add parameters for new data
            cmd.Parameters.AddWithValue("@Machine", row["Machine"]);
            cmd.Parameters.AddWithValue("@ProgStatus", row["ProgStatus"]);
            cmd.Parameters.AddWithValue("@Comment", row["Comment"]);
            cmd.Parameters.AddWithValue("@InsertTime", row["InsertTime"]);
            if (selectedDatabankFilter == "ProductionData")
            {
                cmd.Parameters.AddWithValue("@ProgPfadName", row["ProgPfadName"]);
                cmd.Parameters.AddWithValue("@LineContent", row["LineContent"]);
                cmd.Parameters.AddWithValue("@ToolIdent", row["ToolIdent"]);
                cmd.Parameters.AddWithValue("@Overrid", row["Overrid"]);
                cmd.Parameters.AddWithValue("@MFunktion", row["MFunktion"]);
                cmd.Parameters.AddWithValue("@OpMode", row["OpMode"]);
                cmd.Parameters.AddWithValue("@VorschubSpdl", row["VorschubSpdl"]);
            }
            else if (selectedDatabankFilter == "MachineStatus")
            {
                cmd.Parameters.AddWithValue("@LastUpdate", row["LastUpdate"]);
            }
            // Show the query for debugging purposes
            string debugQuery = cmd.CommandText
                .Replace("@Machine", row["Machine"].ToString())
                .Replace("@ProgStatus", row["ProgStatus"].ToString())
                .Replace("@InsertTime", row["InsertTime"].ToString())
                 .Replace("@Comment", row["Comment"].ToString());
            MessageBox.Show("Executing Query: " + debugQuery);
            cmd.ExecuteNonQuery();
        }
    }


    public void DeleteEntry(int selectedId, string selectedDatabankFilter, DataGridView dataGridView)
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

    public void insertMachineStatus(string machineNo, bool debug, int breakTime, string progStatus, string lastUpdate, string insertTime)
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

    // Example method to fetch the most recent entry's eventID and ProgStatus
    public (int eventID, string progStatus) FetchMostRecentEntry(string machineNr,DataGridView dataGridView)
    {
        // Variables to store the result
        int eventID = 0;
        string progStatus = string.Empty;

        // SQL Query to get the most recent eventID and ProgStatus
        string query = "SELECT eventID, ProgStatus " +
                       "FROM MachineStatus " +
                       "WHERE Machine = '" + machineNr + "'" +
                       "ORDER BY LastUpdate DESC " +
                       "OFFSET 0 ROWS FETCH FIRST 1 ROWS ONLY;";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            try
            {
                conn.Open();

                // Use SqlCommand to execute the query
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Execute the query and use SqlDataReader to get the result
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Read the values and store them in the variables
                            eventID = reader.GetInt32(0);        // eventID (assuming it's an int)
                            progStatus = reader.GetString(1);    // ProgStatus (assuming it's a string)

                            // Optionally, show in the console or messagebox
                            //Console.WriteLine($"EventID: {eventID}, ProgStatus: {progStatus}");
                            //MessageBox.Show($"Most recent EventID: {eventID}\nProgStatus: {progStatus}");
                        }
                    }
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

        // Optionally bind the result to a DataGridView (if you still need to display it)
        string displayQuery = "SELECT eventID, ProgStatus " +
                       "FROM MachineStatus " +
                       "WHERE Machine = '" + machineNr + "'" +
                       "ORDER BY LastUpdate DESC " +
                       "OFFSET 0 ROWS FETCH FIRST 1 ROWS ONLY;";
        // Display the result in DataGridView2
        ExecuteCustomQuery(displayQuery, dataGridView);

        return (eventID, progStatus);
    }




    // Apply special formatting - private since it is an class internal function
    private void dataGridViewSpecialFormat(DataGridView dataGridView)
    {
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
