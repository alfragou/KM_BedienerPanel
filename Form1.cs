//https://www.youtube.com/watch?v=A1xNi4quuk4
//https://github.com/OPCFoundation/UA-.NETStandard-Samples/tree/master/Samples/Client
//https://github.com/OPCFoundation/UA-.NETStandard-Samples/tree/master/Workshop/Views/Client
using Opc.Ua;
using Opc.Ua.Client;
using OpcUaHelper;
using System.Data;
using System.Timers; // For timer functionality
using System.Data.SqlClient;

namespace OPC_UA_Client
{
    public partial class Form1 : Form
    {

        private DataTable dataTable;  // To store data
        OpcUaClient myClient = new OpcUaClient();
        private string SQL_Queries_filePath;
        private string xmlFilePath;

        private MyXmlReader xmlReader;
        string connectionString; // now build from XML
        private string machineNo;
        private string commentReason = "Bitte begründen!";

        public Form1()
        {

            InitializeComponent();
            this.Load += Form1_Load; // Hook up the Load event
            myClient.UserIdentity = new UserIdentity(new AnonymousIdentityToken());


            // ComboBox Databanks - First entry appears first at the dropdown list
            string[] availableDatabanks = { "ProductionData", "MachineStatus" };
            for (int i = 0; i < availableDatabanks.Length; i++)
            {
                cmbSelectedDatabankGeneral.Items.Add(availableDatabanks[i]); // General - Fill Available Databanks 
            }

        }

        // In your Form constructor or Form_Load method, start the timer
        private void Form1_Load(object sender, EventArgs e)
        {
            btnDisconnect.Enabled = false;
            grpRW.Enabled = false;

            timer1.Start(); // UI clock timer for system time

            // Get the directory of the current executable
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // Combine the base directory with the file names
            SQL_Queries_filePath = Path.Combine(baseDirectory, "IniFiles\\SQL_Queries_Example.txt");
            xmlFilePath = Path.Combine(baseDirectory, "IniFiles\\cmachines_conf.xml");

            // Check if the file exists and load the data
            LoadXmlConfig();
        }

        private void LoadXmlConfig()
        {
            if (File.Exists(xmlFilePath))
            {
                // Read XML and build connectionString
                xmlReader = new MyXmlReader();  //instantiate
                string dataSource = MyXmlReader.ReadDataSource(xmlFilePath);
                int port = MyXmlReader.ReadPort(xmlFilePath);
                string initialCatalog = MyXmlReader.ReadInitialCatalog(xmlFilePath);
                string userID = MyXmlReader.ReadUserID(xmlFilePath);
                string password = MyXmlReader.ReadPassword(xmlFilePath);
                connectionString = @"Data Source=" + dataSource + "," + port + ";Initial Catalog=" + initialCatalog + ";User ID=" + userID + ";Password=" + password + ";"; // Using SQLExpress Remotely

                // Read XML and get url based on computername running the software
                string computerName = Environment.MachineName;
                lblComputerName.Text = computerName;    // update label
                txtServer.Text = MyXmlReader.GetAddressByComputerName(xmlFilePath, computerName);

                // Read XML and get machine based on computername running the software
                string machineNo = MyXmlReader.GetMachineNoByComputerName(xmlFilePath, computerName);
                string machineNoSuffix = "-001";
                if (machineNo.EndsWith(machineNoSuffix)) //if suffix found, remove it
                {
                    machineNo = machineNo.Substring(0, machineNo.Length - machineNoSuffix.Length);
                }
                lblMachineNo.Text = machineNo;  // update label 
            }
            else
            {
                MessageBox.Show("XML Config file not found.");
            }
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {

            try
            {
                myClient.ConnectServer(txtServer.Text);
                if (myClient.Connected)
                {
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                    grpRW.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error Connect! " + ex.ToString());
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            myClient.Disconnect();
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            grpRW.Enabled = false;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                //string val = myClient.ReadNode<string>(txtItem.Text); // doesnt work because node is Int16    
                //txtValue.Text = val;
                var val = myClient.ReadNode<object>(txtItem.Text);  // Use object to handle different data types
                txtValue.Text = val?.ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error reading node: " + ex.Message);
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            //myClient.WriteNode(txtItem.Text, txtWrite.Text); // doesnt work because node is Int16
            myClient.WriteNode(txtItem.Text, Convert.ToInt16(txtWrite.Text));
        }

        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            try
            {
                // Add a subscription to monitor the item specified in 'txtItemSub.Text'
                // 'A' is the key, and 'SubCallback' is the method to handle the notifications.
                // key is useful if you have multiple subscriptions and need to differentiate between them
                // SubCallback is the method that will be called whenever the subscribed item's value changes.
                myClient.AddSubscription("A", txtItemSub.Text, SubCallback);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error subscription: " + ex.Message);
            }
        }

        private void SubCallback(string key, MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            // If the method is called from a different thread, invoke it on the UI thread
            if (InvokeRequired)
            {
                Invoke(new Action<string, MonitoredItem, MonitoredItemNotificationEventArgs>(SubCallback), key, monitoredItem, e);
            }

            // Check if the notification corresponds to the subscription with key 'A'
            if (key == "A")
            {
                // Try to cast the notification event to MonitoredItemNotification
                MonitoredItemNotification notIf = e.NotificationValue as MonitoredItemNotification;
                // If the cast is successful, extract the value from the notification
                if (notIf != null)
                {
                    txtValueSub.Text = notIf.Value.WrappedValue.Value.ToString();
                }
            }

        }

        // Timer Tick event handler to update the time
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Update the TextBox with the current time
            txtSystemTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        #region SQL_Manual_Entries
        private void btnReadAllSQLEntries_Click(object sender, EventArgs e)
        {
            // Databank selection
            string selectedDatabankFilter = getDatabankGeneralSelection();
            if (selectedDatabankFilter == null) return;

            string query = "SELECT * FROM " + selectedDatabankFilter;
            //string query = "SELECT * FROM " + selectedDatabankFilter + " WHERE Machine = '" + machineNo + "'";

            //ExecuteCustomQuery(query, dataGridView1);
            ExecuteCustomQuery(query, dataGridView1);
        }

        private string getDatabankGeneralSelection()
        {
            string selectedDatabankFilter = null;
            if (cmbSelectedDatabankGeneral.SelectedIndex == -1) //if No selection
            {
                MessageBox.Show("Please select a GENERAL databank first", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                selectedDatabankFilter = cmbSelectedDatabankGeneral.SelectedItem.ToString();
            }
            return selectedDatabankFilter;
        }

        // A general method to execute SQL queries and bind the results to a DataGridView
        private void ExecuteCustomQuery(string query, DataGridView dataGridView)
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

        private void btnSaveSQLChanges_Click(object sender, EventArgs e)
        {
            // Databank selection
            string selectedDatabankFilter = getDatabankGeneralSelection();
            if (selectedDatabankFilter == null) return;

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
                            // Prepare Query
                            // ** InsertTime is missing
                            string productionDataMsg = "Machine = @Machine, ProgStatus = @ProgStatus, ProgPfadName = @ProgPfadName, LineContent = @LineContent, ToolIdent = @ToolIdent, Overrid = @Overrid, MFunktion = @MFunktion, OpMode = @OpMode, VorschubSpdl = @VorschubSpdl, Comment = @Comment WHERE EventID = @EventID";
                            string machineStatusMsg = "Machine = @Machine, ProgStatus = @ProgStatus, LastUpdate = @LastUpdate, Comment = @Comment WHERE EventID = @EventID";
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
                            SqlCommand cmd = new SqlCommand(query, conn, transaction);

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

                            cmd.ExecuteNonQuery();
                        }
                        // Check if the row is new (Added)
                        else if (row.RowState == DataRowState.Added)
                        {
                            // Prepare Query
                            string productionDataMsg = "Machine, ProgStatus, ProgPfadName, ToolIdent, LineContent, Overrid, InsertTime, MFunktion, OpMode, VorschubSpdl, Comment) VALUES(@Machine, @ProgStatus, @ProgPfadName, @LineContent, @ToolIdent, @Overrid, @MFunktion, @OpMode, @VorschubSpdl, @Comment @InsertTime";
                            string machineStatusMsg = "Machine, ProgStatus, LastUpdate, InsertTime, Comment";
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
                            SqlCommand cmd = new SqlCommand(query, conn, transaction);

                            // Add parameters for new data
                            cmd.Parameters.AddWithValue("@Machine", row["Machine"]);
                            cmd.Parameters.AddWithValue("@ProgStatus", row["ProgStatus"]);
                            cmd.Parameters.AddWithValue("@Comment", row["Comment"]);
                            // ** InsertTime is missing
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

                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Commit transaction
                    transaction.Commit();
                    MessageBox.Show("Changes saved successfully!");

                    // Accept changes in the DataTable
                    dataTable.AcceptChanges();
                }
                catch (Exception ex)
                {
                    // Rollback transaction in case of error
                    transaction.Rollback();
                    MessageBox.Show("Error saving changes: " + ex.Message);
                }
            }
        }
        #endregion

        private void btnDeleteSQLEntry_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Databank selection
                string selectedDatabankFilter = getDatabankGeneralSelection();
                if (selectedDatabankFilter == null) return;

                // Get the selected row's Id (assuming Id is the first column)
                //int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                // int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UserID"].Value); // Old SQL
                int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["EventID"].Value);

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
                        btnReadAllSQLEntries_Click(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }
    }
}
