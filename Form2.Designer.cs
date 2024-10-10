namespace OPC_UA_Client
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblDeltaTime = new Label();
            txtReasoning = new TextBox();
            btnSubmitReasoning = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            btnShiftChange = new Button();
            btnWaitForCrane = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // lblDeltaTime
            // 
            lblDeltaTime.AutoSize = true;
            lblDeltaTime.Location = new Point(14, 13);
            lblDeltaTime.Name = "lblDeltaTime";
            lblDeltaTime.Size = new Size(66, 15);
            lblDeltaTime.TabIndex = 0;
            lblDeltaTime.Text = "Delta Time:";
            // 
            // txtReasoning
            // 
            txtReasoning.Location = new Point(6, 34);
            txtReasoning.Name = "txtReasoning";
            txtReasoning.Size = new Size(282, 23);
            txtReasoning.TabIndex = 1;
            // 
            // btnSubmitReasoning
            // 
            btnSubmitReasoning.Location = new Point(6, 71);
            btnSubmitReasoning.Name = "btnSubmitReasoning";
            btnSubmitReasoning.Size = new Size(128, 23);
            btnSubmitReasoning.TabIndex = 3;
            btnSubmitReasoning.Text = "Begründung melden";
            btnSubmitReasoning.UseVisualStyleBackColor = true;
            btnSubmitReasoning.Click += btnSubmitReasoning_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtReasoning);
            groupBox1.Controls.Add(btnSubmitReasoning);
            groupBox1.Location = new Point(12, 31);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(294, 104);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "1. Option: Begründung eintippen";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnShiftChange);
            groupBox2.Controls.Add(btnWaitForCrane);
            groupBox2.Location = new Point(12, 143);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(296, 140);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "2. Option: Begründung auswählen";
            // 
            // btnShiftChange
            // 
            btnShiftChange.Location = new Point(6, 51);
            btnShiftChange.Name = "btnShiftChange";
            btnShiftChange.Size = new Size(128, 23);
            btnShiftChange.TabIndex = 5;
            btnShiftChange.Text = "Schichtwechsel";
            btnShiftChange.UseVisualStyleBackColor = true;
            // 
            // btnWaitForCrane
            // 
            btnWaitForCrane.Location = new Point(6, 22);
            btnWaitForCrane.Name = "btnWaitForCrane";
            btnWaitForCrane.Size = new Size(128, 23);
            btnWaitForCrane.TabIndex = 4;
            btnWaitForCrane.Text = "Warten auf Kran";
            btnWaitForCrane.UseVisualStyleBackColor = true;
            btnWaitForCrane.Click += btnWaitForCrane_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 295);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lblDeltaTime);
            Name = "Form2";
            Text = "Störungsmeldung";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDeltaTime;
        private TextBox txtReasoning;
        private Button btnSubmitReasoning;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnWaitForCrane;
        private Button btnShiftChange;
    }
}