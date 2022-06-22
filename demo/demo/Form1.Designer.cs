namespace demo
{
    partial class Form1
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
            this.txtBoxRxMsgTest = new System.Windows.Forms.RichTextBox();
            this.labelComport = new System.Windows.Forms.Label();
            this.comboBoxComPort = new System.Windows.Forms.ComboBox();
            this.BtnDisconnect = new System.Windows.Forms.Button();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBatt_voltage = new System.Windows.Forms.TextBox();
            this.txtBatt_ca = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBatt_cap = new System.Windows.Forms.TextBox();
            this.txtSate = new System.Windows.Forms.TextBox();
            this.txtTrip_Id = new System.Windows.Forms.TextBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.Label();
            this.button19 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBoxRxMsgTest
            // 
            this.txtBoxRxMsgTest.Location = new System.Drawing.Point(15, 59);
            this.txtBoxRxMsgTest.Name = "txtBoxRxMsgTest";
            this.txtBoxRxMsgTest.Size = new System.Drawing.Size(400, 252);
            this.txtBoxRxMsgTest.TabIndex = 9;
            this.txtBoxRxMsgTest.Text = "";
            // 
            // labelComport
            // 
            this.labelComport.AutoSize = true;
            this.labelComport.Location = new System.Drawing.Point(12, 14);
            this.labelComport.Name = "labelComport";
            this.labelComport.Size = new System.Drawing.Size(58, 16);
            this.labelComport.TabIndex = 8;
            this.labelComport.Text = "Comport";
            // 
            // comboBoxComPort
            // 
            this.comboBoxComPort.FormattingEnabled = true;
            this.comboBoxComPort.Location = new System.Drawing.Point(76, 10);
            this.comboBoxComPort.Name = "comboBoxComPort";
            this.comboBoxComPort.Size = new System.Drawing.Size(121, 24);
            this.comboBoxComPort.TabIndex = 7;
            // 
            // BtnDisconnect
            // 
            this.BtnDisconnect.Location = new System.Drawing.Point(312, 10);
            this.BtnDisconnect.Name = "BtnDisconnect";
            this.BtnDisconnect.Size = new System.Drawing.Size(102, 24);
            this.BtnDisconnect.TabIndex = 6;
            this.BtnDisconnect.Text = "Disconnect";
            this.BtnDisconnect.UseVisualStyleBackColor = true;
            this.BtnDisconnect.Click += new System.EventHandler(this.BtnDisconnect_Click);
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(205, 10);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(93, 24);
            this.BtnConnect.TabIndex = 5;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(447, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 42;
            this.label2.Text = "Batt_voltage(V)";
            // 
            // txtBatt_voltage
            // 
            this.txtBatt_voltage.Location = new System.Drawing.Point(569, 349);
            this.txtBatt_voltage.Name = "txtBatt_voltage";
            this.txtBatt_voltage.Size = new System.Drawing.Size(100, 22);
            this.txtBatt_voltage.TabIndex = 41;
            // 
            // txtBatt_ca
            // 
            this.txtBatt_ca.AutoSize = true;
            this.txtBatt_ca.Location = new System.Drawing.Point(466, 310);
            this.txtBatt_ca.Name = "txtBatt_ca";
            this.txtBatt_ca.Size = new System.Drawing.Size(80, 16);
            this.txtBatt_ca.TabIndex = 40;
            this.txtBatt_ca.Text = "Batt_cap(%)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(457, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 16);
            this.label5.TabIndex = 39;
            this.label5.Text = "Speed(mm/s)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(501, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 16);
            this.label9.TabIndex = 37;
            this.label9.Text = "Trip Id";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(491, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 16);
            this.label8.TabIndex = 38;
            this.label8.Text = "Position";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(511, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 16);
            this.label7.TabIndex = 36;
            this.label7.Text = "AGV";
            // 
            // txtBatt_cap
            // 
            this.txtBatt_cap.Location = new System.Drawing.Point(569, 211);
            this.txtBatt_cap.Name = "txtBatt_cap";
            this.txtBatt_cap.Size = new System.Drawing.Size(100, 22);
            this.txtBatt_cap.TabIndex = 35;
            // 
            // txtSate
            // 
            this.txtSate.Location = new System.Drawing.Point(569, 108);
            this.txtSate.Name = "txtSate";
            this.txtSate.Size = new System.Drawing.Size(100, 22);
            this.txtSate.TabIndex = 34;
            // 
            // txtTrip_Id
            // 
            this.txtTrip_Id.Location = new System.Drawing.Point(569, 261);
            this.txtTrip_Id.Name = "txtTrip_Id";
            this.txtTrip_Id.Size = new System.Drawing.Size(100, 22);
            this.txtTrip_Id.TabIndex = 33;
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(569, 162);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(100, 22);
            this.txtPosition.TabIndex = 32;
            // 
            // txtSpeed
            // 
            this.txtSpeed.Location = new System.Drawing.Point(569, 304);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(100, 22);
            this.txtSpeed.TabIndex = 31;
            // 
            // txtState
            // 
            this.txtState.AutoSize = true;
            this.txtState.Location = new System.Drawing.Point(508, 114);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(38, 16);
            this.txtState.TabIndex = 29;
            this.txtState.Text = "State";
            // 
            // button19
            // 
            this.button19.ForeColor = System.Drawing.Color.Crimson;
            this.button19.Location = new System.Drawing.Point(341, 346);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(75, 23);
            this.button19.TabIndex = 45;
            this.button19.Text = "Error3";
            this.button19.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.button18.ForeColor = System.Drawing.Color.Crimson;
            this.button18.Location = new System.Drawing.Point(179, 346);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(75, 23);
            this.button18.TabIndex = 44;
            this.button18.Text = "Sai làn";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            this.button17.ForeColor = System.Drawing.Color.Crimson;
            this.button17.Location = new System.Drawing.Point(12, 347);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(75, 23);
            this.button17.TabIndex = 43;
            this.button17.Text = "Vật cản";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "AGV1",
            "AGV2",
            "AGV3"});
            this.comboBox1.Location = new System.Drawing.Point(569, 54);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 24);
            this.comboBox1.TabIndex = 46;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.LimeGreen;
            this.button1.Location = new System.Drawing.Point(578, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 47;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(698, 397);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBatt_voltage);
            this.Controls.Add(this.txtBatt_ca);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBatt_cap);
            this.Controls.Add(this.txtSate);
            this.Controls.Add(this.txtTrip_Id);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.txtSpeed);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.txtBoxRxMsgTest);
            this.Controls.Add(this.labelComport);
            this.Controls.Add(this.comboBoxComPort);
            this.Controls.Add(this.BtnDisconnect);
            this.Controls.Add(this.BtnConnect);
            this.Name = "Form1";
            this.Text = "Giả lập AGV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox txtBoxRxMsgTest;
        private System.Windows.Forms.Label labelComport;
        private System.Windows.Forms.ComboBox comboBoxComPort;
        private System.Windows.Forms.Button BtnDisconnect;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBatt_voltage;
        private System.Windows.Forms.Label txtBatt_ca;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBatt_cap;
        private System.Windows.Forms.TextBox txtSate;
        private System.Windows.Forms.TextBox txtTrip_Id;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.Label txtState;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
    }
}

