
namespace rangdong_agv
{
    partial class FormReport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbTemplatePath = new System.Windows.Forms.TextBox();
            this.btnLoadTemplate = new System.Windows.Forms.Button();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbPhoneNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rtxbTemplate = new System.Windows.Forms.RichTextBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.txbTemplatePath);
            this.panel1.Controls.Add(this.btnLoadTemplate);
            this.panel1.Controls.Add(this.txbEmail);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txbPhoneNumber);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txbName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 167);
            this.panel1.TabIndex = 2;
            // 
            // txbTemplatePath
            // 
            this.txbTemplatePath.BackColor = System.Drawing.SystemColors.Info;
            this.txbTemplatePath.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txbTemplatePath.Location = new System.Drawing.Point(271, 126);
            this.txbTemplatePath.Name = "txbTemplatePath";
            this.txbTemplatePath.ReadOnly = true;
            this.txbTemplatePath.Size = new System.Drawing.Size(492, 29);
            this.txbTemplatePath.TabIndex = 36;
            // 
            // btnLoadTemplate
            // 
            this.btnLoadTemplate.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.btnLoadTemplate.ForeColor = System.Drawing.Color.DarkRed;
            this.btnLoadTemplate.ImageIndex = 2;
            this.btnLoadTemplate.Location = new System.Drawing.Point(122, 126);
            this.btnLoadTemplate.Name = "btnLoadTemplate";
            this.btnLoadTemplate.Size = new System.Drawing.Size(128, 32);
            this.btnLoadTemplate.TabIndex = 11;
            this.btnLoadTemplate.Text = "Load Template";
            this.btnLoadTemplate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoadTemplate.UseVisualStyleBackColor = true;
            // 
            // txbEmail
            // 
            this.txbEmail.Location = new System.Drawing.Point(271, 81);
            this.txbEmail.Name = "txbEmail";
            this.txbEmail.Size = new System.Drawing.Size(238, 27);
            this.txbEmail.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(163, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "        Email:";
            // 
            // txbPhoneNumber
            // 
            this.txbPhoneNumber.Location = new System.Drawing.Point(271, 46);
            this.txbPhoneNumber.Name = "txbPhoneNumber";
            this.txbPhoneNumber.Size = new System.Drawing.Size(238, 27);
            this.txbPhoneNumber.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(84, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "         Phone Number:";
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(271, 11);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(238, 27);
            this.txbName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(90, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "    Supervisor Name:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rtxbTemplate);
            this.panel2.Location = new System.Drawing.Point(1, 193);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1020, 314);
            this.panel2.TabIndex = 3;
            // 
            // rtxbTemplate
            // 
            this.rtxbTemplate.BackColor = System.Drawing.Color.White;
            this.rtxbTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxbTemplate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxbTemplate.Location = new System.Drawing.Point(0, 0);
            this.rtxbTemplate.Name = "rtxbTemplate";
            this.rtxbTemplate.ReadOnly = true;
            this.rtxbTemplate.Size = new System.Drawing.Size(1020, 314);
            this.rtxbTemplate.TabIndex = 39;
            this.rtxbTemplate.Text = "";
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.ForeColor = System.Drawing.Color.DarkRed;
            this.btnPreview.ImageIndex = 0;
            this.btnPreview.Location = new System.Drawing.Point(822, 517);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(94, 32);
            this.btnPreview.TabIndex = 40;
            this.btnPreview.Text = "Preview";
            this.btnPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPreview.UseVisualStyleBackColor = true;
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAs.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSaveAs.ImageIndex = 1;
            this.btnSaveAs.Location = new System.Drawing.Point(922, 517);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(99, 32);
            this.btnSaveAs.TabIndex = 41;
            this.btnSaveAs.Text = "Save as";
            this.btnSaveAs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveAs.UseVisualStyleBackColor = true;
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1024, 561);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormReport";
            this.Text = "Report";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txbTemplatePath;
        private System.Windows.Forms.Button btnLoadTemplate;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbPhoneNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox rtxbTemplate;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnSaveAs;
    }
}