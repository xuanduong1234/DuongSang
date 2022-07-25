namespace rangdong_agv
{
    partial class Calender
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calender));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmpPreMonth = new System.Windows.Forms.Button();
            this.cmpNextMonth = new System.Windows.Forms.Button();
            this.cmdThu = new System.Windows.Forms.Button();
            this.cmdSun = new System.Windows.Forms.Button();
            this.cmdSat = new System.Windows.Forms.Button();
            this.cmdFri = new System.Windows.Forms.Button();
            this.cmdWed = new System.Windows.Forms.Button();
            this.cmdTue = new System.Windows.Forms.Button();
            this.cmdMon = new System.Windows.Forms.Button();
            this.pnlMaTrixNgay = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnTK = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.nmNotify = new System.Windows.Forms.NumericUpDown();
            this.ckbTB = new System.Windows.Forms.CheckBox();
            this.cmdToDay = new System.Windows.Forms.Button();
            this.dtpkDate = new System.Windows.Forms.DateTimePicker();
            this.tmNotify = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmnJob = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmNotify)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 561);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.pnlMaTrixNgay);
            this.panel2.Location = new System.Drawing.Point(179, 55);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(710, 376);
            this.panel2.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cmpPreMonth);
            this.panel4.Controls.Add(this.cmpNextMonth);
            this.panel4.Controls.Add(this.cmdThu);
            this.panel4.Controls.Add(this.cmdSun);
            this.panel4.Controls.Add(this.cmdSat);
            this.panel4.Controls.Add(this.cmdFri);
            this.panel4.Controls.Add(this.cmdWed);
            this.panel4.Controls.Add(this.cmdTue);
            this.panel4.Controls.Add(this.cmdMon);
            this.panel4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(2, 3);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(704, 53);
            this.panel4.TabIndex = 2;
            // 
            // cmpPreMonth
            // 
            this.cmpPreMonth.Location = new System.Drawing.Point(2, 3);
            this.cmpPreMonth.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmpPreMonth.Name = "cmpPreMonth";
            this.cmpPreMonth.Size = new System.Drawing.Size(60, 43);
            this.cmpPreMonth.TabIndex = 10;
            this.cmpPreMonth.Text = "<";
            this.cmpPreMonth.UseVisualStyleBackColor = true;
            this.cmpPreMonth.Click += new System.EventHandler(this.cmpPreMonth_Click);
            // 
            // cmpNextMonth
            // 
            this.cmpNextMonth.Location = new System.Drawing.Point(636, 3);
            this.cmpNextMonth.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmpNextMonth.Name = "cmpNextMonth";
            this.cmpNextMonth.Size = new System.Drawing.Size(60, 43);
            this.cmpNextMonth.TabIndex = 9;
            this.cmpNextMonth.Text = ">";
            this.cmpNextMonth.UseVisualStyleBackColor = true;
            this.cmpNextMonth.Click += new System.EventHandler(this.cmpNextMonth_Click);
            // 
            // cmdThu
            // 
            this.cmdThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdThu.Location = new System.Drawing.Point(312, 3);
            this.cmdThu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdThu.Name = "cmdThu";
            this.cmdThu.Size = new System.Drawing.Size(74, 43);
            this.cmdThu.TabIndex = 3;
            this.cmdThu.Text = "Thứ 5";
            this.cmdThu.UseVisualStyleBackColor = true;
            // 
            // cmdSun
            // 
            this.cmdSun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSun.Location = new System.Drawing.Point(554, 3);
            this.cmdSun.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdSun.Name = "cmdSun";
            this.cmdSun.Size = new System.Drawing.Size(74, 43);
            this.cmdSun.TabIndex = 6;
            this.cmdSun.Text = "Chủ nhật";
            this.cmdSun.UseVisualStyleBackColor = true;
            // 
            // cmdSat
            // 
            this.cmdSat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSat.Location = new System.Drawing.Point(474, 3);
            this.cmdSat.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdSat.Name = "cmdSat";
            this.cmdSat.Size = new System.Drawing.Size(74, 43);
            this.cmdSat.TabIndex = 5;
            this.cmdSat.Text = "Thứ 7";
            this.cmdSat.UseVisualStyleBackColor = true;
            // 
            // cmdFri
            // 
            this.cmdFri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFri.Location = new System.Drawing.Point(392, 3);
            this.cmdFri.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdFri.Name = "cmdFri";
            this.cmdFri.Size = new System.Drawing.Size(74, 43);
            this.cmdFri.TabIndex = 4;
            this.cmdFri.Text = "Thứ 6";
            this.cmdFri.UseVisualStyleBackColor = true;
            // 
            // cmdWed
            // 
            this.cmdWed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdWed.Location = new System.Drawing.Point(230, 3);
            this.cmdWed.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdWed.Name = "cmdWed";
            this.cmdWed.Size = new System.Drawing.Size(74, 43);
            this.cmdWed.TabIndex = 2;
            this.cmdWed.Text = "Thứ 4";
            this.cmdWed.UseVisualStyleBackColor = true;
            // 
            // cmdTue
            // 
            this.cmdTue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdTue.Location = new System.Drawing.Point(150, 3);
            this.cmdTue.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdTue.Name = "cmdTue";
            this.cmdTue.Size = new System.Drawing.Size(74, 43);
            this.cmdTue.TabIndex = 1;
            this.cmdTue.Text = "Thứ 3";
            this.cmdTue.UseVisualStyleBackColor = true;
            // 
            // cmdMon
            // 
            this.cmdMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMon.Location = new System.Drawing.Point(68, 3);
            this.cmdMon.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdMon.Name = "cmdMon";
            this.cmdMon.Size = new System.Drawing.Size(74, 43);
            this.cmdMon.TabIndex = 0;
            this.cmdMon.Text = "Thứ 2";
            this.cmdMon.UseVisualStyleBackColor = true;
            // 
            // pnlMaTrixNgay
            // 
            this.pnlMaTrixNgay.Location = new System.Drawing.Point(72, 62);
            this.pnlMaTrixNgay.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlMaTrixNgay.Name = "pnlMaTrixNgay";
            this.pnlMaTrixNgay.Size = new System.Drawing.Size(564, 303);
            this.pnlMaTrixNgay.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnTK);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.cmdToDay);
            this.panel3.Controls.Add(this.dtpkDate);
            this.panel3.Location = new System.Drawing.Point(2, 3);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1021, 46);
            this.panel3.TabIndex = 1;
            // 
            // btnTK
            // 
            this.btnTK.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTK.Location = new System.Drawing.Point(810, 6);
            this.btnTK.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTK.Name = "btnTK";
            this.btnTK.Size = new System.Drawing.Size(168, 30);
            this.btnTK.TabIndex = 3;
            this.btnTK.Text = "Thống kê tháng";
            this.btnTK.UseVisualStyleBackColor = true;
            this.btnTK.Click += new System.EventHandler(this.btnTK_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.nmNotify);
            this.panel5.Controls.Add(this.ckbTB);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(292, 46);
            this.panel5.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(207, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Phút";
            // 
            // nmNotify
            // 
            this.nmNotify.Enabled = false;
            this.nmNotify.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmNotify.Location = new System.Drawing.Point(141, 9);
            this.nmNotify.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nmNotify.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nmNotify.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmNotify.Name = "nmNotify";
            this.nmNotify.Size = new System.Drawing.Size(48, 27);
            this.nmNotify.TabIndex = 1;
            this.nmNotify.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmNotify.ValueChanged += new System.EventHandler(this.nmTB_ValueChanged);
            // 
            // ckbTB
            // 
            this.ckbTB.AutoSize = true;
            this.ckbTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbTB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ckbTB.Location = new System.Drawing.Point(20, 11);
            this.ckbTB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ckbTB.Name = "ckbTB";
            this.ckbTB.Size = new System.Drawing.Size(104, 24);
            this.ckbTB.TabIndex = 0;
            this.ckbTB.Text = "Thông báo";
            this.ckbTB.UseVisualStyleBackColor = true;
            this.ckbTB.CheckedChanged += new System.EventHandler(this.ckbTB_CheckedChanged);
            // 
            // cmdToDay
            // 
            this.cmdToDay.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdToDay.Location = new System.Drawing.Point(655, 6);
            this.cmdToDay.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdToDay.Name = "cmdToDay";
            this.cmdToDay.Size = new System.Drawing.Size(135, 30);
            this.cmdToDay.TabIndex = 1;
            this.cmdToDay.Text = "Hôm nay";
            this.cmdToDay.UseVisualStyleBackColor = true;
            this.cmdToDay.Click += new System.EventHandler(this.cmdToDay_Click);
            // 
            // dtpkDate
            // 
            this.dtpkDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.dtpkDate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkDate.Location = new System.Drawing.Point(320, 6);
            this.dtpkDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpkDate.Name = "dtpkDate";
            this.dtpkDate.Size = new System.Drawing.Size(293, 27);
            this.dtpkDate.TabIndex = 0;
            this.dtpkDate.ValueChanged += new System.EventHandler(this.dtpkDate_ValueChanged);
            // 
            // tmNotify
            // 
            this.tmNotify.Enabled = true;
            this.tmNotify.Interval = 5000;
            this.tmNotify.Tick += new System.EventHandler(this.tmNotify_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Thông báo";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmnJob,
            this.tsmnExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(151, 48);
            // 
            // tsmnJob
            // 
            this.tsmnJob.Name = "tsmnJob";
            this.tsmnJob.Size = new System.Drawing.Size(150, 22);
            this.tsmnJob.Text = "Lịch công việc";
            this.tsmnJob.Click += new System.EventHandler(this.tsmnJob_Click);
            // 
            // tsmnExit
            // 
            this.tsmnExit.Name = "tsmnExit";
            this.tsmnExit.Size = new System.Drawing.Size(150, 22);
            this.tsmnExit.Text = "Thoát";
            this.tsmnExit.Click += new System.EventHandler(this.tsmnExit_Click);
            // 
            // Calender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1024, 561);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Calender";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Calender_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmNotify)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.NumericUpDown nmNotify;
        private System.Windows.Forms.CheckBox ckbTB;
        private System.Windows.Forms.Button cmdToDay;
        private System.Windows.Forms.DateTimePicker dtpkDate;
        private System.Windows.Forms.Button btnPreMonth;
        private System.Windows.Forms.Timer tmNotify;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmnJob;
        private System.Windows.Forms.ToolStripMenuItem tsmnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTK;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button cmpPreMonth;
        private System.Windows.Forms.Button cmpNextMonth;
        private System.Windows.Forms.Button cmdThu;
        private System.Windows.Forms.Button cmdSun;
        private System.Windows.Forms.Button cmdSat;
        private System.Windows.Forms.Button cmdFri;
        private System.Windows.Forms.Button cmdWed;
        private System.Windows.Forms.Button cmdTue;
        private System.Windows.Forms.Button cmdMon;
        private System.Windows.Forms.Panel pnlMaTrixNgay;
    }
}

