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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            txtServer = new TextBox();
            btnConnect = new Button();
            btnDisconnect = new Button();
            grpRW = new GroupBox();
            txtValueSub = new TextBox();
            btnSubscribe = new Button();
            txtItemSub = new TextBox();
            btnRead = new Button();
            btnWrite = new Button();
            txtWrite = new TextBox();
            label4 = new Label();
            txtValue = new TextBox();
            label3 = new Label();
            txtItem = new TextBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            label41 = new Label();
            cmbSelectedDatabankGeneral = new ComboBox();
            btnSaveSQLChanges = new Button();
            txtSystemTime = new TextBox();
            btnDeleteSQLEntry = new Button();
            btnReadAllSQLEntries = new Button();
            label46 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            label5 = new Label();
            lblComputerName = new Label();
            lblMachineNo = new Label();
            label8 = new Label();
            grpRW.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 0;
            label1.Text = "OPC UA Server:";
            // 
            // txtServer
            // 
            txtServer.Location = new Point(100, 16);
            txtServer.Name = "txtServer";
            txtServer.Size = new Size(366, 23);
            txtServer.TabIndex = 1;
            txtServer.Text = "opc.tcp://km-cad350:62640/IntegrationObjects/ServerSimulator";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(472, 16);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(94, 23);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(572, 16);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(96, 23);
            btnDisconnect.TabIndex = 3;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // grpRW
            // 
            grpRW.Controls.Add(txtValueSub);
            grpRW.Controls.Add(btnSubscribe);
            grpRW.Controls.Add(txtItemSub);
            grpRW.Controls.Add(btnRead);
            grpRW.Controls.Add(btnWrite);
            grpRW.Controls.Add(txtWrite);
            grpRW.Controls.Add(label4);
            grpRW.Controls.Add(txtValue);
            grpRW.Controls.Add(label3);
            grpRW.Controls.Add(txtItem);
            grpRW.Controls.Add(label2);
            grpRW.Location = new Point(12, 74);
            grpRW.Name = "grpRW";
            grpRW.Size = new Size(708, 103);
            grpRW.TabIndex = 4;
            grpRW.TabStop = false;
            grpRW.Text = "Read and Write";
            // 
            // txtValueSub
            // 
            txtValueSub.Location = new Point(368, 42);
            txtValueSub.Name = "txtValueSub";
            txtValueSub.Size = new Size(159, 23);
            txtValueSub.TabIndex = 13;
            // 
            // btnSubscribe
            // 
            btnSubscribe.Location = new Point(533, 13);
            btnSubscribe.Name = "btnSubscribe";
            btnSubscribe.Size = new Size(75, 23);
            btnSubscribe.TabIndex = 6;
            btnSubscribe.Text = "Subscribe";
            btnSubscribe.UseVisualStyleBackColor = true;
            btnSubscribe.Click += btnSubscribe_Click;
            // 
            // txtItemSub
            // 
            txtItemSub.Location = new Point(368, 13);
            txtItemSub.Name = "txtItemSub";
            txtItemSub.Size = new Size(159, 23);
            txtItemSub.TabIndex = 12;
            txtItemSub.Text = "ns=2;s=Tag14";
            // 
            // btnRead
            // 
            btnRead.Location = new Point(265, 13);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(75, 23);
            btnRead.TabIndex = 5;
            btnRead.Text = "Read";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += btnRead_Click;
            // 
            // btnWrite
            // 
            btnWrite.Location = new Point(265, 70);
            btnWrite.Name = "btnWrite";
            btnWrite.Size = new Size(75, 23);
            btnWrite.TabIndex = 7;
            btnWrite.Text = "Write";
            btnWrite.UseVisualStyleBackColor = true;
            btnWrite.Click += btnWrite_Click;
            // 
            // txtWrite
            // 
            txtWrite.Location = new Point(100, 70);
            txtWrite.Name = "txtWrite";
            txtWrite.Size = new Size(159, 23);
            txtWrite.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 73);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 9;
            label4.Text = "Write Value:";
            // 
            // txtValue
            // 
            txtValue.Location = new Point(100, 42);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(159, 23);
            txtValue.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 45);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 7;
            label3.Text = "Value:";
            // 
            // txtItem
            // 
            txtItem.Location = new Point(100, 13);
            txtItem.Name = "txtItem";
            txtItem.Size = new Size(159, 23);
            txtItem.TabIndex = 6;
            txtItem.Text = "ns=2;s=Tag11";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 16);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 5;
            label2.Text = "OPC Item:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtServer);
            groupBox1.Controls.Add(btnConnect);
            groupBox1.Controls.Add(btnDisconnect);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(708, 56);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Verbindung";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Controls.Add(label41);
            groupBox2.Controls.Add(cmbSelectedDatabankGeneral);
            groupBox2.Controls.Add(btnSaveSQLChanges);
            groupBox2.Controls.Add(txtSystemTime);
            groupBox2.Controls.Add(btnDeleteSQLEntry);
            groupBox2.Controls.Add(btnReadAllSQLEntries);
            groupBox2.Controls.Add(label46);
            groupBox2.Location = new Point(12, 183);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(991, 385);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(1, 46);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(983, 333);
            dataGridView1.TabIndex = 54;
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Location = new Point(212, 20);
            label41.Margin = new Padding(4, 0, 4, 0);
            label41.Name = "label41";
            label41.Size = new Size(64, 15);
            label41.TabIndex = 51;
            label41.Text = "Datenbank";
            // 
            // cmbSelectedDatabankGeneral
            // 
            cmbSelectedDatabankGeneral.FormattingEnabled = true;
            cmbSelectedDatabankGeneral.Location = new Point(289, 16);
            cmbSelectedDatabankGeneral.Margin = new Padding(4, 3, 4, 3);
            cmbSelectedDatabankGeneral.Name = "cmbSelectedDatabankGeneral";
            cmbSelectedDatabankGeneral.Size = new Size(140, 23);
            cmbSelectedDatabankGeneral.TabIndex = 50;
            // 
            // btnSaveSQLChanges
            // 
            btnSaveSQLChanges.Location = new Point(875, 15);
            btnSaveSQLChanges.Margin = new Padding(4, 3, 4, 3);
            btnSaveSQLChanges.Name = "btnSaveSQLChanges";
            btnSaveSQLChanges.Size = new Size(105, 27);
            btnSaveSQLChanges.TabIndex = 49;
            btnSaveSQLChanges.Text = "Save Changes";
            btnSaveSQLChanges.UseVisualStyleBackColor = true;
            btnSaveSQLChanges.Click += btnSaveSQLChanges_Click;
            // 
            // txtSystemTime
            // 
            txtSystemTime.Location = new Point(78, 15);
            txtSystemTime.Margin = new Padding(4, 3, 4, 3);
            txtSystemTime.Name = "txtSystemTime";
            txtSystemTime.ReadOnly = true;
            txtSystemTime.Size = new Size(122, 23);
            txtSystemTime.TabIndex = 48;
            // 
            // btnDeleteSQLEntry
            // 
            btnDeleteSQLEntry.Location = new Point(763, 15);
            btnDeleteSQLEntry.Margin = new Padding(4, 3, 4, 3);
            btnDeleteSQLEntry.Name = "btnDeleteSQLEntry";
            btnDeleteSQLEntry.Size = new Size(105, 27);
            btnDeleteSQLEntry.TabIndex = 47;
            btnDeleteSQLEntry.Text = "Delete Entry";
            btnDeleteSQLEntry.UseVisualStyleBackColor = true;
            btnDeleteSQLEntry.Click += btnDeleteSQLEntry_Click;
            // 
            // btnReadAllSQLEntries
            // 
            btnReadAllSQLEntries.Location = new Point(651, 15);
            btnReadAllSQLEntries.Margin = new Padding(4, 3, 4, 3);
            btnReadAllSQLEntries.Name = "btnReadAllSQLEntries";
            btnReadAllSQLEntries.Size = new Size(105, 27);
            btnReadAllSQLEntries.TabIndex = 46;
            btnReadAllSQLEntries.Text = "Read All Entries";
            btnReadAllSQLEntries.UseVisualStyleBackColor = true;
            btnReadAllSQLEntries.Click += btnReadAllSQLEntries_Click;
            // 
            // label46
            // 
            label46.AutoSize = true;
            label46.Location = new Point(7, 19);
            label46.Margin = new Padding(4, 0, 4, 0);
            label46.Name = "label46";
            label46.Size = new Size(71, 15);
            label46.TabIndex = 45;
            label46.Text = "SystemTime";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(817, 15);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 9;
            label5.Text = "Computer:";
            // 
            // lblComputerName
            // 
            lblComputerName.AutoSize = true;
            lblComputerName.Location = new Point(887, 15);
            lblComputerName.Name = "lblComputerName";
            lblComputerName.Size = new Size(109, 15);
            lblComputerName.TabIndex = 11;
            lblComputerName.Text = "<ComputerName>";
            // 
            // lblMachineNo
            // 
            lblMachineNo.AutoSize = true;
            lblMachineNo.Location = new Point(887, 36);
            lblMachineNo.Name = "lblMachineNo";
            lblMachineNo.Size = new Size(101, 15);
            lblMachineNo.TabIndex = 13;
            lblMachineNo.Text = "<MachineName>";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(817, 36);
            label8.Name = "label8";
            label8.Size = new Size(61, 15);
            label8.TabIndex = 12;
            label8.Text = "Maschine:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 580);
            Controls.Add(lblMachineNo);
            Controls.Add(label8);
            Controls.Add(lblComputerName);
            Controls.Add(label5);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(grpRW);
            Name = "Form1";
            Text = "Form1";
            grpRW.ResumeLayout(false);
            grpRW.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        private TextBox txtValueSub;
        private TextBox txtItemSub;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private Label label41;
        private ComboBox cmbSelectedDatabankGeneral;
        private Button btnSaveSQLChanges;
        private TextBox txtSystemTime;
        private Button btnDeleteSQLEntry;
        private Button btnReadAllSQLEntries;
        private Label label46;
        private System.Windows.Forms.Timer timer1;
        private Label label5;
        private Label lblComputerName;
        private Label lblMachineNo;
        private Label label8;
    }
}
