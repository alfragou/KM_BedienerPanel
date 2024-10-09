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
            grpMachineStatus = new GroupBox();
            lblProgStatus = new Label();
            txtDeltaTimePoti = new TextBox();
            txtUpdatedOnPoti = new TextBox();
            txtSameSincePoti = new TextBox();
            label9 = new Label();
            label7 = new Label();
            txtItemPoti = new TextBox();
            label6 = new Label();
            txtItemProgStatus = new TextBox();
            label42 = new Label();
            txtIgnoneBreaksTime = new TextBox();
            label45 = new Label();
            chkMachineStatus_ReadSQLAfterChanges = new CheckBox();
            chkMachineStatus_Add2SQL = new CheckBox();
            label33 = new Label();
            txtCycleTimeMStatus = new TextBox();
            label32 = new Label();
            btnWriteMStatus_Stop = new Button();
            btnWriteMStatus_Start = new Button();
            label39 = new Label();
            txtDeltaTimeProgStatus = new TextBox();
            txtUpdatedOnProgStatus = new TextBox();
            label37 = new Label();
            label30 = new Label();
            txtSameSinceProgStatus = new TextBox();
            label31 = new Label();
            txtValueProgStatus = new TextBox();
            txtValuePoti = new TextBox();
            label34 = new Label();
            label10 = new Label();
            label11 = new Label();
            textBox7 = new TextBox();
            label12 = new Label();
            textBox8 = new TextBox();
            label13 = new Label();
            textBox9 = new TextBox();
            label14 = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            label15 = new Label();
            textBox10 = new TextBox();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            txtQuery = new TextBox();
            btnSendQuery = new Button();
            btnInsertToMachineStatusSQL = new Button();
            grpRW.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            grpMachineStatus.SuspendLayout();
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
            grpRW.Location = new Point(538, 74);
            grpRW.Name = "grpRW";
            grpRW.Size = new Size(512, 103);
            grpRW.TabIndex = 4;
            grpRW.TabStop = false;
            grpRW.Text = "Read and Write";
            // 
            // txtValueSub
            // 
            txtValueSub.Location = new Point(296, 42);
            txtValueSub.Name = "txtValueSub";
            txtValueSub.Size = new Size(130, 23);
            txtValueSub.TabIndex = 13;
            // 
            // btnSubscribe
            // 
            btnSubscribe.Location = new Point(429, 13);
            btnSubscribe.Name = "btnSubscribe";
            btnSubscribe.Size = new Size(75, 23);
            btnSubscribe.TabIndex = 6;
            btnSubscribe.Text = "Subscribe";
            btnSubscribe.UseVisualStyleBackColor = true;
            btnSubscribe.Click += btnSubscribe_Click;
            // 
            // txtItemSub
            // 
            txtItemSub.Location = new Point(296, 13);
            txtItemSub.Name = "txtItemSub";
            txtItemSub.Size = new Size(130, 23);
            txtItemSub.TabIndex = 12;
            txtItemSub.Text = "ns=2;s=Tag11";
            // 
            // btnRead
            // 
            btnRead.Location = new Point(215, 13);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(75, 23);
            btnRead.TabIndex = 5;
            btnRead.Text = "Read";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += btnRead_Click;
            // 
            // btnWrite
            // 
            btnWrite.Location = new Point(215, 70);
            btnWrite.Name = "btnWrite";
            btnWrite.Size = new Size(75, 23);
            btnWrite.TabIndex = 7;
            btnWrite.Text = "Write";
            btnWrite.UseVisualStyleBackColor = true;
            btnWrite.Click += btnWrite_Click;
            // 
            // txtWrite
            // 
            txtWrite.Location = new Point(79, 70);
            txtWrite.Name = "txtWrite";
            txtWrite.Size = new Size(130, 23);
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
            txtValue.Location = new Point(79, 42);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(130, 23);
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
            txtItem.Location = new Point(79, 13);
            txtItem.Name = "txtItem";
            txtItem.Size = new Size(130, 23);
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
            groupBox2.Location = new Point(12, 321);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(991, 265);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(8, 48);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(983, 204);
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
            // grpMachineStatus
            // 
            grpMachineStatus.Controls.Add(lblProgStatus);
            grpMachineStatus.Controls.Add(txtDeltaTimePoti);
            grpMachineStatus.Controls.Add(txtUpdatedOnPoti);
            grpMachineStatus.Controls.Add(txtSameSincePoti);
            grpMachineStatus.Controls.Add(label9);
            grpMachineStatus.Controls.Add(label7);
            grpMachineStatus.Controls.Add(txtItemPoti);
            grpMachineStatus.Controls.Add(label6);
            grpMachineStatus.Controls.Add(txtItemProgStatus);
            grpMachineStatus.Controls.Add(label42);
            grpMachineStatus.Controls.Add(txtIgnoneBreaksTime);
            grpMachineStatus.Controls.Add(label45);
            grpMachineStatus.Controls.Add(chkMachineStatus_ReadSQLAfterChanges);
            grpMachineStatus.Controls.Add(chkMachineStatus_Add2SQL);
            grpMachineStatus.Controls.Add(label33);
            grpMachineStatus.Controls.Add(txtCycleTimeMStatus);
            grpMachineStatus.Controls.Add(label32);
            grpMachineStatus.Controls.Add(btnWriteMStatus_Stop);
            grpMachineStatus.Controls.Add(btnWriteMStatus_Start);
            grpMachineStatus.Controls.Add(label39);
            grpMachineStatus.Controls.Add(txtDeltaTimeProgStatus);
            grpMachineStatus.Controls.Add(txtUpdatedOnProgStatus);
            grpMachineStatus.Controls.Add(label37);
            grpMachineStatus.Controls.Add(label30);
            grpMachineStatus.Controls.Add(txtSameSinceProgStatus);
            grpMachineStatus.Controls.Add(label31);
            grpMachineStatus.Controls.Add(txtValueProgStatus);
            grpMachineStatus.Controls.Add(txtValuePoti);
            grpMachineStatus.Location = new Point(12, 74);
            grpMachineStatus.Name = "grpMachineStatus";
            grpMachineStatus.Size = new Size(520, 211);
            grpMachineStatus.TabIndex = 14;
            grpMachineStatus.TabStop = false;
            grpMachineStatus.Text = "Maschine Status";
            // 
            // lblProgStatus
            // 
            lblProgStatus.AutoSize = true;
            lblProgStatus.Location = new Point(56, 48);
            lblProgStatus.Margin = new Padding(4, 0, 4, 0);
            lblProgStatus.Name = "lblProgStatus";
            lblProgStatus.Size = new Size(37, 15);
            lblProgStatus.TabIndex = 71;
            lblProgStatus.Text = "Stand";
            lblProgStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDeltaTimePoti
            // 
            txtDeltaTimePoti.Location = new Point(391, 100);
            txtDeltaTimePoti.Margin = new Padding(4, 3, 4, 3);
            txtDeltaTimePoti.Name = "txtDeltaTimePoti";
            txtDeltaTimePoti.Size = new Size(122, 23);
            txtDeltaTimePoti.TabIndex = 70;
            // 
            // txtUpdatedOnPoti
            // 
            txtUpdatedOnPoti.Location = new Point(128, 102);
            txtUpdatedOnPoti.Margin = new Padding(4, 3, 4, 3);
            txtUpdatedOnPoti.Name = "txtUpdatedOnPoti";
            txtUpdatedOnPoti.Size = new Size(122, 23);
            txtUpdatedOnPoti.TabIndex = 67;
            // 
            // txtSameSincePoti
            // 
            txtSameSincePoti.Location = new Point(264, 100);
            txtSameSincePoti.Margin = new Padding(4, 3, 4, 3);
            txtSameSincePoti.Name = "txtSameSincePoti";
            txtSameSincePoti.Size = new Size(122, 23);
            txtSameSincePoti.TabIndex = 66;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(10, 110);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(28, 15);
            label9.TabIndex = 63;
            label9.Text = "Poti";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(219, 25);
            label7.Name = "label7";
            label7.Size = new Size(28, 15);
            label7.TabIndex = 61;
            label7.Text = "Poti";
            // 
            // txtItemPoti
            // 
            txtItemPoti.Location = new Point(289, 22);
            txtItemPoti.Name = "txtItemPoti";
            txtItemPoti.Size = new Size(130, 23);
            txtItemPoti.TabIndex = 60;
            txtItemPoti.Text = "ns=2;s=Tag12";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 25);
            label6.Name = "label6";
            label6.Size = new Size(64, 15);
            label6.TabIndex = 59;
            label6.Text = "ProgStatus";
            // 
            // txtItemProgStatus
            // 
            txtItemProgStatus.Location = new Point(78, 22);
            txtItemProgStatus.Name = "txtItemProgStatus";
            txtItemProgStatus.Size = new Size(130, 23);
            txtItemProgStatus.TabIndex = 58;
            txtItemProgStatus.Text = "ns=2;s=Tag11";
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Location = new Point(465, 174);
            label42.Margin = new Padding(4, 0, 4, 0);
            label42.Name = "label42";
            label42.Size = new Size(24, 15);
            label42.TabIndex = 57;
            label42.Text = "sec";
            // 
            // txtIgnoneBreaksTime
            // 
            txtIgnoneBreaksTime.Location = new Point(341, 170);
            txtIgnoneBreaksTime.Margin = new Padding(4, 3, 4, 3);
            txtIgnoneBreaksTime.Name = "txtIgnoneBreaksTime";
            txtIgnoneBreaksTime.Size = new Size(116, 23);
            txtIgnoneBreaksTime.TabIndex = 56;
            txtIgnoneBreaksTime.Text = "10";
            // 
            // label45
            // 
            label45.AutoSize = true;
            label45.Location = new Point(215, 159);
            label45.Margin = new Padding(4, 0, 4, 0);
            label45.Name = "label45";
            label45.Size = new Size(118, 45);
            label45.TabIndex = 55;
            label45.Text = "Keine Begründung\r\nfür Unterbrechungen\r\nkleiner als";
            label45.TextAlign = ContentAlignment.MiddleRight;
            // 
            // chkMachineStatus_ReadSQLAfterChanges
            // 
            chkMachineStatus_ReadSQLAfterChanges.AutoSize = true;
            chkMachineStatus_ReadSQLAfterChanges.Location = new Point(10, 185);
            chkMachineStatus_ReadSQLAfterChanges.Margin = new Padding(4, 3, 4, 3);
            chkMachineStatus_ReadSQLAfterChanges.Name = "chkMachineStatus_ReadSQLAfterChanges";
            chkMachineStatus_ReadSQLAfterChanges.Size = new Size(142, 19);
            chkMachineStatus_ReadSQLAfterChanges.TabIndex = 54;
            chkMachineStatus_ReadSQLAfterChanges.Text = "Änderungen anzeigen";
            chkMachineStatus_ReadSQLAfterChanges.UseVisualStyleBackColor = true;
            // 
            // chkMachineStatus_Add2SQL
            // 
            chkMachineStatus_Add2SQL.AutoSize = true;
            chkMachineStatus_Add2SQL.Location = new Point(10, 163);
            chkMachineStatus_Add2SQL.Margin = new Padding(4, 3, 4, 3);
            chkMachineStatus_Add2SQL.Name = "chkMachineStatus_Add2SQL";
            chkMachineStatus_Add2SQL.Size = new Size(186, 19);
            chkMachineStatus_Add2SQL.TabIndex = 53;
            chkMachineStatus_Add2SQL.Text = "Änderung auf SQL hinzufügen";
            chkMachineStatus_Add2SQL.UseVisualStyleBackColor = true;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(465, 132);
            label33.Margin = new Padding(4, 0, 4, 0);
            label33.Name = "label33";
            label33.Size = new Size(23, 15);
            label33.TabIndex = 52;
            label33.Text = "ms";
            // 
            // txtCycleTimeMStatus
            // 
            txtCycleTimeMStatus.Location = new Point(341, 129);
            txtCycleTimeMStatus.Margin = new Padding(4, 3, 4, 3);
            txtCycleTimeMStatus.Name = "txtCycleTimeMStatus";
            txtCycleTimeMStatus.Size = new Size(116, 23);
            txtCycleTimeMStatus.TabIndex = 51;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(269, 132);
            label32.Margin = new Padding(4, 0, 4, 0);
            label32.Name = "label32";
            label32.Size = new Size(62, 15);
            label32.TabIndex = 50;
            label32.Text = "CycleTime";
            // 
            // btnWriteMStatus_Stop
            // 
            btnWriteMStatus_Stop.BackColor = Color.White;
            btnWriteMStatus_Stop.ForeColor = Color.Red;
            btnWriteMStatus_Stop.Location = new Point(128, 129);
            btnWriteMStatus_Stop.Margin = new Padding(4, 3, 4, 3);
            btnWriteMStatus_Stop.Name = "btnWriteMStatus_Stop";
            btnWriteMStatus_Stop.Size = new Size(88, 27);
            btnWriteMStatus_Stop.TabIndex = 49;
            btnWriteMStatus_Stop.Text = "Stop";
            btnWriteMStatus_Stop.UseVisualStyleBackColor = false;
            btnWriteMStatus_Stop.Click += btnWriteMStatus_Stop_Click;
            // 
            // btnWriteMStatus_Start
            // 
            btnWriteMStatus_Start.BackColor = Color.White;
            btnWriteMStatus_Start.ForeColor = Color.Green;
            btnWriteMStatus_Start.Location = new Point(10, 129);
            btnWriteMStatus_Start.Margin = new Padding(4, 3, 4, 3);
            btnWriteMStatus_Start.Name = "btnWriteMStatus_Start";
            btnWriteMStatus_Start.Size = new Size(88, 27);
            btnWriteMStatus_Start.TabIndex = 48;
            btnWriteMStatus_Start.Text = "Start";
            btnWriteMStatus_Start.UseVisualStyleBackColor = false;
            btnWriteMStatus_Start.Click += btnWriteMStatus_Start_Click;
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Location = new Point(391, 50);
            label39.Margin = new Padding(4, 0, 4, 0);
            label39.Name = "label39";
            label39.Size = new Size(120, 15);
            label39.TabIndex = 46;
            label39.Text = "Delta Zeit (hh:MM:ss)";
            // 
            // txtDeltaTimeProgStatus
            // 
            txtDeltaTimeProgStatus.Location = new Point(391, 73);
            txtDeltaTimeProgStatus.Margin = new Padding(4, 3, 4, 3);
            txtDeltaTimeProgStatus.Name = "txtDeltaTimeProgStatus";
            txtDeltaTimeProgStatus.Size = new Size(122, 23);
            txtDeltaTimeProgStatus.TabIndex = 47;
            // 
            // txtUpdatedOnProgStatus
            // 
            txtUpdatedOnProgStatus.Location = new Point(129, 73);
            txtUpdatedOnProgStatus.Margin = new Padding(4, 3, 4, 3);
            txtUpdatedOnProgStatus.Name = "txtUpdatedOnProgStatus";
            txtUpdatedOnProgStatus.Size = new Size(122, 23);
            txtUpdatedOnProgStatus.TabIndex = 45;
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Location = new Point(125, 48);
            label37.Margin = new Padding(4, 0, 4, 0);
            label37.Name = "label37";
            label37.Size = new Size(86, 15);
            label37.TabIndex = 44;
            label37.Text = "Aktualisiert am";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(264, 48);
            label30.Margin = new Padding(4, 0, 4, 0);
            label30.Name = "label30";
            label30.Size = new Size(62, 15);
            label30.TabIndex = 41;
            label30.Text = "Gleich Seit";
            // 
            // txtSameSinceProgStatus
            // 
            txtSameSinceProgStatus.Location = new Point(264, 73);
            txtSameSinceProgStatus.Margin = new Padding(4, 3, 4, 3);
            txtSameSinceProgStatus.Name = "txtSameSinceProgStatus";
            txtSameSinceProgStatus.Size = new Size(122, 23);
            txtSameSinceProgStatus.TabIndex = 42;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(10, 82);
            label31.Margin = new Padding(4, 0, 4, 0);
            label31.Name = "label31";
            label31.Size = new Size(39, 15);
            label31.TabIndex = 43;
            label31.Text = "Status";
            // 
            // txtValueProgStatus
            // 
            txtValueProgStatus.Location = new Point(56, 73);
            txtValueProgStatus.Name = "txtValueProgStatus";
            txtValueProgStatus.Size = new Size(65, 23);
            txtValueProgStatus.TabIndex = 14;
            txtValueProgStatus.TextChanged += txtValueProgStatus_TextChanged;
            // 
            // txtValuePoti
            // 
            txtValuePoti.Location = new Point(56, 102);
            txtValuePoti.Name = "txtValuePoti";
            txtValuePoti.Size = new Size(65, 23);
            txtValuePoti.TabIndex = 69;
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.BorderStyle = BorderStyle.FixedSingle;
            label34.Location = new Point(538, 182);
            label34.Margin = new Padding(4, 0, 4, 0);
            label34.Name = "label34";
            label34.Size = new Size(96, 92);
            label34.TabIndex = 21;
            label34.Text = "Status\r\n1=Unterbrochen\r\n2=Angehalten\r\n3=Läuft\r\n4=Wartend\r\n5=Abgebrochen";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(10, 110);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(28, 15);
            label10.TabIndex = 63;
            label10.Text = "Poti";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(219, 25);
            label11.Name = "label11";
            label11.Size = new Size(28, 15);
            label11.TabIndex = 61;
            label11.Text = "Poti";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(289, 22);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(130, 23);
            textBox7.TabIndex = 60;
            textBox7.Text = "ns=2;s=Tag12";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(8, 25);
            label12.Name = "label12";
            label12.Size = new Size(64, 15);
            label12.TabIndex = 59;
            label12.Text = "ProgStatus";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(78, 22);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(130, 23);
            textBox8.TabIndex = 58;
            textBox8.Text = "ns=2;s=Tag11";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(465, 181);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(24, 15);
            label13.TabIndex = 57;
            label13.Text = "sec";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(341, 177);
            textBox9.Margin = new Padding(4, 3, 4, 3);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(116, 23);
            textBox9.TabIndex = 56;
            textBox9.Text = "10";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(215, 166);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(118, 45);
            label14.TabIndex = 55;
            label14.Text = "Keine Begründung\r\nfür Unterbrechungen\r\nkleiner als";
            label14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(10, 197);
            checkBox1.Margin = new Padding(4, 3, 4, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(142, 19);
            checkBox1.TabIndex = 54;
            checkBox1.Text = "Änderungen anzeigen";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(10, 170);
            checkBox2.Margin = new Padding(4, 3, 4, 3);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(186, 19);
            checkBox2.TabIndex = 53;
            checkBox2.Text = "Änderung auf SQL hinzufügen";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(465, 139);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(23, 15);
            label15.TabIndex = 52;
            label15.Text = "ms";
            // 
            // textBox10
            // 
            textBox10.Location = new Point(341, 136);
            textBox10.Margin = new Padding(4, 3, 4, 3);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(116, 23);
            textBox10.TabIndex = 51;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(269, 139);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(62, 15);
            label16.TabIndex = 50;
            label16.Text = "CycleTime";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(388, 52);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(120, 15);
            label17.TabIndex = 46;
            label17.Text = "Delta Zeit (hh:MM:ss)";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(125, 55);
            label18.Margin = new Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new Size(86, 15);
            label18.TabIndex = 44;
            label18.Text = "Aktualisiert am";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(261, 52);
            label19.Margin = new Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new Size(62, 15);
            label19.TabIndex = 41;
            label19.Text = "Gleich Seit";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(10, 82);
            label20.Margin = new Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new Size(39, 15);
            label20.TabIndex = 43;
            label20.Text = "Status";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(19, 296);
            label21.Margin = new Padding(4, 0, 4, 0);
            label21.Name = "label21";
            label21.Size = new Size(39, 15);
            label21.TabIndex = 55;
            label21.Text = "Query";
            // 
            // txtQuery
            // 
            txtQuery.Location = new Point(68, 293);
            txtQuery.Name = "txtQuery";
            txtQuery.Size = new Size(813, 23);
            txtQuery.TabIndex = 71;
            // 
            // btnSendQuery
            // 
            btnSendQuery.Location = new Point(888, 290);
            btnSendQuery.Margin = new Padding(4, 3, 4, 3);
            btnSendQuery.Name = "btnSendQuery";
            btnSendQuery.Size = new Size(105, 27);
            btnSendQuery.TabIndex = 55;
            btnSendQuery.Text = "Send Query";
            btnSendQuery.UseVisualStyleBackColor = true;
            btnSendQuery.Click += btnSendQuery_Click;
            // 
            // btnInsertToMachineStatusSQL
            // 
            btnInsertToMachineStatusSQL.Location = new Point(834, 259);
            btnInsertToMachineStatusSQL.Margin = new Padding(4, 3, 4, 3);
            btnInsertToMachineStatusSQL.Name = "btnInsertToMachineStatusSQL";
            btnInsertToMachineStatusSQL.Size = new Size(159, 27);
            btnInsertToMachineStatusSQL.TabIndex = 72;
            btnInsertToMachineStatusSQL.Text = "Insert->MachineStatusSQL";
            btnInsertToMachineStatusSQL.UseVisualStyleBackColor = true;
            btnInsertToMachineStatusSQL.Click += btnInsertToMachineStatusSQL_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 598);
            Controls.Add(btnInsertToMachineStatusSQL);
            Controls.Add(btnSendQuery);
            Controls.Add(txtQuery);
            Controls.Add(label21);
            Controls.Add(label34);
            Controls.Add(grpMachineStatus);
            Controls.Add(lblMachineNo);
            Controls.Add(label8);
            Controls.Add(lblComputerName);
            Controls.Add(label5);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(grpRW);
            Name = "Form1";
            Text = "Bediener Panel";
            grpRW.ResumeLayout(false);
            grpRW.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            grpMachineStatus.ResumeLayout(false);
            grpMachineStatus.PerformLayout();
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
        private GroupBox grpMachineStatus;
        private Label label42;
        private TextBox txtIgnoneBreaksTime;
        private Label label45;
        private CheckBox chkMachineStatus_ReadSQLAfterChanges;
        private CheckBox chkMachineStatus_Add2SQL;
        private Label label33;
        private TextBox txtCycleTimeMStatus;
        private Label label32;
        private Button btnWriteMStatus_Stop;
        private Button btnWriteMStatus_Start;
        private Label label39;
        private Label label37;
        private Label label30;
        private Label label31;
        private Label label34;
        private Label label7;
        private TextBox txtItemPoti;
        private Label label6;
        private TextBox txtItemProgStatus;
        private Label label9;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label10;
        private Label label11;
        private TextBox textBox7;
        private Label label12;
        private TextBox textBox8;
        private Label label13;
        private TextBox textBox9;
        private Label label14;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Label label15;
        private TextBox textBox10;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private TextBox txtValueProgStatus;
        private TextBox txtValuePoti;
        private TextBox txtDeltaTimePoti;
        private TextBox txtUpdatedOnPoti;
        private TextBox txtSameSincePoti;
        private TextBox txtDeltaTimeProgStatus;
        private TextBox txtUpdatedOnProgStatus;
        private TextBox txtSameSinceProgStatus;
        private Label label21;
        private TextBox txtQuery;
        private Button btnSendQuery;
        private Button btnInsertToMachineStatusSQL;
        private Label lblProgStatus;
    }
}
