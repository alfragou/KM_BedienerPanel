using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPC_UA_Client
{
    public partial class PopUpForm : Form
    {
        public PopUpForm()
        {
            InitializeComponent();
        }

        // Method to update the delta time label
        public void UpdateDeltaTime(string deltaTime)
        {
            lblDeltaTime.Text = "Delta Time: " + deltaTime;
        }

        public string GetUserInput()
        {
            return txtReasoning.Text; // Returns the user's input from the TextBox
        }

        private void btnSubmitReasoning_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form when the button is clicked
        }

        private void btnWaitForCrane_Click(object sender, EventArgs e)
        {
            txtReasoning.Text = "Warten auf Kran";
            this.Close(); // Close the form when the button is clicked

        }

        private void btnShiftChange_Click(object sender, EventArgs e)
        {
            txtReasoning.Text = "Schichtwechsel";
            this.Close(); // Close the form when the button is clicked

        }
    } // End of class
} // End of namespace
