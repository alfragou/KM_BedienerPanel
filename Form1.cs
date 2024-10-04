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
                myClient.AddSubscription("A", txtItemSub.Text, SubCallback);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error subscription: " + ex.Message);
            }
        }

        private void SubCallback(string key, MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string, MonitoredItem, MonitoredItemNotificationEventArgs>(SubCallback), key, monitoredItem, e);
            }

            if (key == "A")
            {
                MonitoredItemNotification notIf = e.NotificationValue as MonitoredItemNotification;
                if (notIf != null)
                {
                    txtValueSub.Text = notIf.Value.WrappedValue.Value.ToString();
                }
            }

        }

    }
}
