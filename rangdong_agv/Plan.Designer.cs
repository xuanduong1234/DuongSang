namespace rangdong_agv
{
    partial class Plan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Plan));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnsAddJob = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsToday = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnTK = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dtpkDate = new System.Windows.Forms.DateTimePicker();
            this.cmdNext = new System.Windows.Forms.Button();
            this.cmdPrevious = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlJos = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.menuStrip1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsAddJob,
            this.mnsToday,
            this.tsmnTK});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1024, 43);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnsAddJob
            // 
            this.mnsAddJob.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.mnsAddJob.Name = "mnsAddJob";
            this.mnsAddJob.Size = new System.Drawing.Size(101, 39);
            this.mnsAddJob.Text = "Thêm việc";
            this.mnsAddJob.Click += new System.EventHandler(this.mnsAddJob_Click);
            // 
            // mnsToday
            // 
            this.mnsToday.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.mnsToday.Name = "mnsToday";
            this.mnsToday.Size = new System.Drawing.Size(91, 39);
            this.mnsToday.Text = "Hôm nay";
            this.mnsToday.Click += new System.EventHandler(this.mnsToday_Click);
            // 
            // tsmnTK
            // 
            this.tsmnTK.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tsmnTK.Name = "tsmnTK";
            this.tsmnTK.Size = new System.Drawing.Size(145, 39);
            this.tsmnTK.Text = "Thống kê tháng";
            this.tsmnTK.Click += new System.EventHandler(this.tsmnTK_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 535);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1024, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(174, 21);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // dtpkDate
            // 
            this.dtpkDate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkDate.Location = new System.Drawing.Point(347, 22);
            this.dtpkDate.Name = "dtpkDate";
            this.dtpkDate.Size = new System.Drawing.Size(325, 27);
            this.dtpkDate.TabIndex = 1;
            this.dtpkDate.ValueChanged += new System.EventHandler(this.dtpkDate_ValueChanged);
            // 
            // cmdNext
            // 
            this.cmdNext.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNext.Location = new System.Drawing.Point(770, 13);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(177, 48);
            this.cmdNext.TabIndex = 2;
            this.cmdNext.Text = "Ngày mai";
            this.cmdNext.UseVisualStyleBackColor = true;
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // cmdPrevious
            // 
            this.cmdPrevious.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrevious.Location = new System.Drawing.Point(83, 13);
            this.cmdPrevious.Name = "cmdPrevious";
            this.cmdPrevious.Size = new System.Drawing.Size(177, 48);
            this.cmdPrevious.TabIndex = 3;
            this.cmdPrevious.Text = "Hôm qua";
            this.cmdPrevious.UseVisualStyleBackColor = true;
            this.cmdPrevious.Click += new System.EventHandler(this.cmdPrevious_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdPrevious);
            this.panel1.Controls.Add(this.cmdNext);
            this.panel1.Controls.Add(this.dtpkDate);
            this.panel1.Controls.Add(this.pnlJos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 518);
            this.panel1.TabIndex = 0;
            // 
            // pnlJos
            // 
            this.pnlJos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlJos.Location = new System.Drawing.Point(0, 76);
            this.pnlJos.Name = "pnlJos";
            this.pnlJos.Size = new System.Drawing.Size(1024, 442);
            this.pnlJos.TabIndex = 0;
            // 
            // Plan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1024, 561);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Plan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch trong ngày";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Plan_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnsAddJob;
        private System.Windows.Forms.ToolStripMenuItem mnsToday;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem tsmnTK;
        private System.Windows.Forms.DateTimePicker dtpkDate;
        private System.Windows.Forms.Button cmdNext;
        private System.Windows.Forms.Button cmdPrevious;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlJos;
    }
}