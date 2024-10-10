//https://www.youtube.com/watch?v=A1xNi4quuk4
//https://github.com/OPCFoundation/UA-.NETStandard-Samples/tree/master/Samples/Client
//https://github.com/OPCFoundation/UA-.NETStandard-Samples/tree/master/Workshop/Views/Client

using Opc.Ua;
using Opc.Ua.Client;
using OpcUaHelper;
using System.Data;
using System.Timers; // For timer functionality
using System.Data.SqlClient;
using System.Threading.Tasks;
using static Org.BouncyCastle.Math.Primes;
using MyTimeNamespace;
using System.Data.Common; //my class for time functions

namespace OPC_UA_Client
{
    public partial class Form1 : Form
    {

        // Create library instances
        OpcUaClient myClient = new OpcUaClient();
        MyTime myTime = new MyTime();
        private MySQL mySQL; // similar to MySQL mySQL = new MySQL() but without constructor argument
        MyGUI myGUI = new MyGUI();
        private MyOpcClient myOpcClient;  // Declare MyOpcClient as a field


        private DataTable dataTable;  // To store data

        private string SQL_Queries_filePath;
        private string xmlFilePath;

        private System.Timers.Timer opcTimerMStatus;  // Timer for periodic OPC UA reading with Explicit reference to System.Timers.Timer 
        private int cycleTime = 3000;  // Stores the cycle time

        private MyXmlReader xmlReader;
        string connectionString; // now build from XML
        private string machineNo;

        private string oldProgStatus = string.Empty; // A field to store the old program status
        private string LogMsg = string.Empty; // To store Log Messages

        public Form1()
        {

            InitializeComponent();
            txtValueProgStatus.TextChanged += txtValueProgStatus_TextChanged; // Subscribing to the Prog Status TextChanged event
            this.Load += Form1_Load; // Hook up the Load event
            myClient.UserIdentity = new UserIdentity(new AnonymousIdentityToken());

            txtCycleTimeMStatus.Text = cycleTime.ToString();

            // Initialize the Timer, but do not start it yet
            opcTimerMStatus = new System.Timers.Timer();
            opcTimerMStatus.Elapsed += OpcTimerMStatus_Elapsed;

            InitializeComboBoxes();

            // Create a DataTable with sample data
            dataTable = new DataTable();
            // Bind the DataGridView to the DataTable
            dataGridView1.DataSource = dataTable;

            // Get the directory of the current executable
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // Combine the base directory with the file names
            SQL_Queries_filePath = Path.Combine(baseDirectory, "IniFiles\\SQL_Queries_Example.txt");
            xmlFilePath = Path.Combine(baseDirectory, "IniFiles\\cmachines_conf.xml");

            // Check if the file exists and load the data
            LoadXmlConfig();

            // Initialize MyOpcClient
            myOpcClient = new MyOpcClient();
            mySQL = new MySQL(connectionString);

        }

        

    private void InitializeComboBoxes()
    {
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
            grpMachineStatus.Enabled = false;

            timer1.Start(); // UI clock timer for system time

            
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

                string serverURL = txtServer.Text;
                myClient.ConnectServer(serverURL);
                if (myClient.Connected)
                //if (myOpcClient.Connect(serverURL))
                {
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                    grpRW.Enabled = true;
                    grpMachineStatus.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error Connect! " + ex.ToString());
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            myOpcClient.Disconnect();
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            grpRW.Enabled = false;
            grpMachineStatus.Enabled = false;
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


        // The button click event that triggers the subscription
        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            // Pass the specific TextBox controls for input and output
            SubscribeAsync(txtItemSub.Text, txtValueSub); // For one pair
            //Subscribe(txtItemSub2, txtValueSub2); // For another pair
        }

        // Asynchronous method for subscribing to a monitored item
        private async Task SubscribeAsync(string nodeId, TextBox txtOutput)
        {
            try
            {
                // Add a subscription to monitor the item specified in 'txtItemSub.Text'
                // 'A' is the key, and 'SubCallback' is the method to handle the notifications.
                // key is useful if you have multiple subscriptions and need to differentiate between them
                // SubCallback is the method that will be called whenever the subscribed item's value changes.
                // myClient.AddSubscription("A", txtItemSub.Text, SubCallback); // working but with fixed textboxes

                // Add a subscription with a unique key for each TextBox combination
                string subscriptionKey = Guid.NewGuid().ToString(); // Unique key per subscription
                                                                    // Add the subscription asynchronously using awaitable methods



                await Task.Run(() =>
                    myClient.AddSubscription(subscriptionKey, nodeId,
                    (key, monitoredItem, ev) => SubCallback(key, monitoredItem, ev, txtOutput)));



            }
            catch (Exception ex)
            {

                MessageBox.Show("Error subscription: " + ex.Message);
            }
        }





        private void OnSubscriptionCompleted()
        {
            // This method is called when the subscription task finishes
            // Update the UI or log the completion
            txtUpdatedOnProgStatus.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        // The callback to process the subscription updates asynchronously
        private async void SubCallback(string key, MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e, TextBox txtOutput)
        {
            // Ensure thread-safe access to the UI thread
            if (InvokeRequired)
            {
                // Use Task.Run to wrap the synchronous Invoke call and make it async-friendly
                Invoke(new Action<string, MonitoredItem, MonitoredItemNotificationEventArgs, TextBox>(SubCallback), key, monitoredItem, e, txtOutput);
            }

            else
            {
                // Process the notification
                MonitoredItemNotification notIf = e.NotificationValue as MonitoredItemNotification;
                // Check if the notification is valid and if there is a change
                if (notIf != null)
                {
                    // Update txtOutput with the new value
                    txtOutput.Text = notIf.Value.WrappedValue.Value.ToString();

                    // Update txtSameSince with the current system time
                    txtSameSinceProgStatus.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    // If the signal has not changed, update txtUpdatedOn with the current system time
                    txtUpdatedOnProgStatus.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }

        }

        // Timer Tick event handler to update the time
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Update the TextBox with the current time
            string timeNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtSystemTime.Text = timeNow;
            txtUpdatedOnProgStatus.Text = timeNow;

            // CalculateDelta
            if (txtSameSinceProgStatus.Text != "") txtDeltaTimeProgStatus.Text = myTime.CalculateTimeDifference(txtSameSinceProgStatus.Text, timeNow);
            if (txtSameSincePoti.Text != "") txtDeltaTimePoti.Text = myTime.CalculateTimeDifference(txtSameSincePoti.Text, timeNow);
        }





        #region SQL_Manual_Entries
        private void btnReadAllSQLEntries_Click(object sender, EventArgs e)
        {
            // Databank selection
            string selectedTable = GetSelectedTable(); // Create a method to choose the table
            if (string.IsNullOrEmpty(selectedTable))
            {
                MessageBox.Show("Please select a table.");
                PostLogMessage(MyLog.MessageType.Error, "Please select a table.");
                return;
            }

            string query = "SELECT * FROM " + selectedTable;
            //string query = "SELECT * FROM " + selectedTable + " WHERE Machine = '" + machineNo + "'";

            //ExecuteCustomQuery(query, dataGridView1);
            //mySQL.ExecuteCustomQuery(query, dataGridView1);
            dataTable = mySQL.LoadData(selectedTable, dataGridView1);
            dataGridView1.DataSource = dataTable;
        }

        private string GetSelectedTable()
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



        private void btnSaveSQLChanges_Click(object sender, EventArgs e)
        {
            // Databank selection
            string selectedTable = GetSelectedTable(); // Create a method to choose the table
            if (string.IsNullOrEmpty(selectedTable))
            {
                MessageBox.Show("Please select a table.");
                return;
            }

            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No data to save.");
                return;
            }

            mySQL.SaveData(dataTable,selectedTable);
        }
            #endregion

            private void btnDeleteSQLEntry_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Databank selection
                string selectedDatabankFilter = GetSelectedTable();
                if (selectedDatabankFilter == null) return;

                // Get the selected row's Id (assuming Id is the first column)
                //int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                // int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UserID"].Value); // Old SQL
                int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["EventID"].Value);

                mySQL.DeleteEntry(selectedId, selectedDatabankFilter, dataGridView1);
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private async void btnWriteMStatus_Start_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtCycleTimeMStatus.Text, out cycleTime) && cycleTime > 0)
                {
                    //updateChangeSinceTextBox(); // Update TextBox with systemTime
                    //opcTimerMStatus.Interval = cycleTime;  // Set the interval based on cycle time input
                    //opcTimerMStatus.Start();  // Start the timer to repeatedly fetch OPC data
                    btnWriteMStatus_Start.Enabled = false;  // Disable the Start button while running
                    btnWriteMStatus_Stop.Enabled = true;  // Enable Stop button

                    string nodeID_progStatus = "ns=2;s=Tag11";
                    string nodeID_poti = "ns=2;s=Tag12";

                    await SubscribeAsync(txtItemSub.Text, txtValueSub);
                    await SubscribeAsync(nodeID_progStatus, txtValueProgStatus); // For one pair
                    await SubscribeAsync(nodeID_poti, txtValuePoti); // For one pair

                }
                else
                {
                    MessageBox.Show("Please enter a valid cycle time (milliseconds).");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void updateChangeSinceTextBox()
        {
            // Action for all textboxes that start with txtSameSince within groupBox3
            foreach (Control control in grpMachineStatus.Controls)
            {
                if (control is TextBox textBox && control.Name.StartsWith("txtSameSince"))
                {
                    textBox.Text = txtSystemTime.Text;
                }
            }
        }

        private async void OpcTimerMStatus_Elapsed(object sender, ElapsedEventArgs e)
        {
            //await ReadOpcDataFromMultipleEndpointsAsync();
        }

        // Async method to read OPC data from multiple endpoints and update TextBoxes
        private async Task ReadOpcDataFromMultipleEndpointsAsync()
        {
            try
            {
                SubscribeAsync(txtItemProgStatus.Text, txtValueProgStatus); // For one pair
                SubscribeAsync(txtItemPoti.Text, txtValuePoti); // For one pair
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void btnWriteMStatus_Stop_Click(object sender, EventArgs e)
        {
            opcTimerMStatus.Stop();  // Stop the timer
            btnWriteMStatus_Start.Enabled = true;  // Enable Start button
            btnWriteMStatus_Stop.Enabled = false;  // Disable Stop button

            // Clear fields
            DialogResult result = MessageBox.Show("Do you want to clear the fields?", "Clear Fields", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Action for all textboxes with groupBox3
                foreach (Control control in grpMachineStatus.Controls)
                {
                    if (control is TextBox textBox)
                    {
                        textBox.Clear();
                        textBox.BackColor = Color.White;
                    }
                }
            }
        }

        private void btnSendQuery_Click(object sender, EventArgs e)
        {
            //For example 
            //SELECT * FROM MachineStatus WHERE InsertTime >= '2024-09-20T00:00:00'
            //SELECT * FROM MachineStatus WHERE Machine = '4803'                   // Machine is 4803
            //SELECT * FROM MachineStatus WHERE Machine LIKE '%4%0%'              // FirstName is 4*0*
            //SELECT DISTINCT Machine FROM MachineStatus ORDER BY Machine       // Unique First Names

            string query = txtQuery.Text; // Get the query from the txtQuery TextBox

            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Please enter a valid SQL query.", "Invalid Query", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Execute the custom query and display results in dataGridView1
            mySQL.ExecuteCustomQuery(query, dataGridView1);
        }

        private void btnInsertToMachineStatusSQL_Click(object sender, EventArgs e)
        {
            insertSQL();
        }

        private void txtValueProgStatus_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string progStatus = txtValueProgStatus.Text;
            // Attention - For a reason, after every change, TextChanged runs twice
            if (oldProgStatus == string.Empty) // to avoid the first run
            {
                // Update the old text after processing
                oldProgStatus = progStatus;
            }
            // Detect ProgStatus Value Change
            else if  (oldProgStatus != progStatus) { 
                // Process the new text here
                // Optionally, show the old text and new text
                LogMsg = $"Old Text: {oldProgStatus} - New Text: {progStatus}";
                //MessageBox.Show(LogMsg);
                PostLogMessage(MyLog.MessageType.Info, LogMsg);


                // Change appearance according to value
                (txtValueProgStatus.BackColor, lblProgStatus.ForeColor, lblProgStatus.Text) = myGUI.AppearanceFromValue(progStatus, txtValueProgStatus, lblProgStatus);

                if (chkMachineStatus_Add2SQL.Checked) 
                {
                    string machineNr = lblMachineNo.Text;
                    // Returns eventID and ProgStatus of most recent entry for this machine
                    (int eventID, string progStatusSQL) = mySQL.FetchMostRecentEntry(machineNr, dataGridView1); //deconstruct results
                    PostLogMessage(MyLog.MessageType.SQLInfo, $"Most recent EventID: {eventID} - ProgStatus: {progStatus}");

                    //insertSQL(); 
                    //mySQL.insertMachineStatus(lblMachineNo.Text, false, int.Parse(txtIgnoneBreaksTime.Text),
                    //txtValueProgStatus.Text, txtUpdatedOnProgStatus.Text, txtSameSinceProgStatus.Text);

                    // STEP 4 - Compare sql ProgStatus with current ProgStatus
                    // if different update time at last sql and add new entry 
                    // UPDATE MachineStatus Entry
                    // UPDATE MachineStatus SET LastUpdate = '2024-09-30T16:21:19' WHERE eventID = 15
                    // Update Time
                    string timeLastEntry = txtSameSinceProgStatus.Text;
                    string updateTimeLastEntryQuery = "UPDATE MachineStatus SET LastUpdate = '" + MyTime.convertTimeForSQL(timeLastEntry) + "' WHERE eventID =" + eventID;
                    mySQL.ExecuteCustomQuery(updateTimeLastEntryQuery, dataGridView1);
                    PostLogMessage(MyLog.MessageType.SQLChange, $"EventID: {eventID} - LastUpdate: {timeLastEntry}");


                    if (progStatusSQL != progStatus)
                    {
                        string timeNewEntry = txtUpdatedOnProgStatus.Text;
                        // Add new SQL entry - insertMachineStatus converts TextTime to TextTimeForSQL
                       mySQL.insertMachineStatus(machineNr, true, int.Parse(txtIgnoneBreaksTime.Text), progStatus, timeNewEntry, timeLastEntry);
                        PostLogMessage(MyLog.MessageType.SQLEntry, $"Machine:{machineNr} - ProgStatus:{progStatus} - LastUpdate: {timeNewEntry} - InsertTime:{timeLastEntry}");
                    }
                    txtSameSinceProgStatus.Text = txtUpdatedOnProgStatus.Text; // UpdateTime Now

                }

                // Update view after change
                if (chkMachineStatus_ReadSQLAfterChanges.Checked)
                {
                    // Read and display SQL data in DataGridView1
                    string query = "SELECT * FROM " + "MachineStatus";
                    mySQL.ExecuteCustomQuery(query, dataGridView1);
                }
                // Update the old text after processing
                oldProgStatus = progStatus;
            }

        }

        // Create sql entry from textboxes
        private void insertSQL() 
        {
            mySQL.insertMachineStatus(lblMachineNo.Text, false, int.Parse(txtIgnoneBreaksTime.Text),
                 txtValueProgStatus.Text, txtUpdatedOnProgStatus.Text, txtSameSinceProgStatus.Text);
        }

        public void PostLogMessage(MyLog.MessageType type, string msg)
        {
            MyLog.PostLogMessage(rtxLog,type, msg);
        }

    }
}
