using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPC_UA_Client
{
    public class MyGUI
    {
        public (Color, Color, String) AppearanceFromValue(string progStatus, TextBox box, Label label)
        {
            Color textboxColor = Color.Empty;
            Color labelColor = Color.Empty;
            string statusText = string.Empty;   

            switch (progStatus)
            {
                case "1":
                    statusText  = "Unterbrochen";
                    labelColor = Color.Red;
                    textboxColor = Color.Red;
                    break;
                case "2":
                    statusText  = "Angehalten";
                    labelColor = Color.Red;
                    textboxColor = Color.Red;
                    break;
                case "3":
                    statusText  = "Laüft";
                    labelColor = Color.Green;
                    textboxColor = Color.Green;
                    break;
                case "4":
                    statusText  = "Wartend";
                    labelColor = Color.Red;
                    textboxColor = Color.Red;
                    break;
                case "5":
                    statusText  = "Abgebrochen";
                    labelColor = Color.Red;
                    textboxColor = Color.Red;
                    break;
            }

            return (textboxColor, labelColor, statusText);  
        }
    } // End of class
} // End of namespace
