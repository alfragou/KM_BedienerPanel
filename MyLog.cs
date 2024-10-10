using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class MyLog
{
    // Post Log Messages at RichTextBox
    public static void PostLogMessage(RichTextBox richTextBox, MessageType type, string message)
    {
        // Get the current timestamp
        string timestamp = DateTime.Now.ToString("HH:mm:ss");

        // Create the formatted message with timestamp
        string formattedMessage = $"{timestamp} - [{type}] {message}";

        // Insert the message at the beginning of the RichTextBox
        richTextBox.Text = formattedMessage + Environment.NewLine + richTextBox.Text;

        // Scroll to the beginning to show the newest message
        richTextBox.ScrollToCaret();
    }

    // Enum types to be used 
    public enum MessageType
    {
        Error,
        Info,
        SQLChange,
        SQLInfo,
        SQLEntry
    }

} // End of class
