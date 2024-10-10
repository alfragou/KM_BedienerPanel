using System;
using System.Windows.Forms;
using OPC_UA_Client; // Assuming the namespace of PopUpForm is OPC_UA_Client

public class NonBlockingMessage
{
    private System.Windows.Forms.Timer updateTimer;
    private PopUpForm popUpForm;

    // Define an event that will be triggered when the pop-up form is closed
    public event EventHandler PopUpClosed;

    public NonBlockingMessage()
    {
        popUpForm = new PopUpForm();
        updateTimer = new System.Windows.Forms.Timer();
        updateTimer.Interval = 1000; // 1 second interval for updates
        updateTimer.Tick += UpdateDeltaTime;

        // Subscribe to the form's Closed event to trigger PopUpClosed
        popUpForm.FormClosed += (sender, e) => OnPopUpClosed();
    }

    public void Show()
    {
        //updateTimer.Start();
        //popUpForm.Show(); // Non-blocking display of the form

        updateTimer.Start();
        popUpForm.ShowDialog(); // Blocks until the form is closed
        string userInput = popUpForm.GetUserInput(); // Get the input after the form closes
        MessageBox.Show("Begründung: " + userInput); // Do something with the user input
    }

    private void UpdateDeltaTime(object sender, EventArgs e)
    {
        TimeSpan deltaProgStatus = GetDeltaProgStatus(); // Your logic to get updated deltaTime
        popUpForm.UpdateDeltaTime(deltaProgStatus.TotalMilliseconds.ToString()); // Time in milliseconds
        //popUpForm.UpdateDeltaTime(deltaProgStatus.ToString(@"hh\:mm\:ss")); // Format the time as a string in HH:MM:SS format
    }

    private TimeSpan GetDeltaProgStatus()
    {
        DateTime startTime = DateTime.Now.AddSeconds(-30); // Mock data for testing
        return DateTime.Now - startTime;
    }

    // Event invocator method to raise the PopUpClosed event
    protected virtual void OnPopUpClosed()
    {
        // Raise the event if there are any subscribers
        PopUpClosed?.Invoke(this, EventArgs.Empty);
    }
}
