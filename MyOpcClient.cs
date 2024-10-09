using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opc.Ua;
using Opc.Ua.Client;
using OpcUaHelper;
using Org.BouncyCastle.Crypto.Tls;

public class MyOpcClient
{
    private OpcUaClient _client;

    // Constructor to initialize the OpcUaClient
    public MyOpcClient()
    {
        _client = new OpcUaClient();
    }

    // Method to connect to the OPC UA server
    public bool Connect(string serverUrl)
    {
        try
        {
            // Attempt to connect to the server
            _client.ConnectServer(serverUrl);
            return _client.Connected; // Return the connection status
        }
        catch (Exception ex)
        {
            // Handle connection exceptions
            Console.WriteLine("Error connecting to OPC UA server: " + ex.Message);
            return false; // Return false if connection failed
        }
    }

    // Property to check if the client is connected
    public bool IsConnected
    {
        get
        {
            return _client != null && _client.Connected;
        }
    }

    // Optional: A method to disconnect from the server
    public void Disconnect()
    {
        if (_client.Connected)
        {
            _client.Disconnect();
        }
    }

    // Optional: A getter for the OpcUaClient instance if needed
    public OpcUaClient Client
    {
        get { return _client; }
    }



    // Asynchronous method for subscribing to a monitored item
    public async Task SubscribeAsync(string nodeId, TextBox txtValueOut)
    {
        OpcUaClient myClient = new OpcUaClient();

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
                (key, monitoredItem, ev) => SubCallback(key, monitoredItem, ev, txtValueOut)));



        }
        catch (Exception ex)
        {

            MessageBox.Show("Error subscription: " + ex.Message);
        }
    }

    // The callback to process the subscription updates asynchronously
    private async void SubCallback(string key, MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e, TextBox txtValueOut)
    {
        // Ensure thread-safe access to the UI thread
        if (txtValueOut.InvokeRequired)
        {
            // Use Task.Run to wrap the synchronous Invoke call and make it async-friendly
            //txtValueOut.Invoke(new Action<string, MonitoredItem, MonitoredItemNotificationEventArgs, TextBox>(SubCallback), key, monitoredItem, e, txtValueOut);
            // Use Invoke on the TextBox control to marshal the callback to the UI thread
            txtValueOut.Invoke(new Action(() => SubCallback(key, monitoredItem, e, txtValueOut)));
        }

        else
        {
            // Process the notification
            //MonitoredItemNotification notIf = e.NotificationValue as MonitoredItemNotification;
            // Check if the notification is valid and if there is a change
            //if (notIf != null)
            //{
            //    // Update txtOutput with the new value
            //    txtValueOut.Text = notIf.Value.WrappedValue.Value.ToString();

            //    // Update txtSameSince with the current system time
            //    //txtSameSinceProgStatus.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //}
            //else
            //{
            //    // If the signal has not changed, update txtUpdatedOn with the current system time
            //    //txtUpdatedOnProgStatus.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //}

            // This runs on the UI thread, so it's safe to update the TextBox directly
            txtValueOut.Text = e.NotificationValue.ToString(); // Assuming NotificationValue contains the data you want to display


            
        }

    }

}
