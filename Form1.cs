//https://www.youtube.com/watch?v=A1xNi4quuk4
//https://github.com/OPCFoundation/UA-.NETStandard-Samples/tree/master/Samples/Client
//https://github.com/OPCFoundation/UA-.NETStandard-Samples/tree/master/Workshop/Views/Client
using Opc.Ua;
using Opc.Ua.Client;
using OpcUaHelper;

namespace OPC_UA_Client
{
    public partial class Form1 : Form
    {
        OpcUaClient myClient = new OpcUaClient();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load; // Hook up the Load event
            myClient.UserIdentity = new UserIdentity(new AnonymousIdentityToken());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnDisconnect.Enabled = false;
            grpRW.Enabled = false;

            string computerName = Environment.MachineName;
            if (computerName == "CMP06507") txtServer.Text = "opc.tcp://cmp06507:62640/IntegrationObjects/ServerSimulator";
            else if (computerName == "KM-CAD350") txtServer.Text = "opc.tcp://km-cad350:62640/IntegrationObjects/ServerSimulator";

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

    }
}
