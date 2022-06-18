
namespace rangdong_agv
{
    partial class FormError
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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxDanhMucLoi = new System.Windows.Forms.ListBox();
            this.lvTenLoi = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(101, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Danh mục lỗi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(502, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên lỗi";
            // 
            // listBoxDanhMucLoi
            // 
            this.listBoxDanhMucLoi.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.listBoxDanhMucLoi.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.listBoxDanhMucLoi.FormattingEnabled = true;
            this.listBoxDanhMucLoi.ItemHeight = 21;
            this.listBoxDanhMucLoi.Location = new System.Drawing.Point(32, 77);
            this.listBoxDanhMucLoi.Name = "listBoxDanhMucLoi";
            this.listBoxDanhMucLoi.Size = new System.Drawing.Size(262, 445);
            this.listBoxDanhMucLoi.TabIndex = 4;
            this.listBoxDanhMucLoi.SelectedIndexChanged += new System.EventHandler(this.listBoxDanhMucLoi_SelectedIndexChanged);
            // 
            // lvTenLoi
            // 
            this.lvTenLoi.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lvTenLoi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvTenLoi.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lvTenLoi.FullRowSelect = true;
            this.lvTenLoi.GridLines = true;
            this.lvTenLoi.HideSelection = false;
            this.lvTenLoi.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.lvTenLoi.Location = new System.Drawing.Point(326, 77);
            this.lvTenLoi.Name = "lvTenLoi";
            this.lvTenLoi.Size = new System.Drawing.Size(600, 445);
            this.lvTenLoi.TabIndex = 5;
            this.lvTenLoi.UseCompatibleStateImageBehavior = false;
            this.lvTenLoi.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã lỗi";
            this.columnHeader1.Width = 103;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Date";
            this.columnHeader2.Width = 240;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tên lỗi";
            this.columnHeader3.Width = 350;
            // 
            // FormError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1024, 561);
            this.Controls.Add(this.lvTenLoi);
            this.Controls.Add(this.listBoxDanhMucLoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormError";
            this.Text = "FormError";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxDanhMucLoi;
        private System.Windows.Forms.ListView lvTenLoi;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}