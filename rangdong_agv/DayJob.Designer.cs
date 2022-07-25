namespace rangdong_agv
{
    partial class DayJob
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nmToMinute = new System.Windows.Forms.NumericUpDown();
            this.nmToHours = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nmFromMinute = new System.Windows.Forms.NumericUpDown();
            this.nmFromHours = new System.Windows.Forms.NumericUpDown();
            this.txtJob = new System.Windows.Forms.TextBox();
            this.ckbDone = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmToMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmToHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmFromMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmFromHours)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdDelete);
            this.panel1.Controls.Add(this.cmdEdit);
            this.panel1.Controls.Add(this.cbStatus);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txtJob);
            this.panel1.Controls.Add(this.ckbDone);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 40);
            this.panel1.TabIndex = 0;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdDelete.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelete.Location = new System.Drawing.Point(850, 0);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(87, 40);
            this.cmdDelete.TabIndex = 5;
            this.cmdDelete.Text = "Xóa";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdEdit.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEdit.Location = new System.Drawing.Point(937, 0);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(87, 40);
            this.cmdEdit.TabIndex = 4;
            this.cmdEdit.Text = "Sửa";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cbStatus
            // 
            this.cbStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.cbStatus.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(622, 4);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(222, 29);
            this.cbStatus.TabIndex = 3;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nmToMinute);
            this.panel2.Controls.Add(this.nmToHours);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.nmFromMinute);
            this.panel2.Controls.Add(this.nmFromHours);
            this.panel2.Location = new System.Drawing.Point(382, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 32);
            this.panel2.TabIndex = 2;
            // 
            // nmToMinute
            // 
            this.nmToMinute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.nmToMinute.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmToMinute.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.nmToMinute.Location = new System.Drawing.Point(202, 3);
            this.nmToMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nmToMinute.Name = "nmToMinute";
            this.nmToMinute.Size = new System.Drawing.Size(33, 27);
            this.nmToMinute.TabIndex = 4;
            // 
            // nmToHours
            // 
            this.nmToHours.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.nmToHours.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmToHours.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.nmToHours.Location = new System.Drawing.Point(163, 2);
            this.nmToHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nmToHours.Name = "nmToHours";
            this.nmToHours.Size = new System.Drawing.Size(33, 27);
            this.nmToHours.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(101, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đến";
            // 
            // nmFromMinute
            // 
            this.nmFromMinute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.nmFromMinute.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmFromMinute.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.nmFromMinute.Location = new System.Drawing.Point(43, 4);
            this.nmFromMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nmFromMinute.Name = "nmFromMinute";
            this.nmFromMinute.Size = new System.Drawing.Size(33, 27);
            this.nmFromMinute.TabIndex = 1;
            // 
            // nmFromHours
            // 
            this.nmFromHours.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.nmFromHours.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmFromHours.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.nmFromHours.Location = new System.Drawing.Point(4, 4);
            this.nmFromHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nmFromHours.Name = "nmFromHours";
            this.nmFromHours.Size = new System.Drawing.Size(33, 27);
            this.nmFromHours.TabIndex = 0;
            // 
            // txtJob
            // 
            this.txtJob.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.txtJob.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJob.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtJob.Location = new System.Drawing.Point(35, 6);
            this.txtJob.Name = "txtJob";
            this.txtJob.Size = new System.Drawing.Size(345, 27);
            this.txtJob.TabIndex = 1;
            // 
            // ckbDone
            // 
            this.ckbDone.Location = new System.Drawing.Point(14, 8);
            this.ckbDone.Name = "ckbDone";
            this.ckbDone.Size = new System.Drawing.Size(29, 24);
            this.ckbDone.TabIndex = 0;
            this.ckbDone.UseVisualStyleBackColor = true;
            this.ckbDone.CheckedChanged += new System.EventHandler(this.ckbDone_CheckedChanged);
            // 
            // DayJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.Controls.Add(this.panel1);
            this.Name = "DayJob";
            this.Size = new System.Drawing.Size(1024, 40);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmToMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmToHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmFromMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmFromHours)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown nmToMinute;
        private System.Windows.Forms.NumericUpDown nmToHours;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nmFromMinute;
        private System.Windows.Forms.NumericUpDown nmFromHours;
        private System.Windows.Forms.TextBox txtJob;
        private System.Windows.Forms.CheckBox ckbDone;
    }
}
