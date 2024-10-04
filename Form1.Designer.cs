namespace OPC_UA_Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtServer = new TextBox();
            btnConnect = new Button();
            btnDisconnect = new Button();
            grpRW = new GroupBox();
            btnWrite = new Button();
            txtWrite = new TextBox();
            label4 = new Label();
            txtValue = new TextBox();
            label3 = new Label();
            txtItem = new TextBox();
            label2 = new Label();
            btnSubscribe = new Button();
            btnRead = new Button();
            grpRW.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 30);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 0;
            label1.Text = "OPC UA Server:";
            // 
            // txtServer
            // 
            txtServer.Location = new Point(110, 27);
            txtServer.Name = "txtServer";
            txtServer.Size = new Size(366, 23);
            txtServer.TabIndex = 1;
            txtServer.Text = "opc.tcp://km-cad350:62640/IntegrationObjects/ServerSimulator";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(124, 86);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(233, 86);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(75, 23);
            btnDisconnect.TabIndex = 3;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // grpRW
            // 
            grpRW.Controls.Add(btnWrite);
            grpRW.Controls.Add(txtWrite);
            grpRW.Controls.Add(label4);
            grpRW.Controls.Add(txtValue);
            grpRW.Controls.Add(label3);
            grpRW.Controls.Add(txtItem);
            grpRW.Controls.Add(label2);
            grpRW.Location = new Point(49, 154);
            grpRW.Name = "grpRW";
            grpRW.Size = new Size(558, 284);
            grpRW.TabIndex = 4;
            grpRW.TabStop = false;
            grpRW.Text = "Read and Write";
            // 
            // btnWrite
            // 
            btnWrite.Location = new Point(100, 203);
            btnWrite.Name = "btnWrite";
            btnWrite.Size = new Size(75, 23);
            btnWrite.TabIndex = 7;
            btnWrite.Text = "Write";
            btnWrite.UseVisualStyleBackColor = true;
            btnWrite.Click += btnWrite_Click;
            // 
            // txtWrite
            // 
            txtWrite.Location = new Point(100, 160);
            txtWrite.Name = "txtWrite";
            txtWrite.Size = new Size(366, 23);
            txtWrite.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 163);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 9;
            label4.Text = "Write Value:";
            // 
            // txtValue
            // 
            txtValue.Location = new Point(100, 89);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(366, 23);
            txtValue.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 92);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 7;
            label3.Text = "Value:";
            // 
            // txtItem
            // 
            txtItem.Location = new Point(100, 29);
            txtItem.Name = "txtItem";
            txtItem.Size = new Size(366, 23);
            txtItem.TabIndex = 6;
            txtItem.Text = "ns=2;s=Tag11";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 32);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 5;
            label2.Text = "OPC Item:";
            // 
            // btnSubscribe
            // 
            btnSubscribe.Location = new Point(417, 214);
            btnSubscribe.Name = "btnSubscribe";
            btnSubscribe.Size = new Size(75, 23);
            btnSubscribe.TabIndex = 6;
            btnSubscribe.Text = "Subscribe";
            btnSubscribe.UseVisualStyleBackColor = true;
            btnSubscribe.Click += btnSubscribe_Click;
            // 
            // btnRead
            // 
            btnRead.Location = new Point(308, 214);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(75, 23);
            btnRead.TabIndex = 5;
            btnRead.Text = "Read";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += btnRead_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSubscribe);
            Controls.Add(btnRead);
            Controls.Add(grpRW);
            Controls.Add(btnDisconnect);
            Controls.Add(btnConnect);
            Controls.Add(txtServer);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            grpRW.ResumeLayout(false);
            grpRW.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtServer;
        private Button btnConnect;
        private Button btnDisconnect;
        private GroupBox grpRW;
        private Button btnWrite;
        private TextBox txtWrite;
        private Label label4;
        private TextBox txtValue;
        private Label label3;
        private TextBox txtItem;
        private Label label2;
        private Button btnSubscribe;
        private Button btnRead;
    }
}
