
namespace rangdong_agv
{
    partial class UserControl1
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
            this.groupBoxStation1 = new System.Windows.Forms.GroupBox();
            this.btnStnCallAgv1 = new FontAwesome.Sharp.IconButton();
            this.labelStnMaterialQuantity1 = new System.Windows.Forms.Label();
            this.labelStnMaterialCode1 = new System.Windows.Forms.Label();
            this.labelStnLastDeliveryTime1 = new System.Windows.Forms.Label();
            this.labelStn1Line = new System.Windows.Forms.Label();
            this.labelStnId1 = new System.Windows.Forms.Label();
            this.labelStnMaterialStatus1 = new System.Windows.Forms.Label();
            this.groupBoxStation1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxStation1
            // 
            this.groupBoxStation1.AutoSize = true;
            this.groupBoxStation1.Controls.Add(this.btnStnCallAgv1);
            this.groupBoxStation1.Controls.Add(this.labelStnMaterialQuantity1);
            this.groupBoxStation1.Controls.Add(this.labelStnMaterialCode1);
            this.groupBoxStation1.Controls.Add(this.labelStnLastDeliveryTime1);
            this.groupBoxStation1.Controls.Add(this.labelStn1Line);
            this.groupBoxStation1.Controls.Add(this.labelStnId1);
            this.groupBoxStation1.Controls.Add(this.labelStnMaterialStatus1);
            this.groupBoxStation1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxStation1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxStation1.ForeColor = System.Drawing.Color.Gainsboro;
            this.groupBoxStation1.Location = new System.Drawing.Point(0, 0);
            this.groupBoxStation1.Name = "groupBoxStation1";
            this.groupBoxStation1.Size = new System.Drawing.Size(183, 189);
            this.groupBoxStation1.TabIndex = 1;
            this.groupBoxStation1.TabStop = false;
            this.groupBoxStation1.Text = "Trạm nhận 1";
            // 
            // btnStnCallAgv1
            // 
            this.btnStnCallAgv1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnStnCallAgv1.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStnCallAgv1.FlatAppearance.BorderSize = 0;
            this.btnStnCallAgv1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnStnCallAgv1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStnCallAgv1.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.btnStnCallAgv1.IconChar = FontAwesome.Sharp.IconChar.Caravan;
            this.btnStnCallAgv1.IconColor = System.Drawing.Color.Gainsboro;
            this.btnStnCallAgv1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStnCallAgv1.IconSize = 20;
            this.btnStnCallAgv1.Location = new System.Drawing.Point(3, 156);
            this.btnStnCallAgv1.Name = "btnStnCallAgv1";
            this.btnStnCallAgv1.Size = new System.Drawing.Size(177, 30);
            this.btnStnCallAgv1.TabIndex = 7;
            this.btnStnCallAgv1.Text = "Call AGV";
            this.btnStnCallAgv1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStnCallAgv1.UseVisualStyleBackColor = false;
            // 
            // labelStnMaterialQuantity1
            // 
            this.labelStnMaterialQuantity1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelStnMaterialQuantity1.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.labelStnMaterialQuantity1.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelStnMaterialQuantity1.Location = new System.Drawing.Point(3, 136);
            this.labelStnMaterialQuantity1.Name = "labelStnMaterialQuantity1";
            this.labelStnMaterialQuantity1.Size = new System.Drawing.Size(177, 20);
            this.labelStnMaterialQuantity1.TabIndex = 4;
            this.labelStnMaterialQuantity1.Text = "Số lượng:";
            this.labelStnMaterialQuantity1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelStnMaterialCode1
            // 
            this.labelStnMaterialCode1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelStnMaterialCode1.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.labelStnMaterialCode1.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelStnMaterialCode1.Location = new System.Drawing.Point(3, 116);
            this.labelStnMaterialCode1.Name = "labelStnMaterialCode1";
            this.labelStnMaterialCode1.Size = new System.Drawing.Size(177, 20);
            this.labelStnMaterialCode1.TabIndex = 8;
            this.labelStnMaterialCode1.Text = "Mã vật tư:";
            this.labelStnMaterialCode1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelStnLastDeliveryTime1
            // 
            this.labelStnLastDeliveryTime1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelStnLastDeliveryTime1.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.labelStnLastDeliveryTime1.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelStnLastDeliveryTime1.Location = new System.Drawing.Point(3, 96);
            this.labelStnLastDeliveryTime1.Name = "labelStnLastDeliveryTime1";
            this.labelStnLastDeliveryTime1.Size = new System.Drawing.Size(177, 20);
            this.labelStnLastDeliveryTime1.TabIndex = 3;
            this.labelStnLastDeliveryTime1.Text = "Giao cuối:";
            this.labelStnLastDeliveryTime1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelStn1Line
            // 
            this.labelStn1Line.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelStn1Line.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.labelStn1Line.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelStn1Line.Location = new System.Drawing.Point(3, 76);
            this.labelStn1Line.Name = "labelStn1Line";
            this.labelStn1Line.Size = new System.Drawing.Size(177, 20);
            this.labelStn1Line.TabIndex = 5;
            this.labelStn1Line.Text = "Line:";
            this.labelStn1Line.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelStnId1
            // 
            this.labelStnId1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelStnId1.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.labelStnId1.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelStnId1.Location = new System.Drawing.Point(3, 57);
            this.labelStnId1.Name = "labelStnId1";
            this.labelStnId1.Size = new System.Drawing.Size(177, 19);
            this.labelStnId1.TabIndex = 6;
            this.labelStnId1.Text = "ID:";
            this.labelStnId1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelStnMaterialStatus1
            // 
            this.labelStnMaterialStatus1.BackColor = System.Drawing.Color.SeaGreen;
            this.labelStnMaterialStatus1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelStnMaterialStatus1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelStnMaterialStatus1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelStnMaterialStatus1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStnMaterialStatus1.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelStnMaterialStatus1.Location = new System.Drawing.Point(3, 23);
            this.labelStnMaterialStatus1.Name = "labelStnMaterialStatus1";
            this.labelStnMaterialStatus1.Size = new System.Drawing.Size(177, 34);
            this.labelStnMaterialStatus1.TabIndex = 0;
            this.labelStnMaterialStatus1.Text = "Trạm vật tư";
            this.labelStnMaterialStatus1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.Controls.Add(this.groupBoxStation1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(183, 214);
            this.groupBoxStation1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxStation1;
        private FontAwesome.Sharp.IconButton btnStnCallAgv1;
        private System.Windows.Forms.Label labelStnMaterialQuantity1;
        private System.Windows.Forms.Label labelStnMaterialCode1;
        private System.Windows.Forms.Label labelStnLastDeliveryTime1;
        private System.Windows.Forms.Label labelStn1Line;
        private System.Windows.Forms.Label labelStnId1;
        private System.Windows.Forms.Label labelStnMaterialStatus1;
    }
}
