
namespace rangdong_agv
{
    partial class FormDelivery
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
            this.tblLayoutPanelDelivery = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnMaterialDiscard = new System.Windows.Forms.Button();
            this.btnMaterialApply = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxFeedingMaterialCode2 = new System.Windows.Forms.ComboBox();
            this.btnFeedingClear2 = new System.Windows.Forms.Button();
            this.labelFeedingDeliveryStation2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.comboBoxFeedingShelf2 = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.comboBoxFeedingStation2 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFeedingClear1 = new System.Windows.Forms.Button();
            this.comboBoxFeedingMaterialCode1 = new System.Windows.Forms.ComboBox();
            this.labelFeedingDeliveryStation1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxFeedingShelf1 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxFeedingStation1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxTest = new System.Windows.Forms.TextBox();
            this.btnStopAgv = new FontAwesome.Sharp.IconButton();
            this.btnStartAgv = new FontAwesome.Sharp.IconButton();
            this.radioButtonAgv3 = new System.Windows.Forms.RadioButton();
            this.radioButtonAgv2 = new System.Windows.Forms.RadioButton();
            this.radioButtonAgv1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.mySqlCommandBuilder1 = new MySqlConnector.MySqlCommandBuilder();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.tblLayoutPanelDelivery);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 561);
            this.panel1.TabIndex = 0;
            // 
            // tblLayoutPanelDelivery
            // 
            this.tblLayoutPanelDelivery.AutoScroll = true;
            this.tblLayoutPanelDelivery.ColumnCount = 4;
            this.tblLayoutPanelDelivery.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblLayoutPanelDelivery.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblLayoutPanelDelivery.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblLayoutPanelDelivery.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblLayoutPanelDelivery.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblLayoutPanelDelivery.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutPanelDelivery.Name = "tblLayoutPanelDelivery";
            this.tblLayoutPanelDelivery.RowCount = 3;
            this.tblLayoutPanelDelivery.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tblLayoutPanelDelivery.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tblLayoutPanelDelivery.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblLayoutPanelDelivery.Size = new System.Drawing.Size(774, 558);
            this.tblLayoutPanelDelivery.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(774, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 561);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(11)))));
            this.panel3.Controls.Add(this.btnMaterialDiscard);
            this.panel3.Controls.Add(this.btnMaterialApply);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 300);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 261);
            this.panel3.TabIndex = 0;
            // 
            // btnMaterialDiscard
            // 
            this.btnMaterialDiscard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaterialDiscard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnMaterialDiscard.FlatAppearance.BorderSize = 0;
            this.btnMaterialDiscard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnMaterialDiscard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaterialDiscard.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaterialDiscard.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMaterialDiscard.Location = new System.Drawing.Point(167, 1769);
            this.btnMaterialDiscard.Name = "btnMaterialDiscard";
            this.btnMaterialDiscard.Size = new System.Drawing.Size(80, 40);
            this.btnMaterialDiscard.TabIndex = 13;
            this.btnMaterialDiscard.Text = "&Discard";
            this.btnMaterialDiscard.UseVisualStyleBackColor = false;
            this.btnMaterialDiscard.Click += new System.EventHandler(this.btnMaterialDiscard_Click);
            // 
            // btnMaterialApply
            // 
            this.btnMaterialApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnMaterialApply.FlatAppearance.BorderSize = 0;
            this.btnMaterialApply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnMaterialApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaterialApply.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaterialApply.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMaterialApply.Location = new System.Drawing.Point(10, 1769);
            this.btnMaterialApply.Name = "btnMaterialApply";
            this.btnMaterialApply.Size = new System.Drawing.Size(80, 40);
            this.btnMaterialApply.TabIndex = 12;
            this.btnMaterialApply.Text = "&Apply";
            this.btnMaterialApply.UseVisualStyleBackColor = false;
            this.btnMaterialApply.Click += new System.EventHandler(this.btnMaterialApply_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxFeedingMaterialCode2);
            this.groupBox3.Controls.Add(this.btnFeedingClear2);
            this.groupBox3.Controls.Add(this.labelFeedingDeliveryStation2);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.comboBoxFeedingShelf2);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.comboBoxFeedingStation2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Gainsboro;
            this.groupBox3.Location = new System.Drawing.Point(0, 255);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(233, 215);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Giá xe 2";
            // 
            // comboBoxFeedingMaterialCode2
            // 
            this.comboBoxFeedingMaterialCode2.FormattingEnabled = true;
            this.comboBoxFeedingMaterialCode2.Location = new System.Drawing.Point(106, 26);
            this.comboBoxFeedingMaterialCode2.Name = "comboBoxFeedingMaterialCode2";
            this.comboBoxFeedingMaterialCode2.Size = new System.Drawing.Size(121, 29);
            this.comboBoxFeedingMaterialCode2.TabIndex = 16;
            // 
            // btnFeedingClear2
            // 
            this.btnFeedingClear2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFeedingClear2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnFeedingClear2.FlatAppearance.BorderSize = 0;
            this.btnFeedingClear2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnFeedingClear2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFeedingClear2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeedingClear2.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnFeedingClear2.Location = new System.Drawing.Point(148, 164);
            this.btnFeedingClear2.Name = "btnFeedingClear2";
            this.btnFeedingClear2.Size = new System.Drawing.Size(80, 40);
            this.btnFeedingClear2.TabIndex = 15;
            this.btnFeedingClear2.Text = "&Clear";
            this.btnFeedingClear2.UseVisualStyleBackColor = false;
            this.btnFeedingClear2.Click += new System.EventHandler(this.btnFeedingClear2_Click);
            // 
            // labelFeedingDeliveryStation2
            // 
            this.labelFeedingDeliveryStation2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFeedingDeliveryStation2.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelFeedingDeliveryStation2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelFeedingDeliveryStation2.Location = new System.Drawing.Point(108, 131);
            this.labelFeedingDeliveryStation2.Name = "labelFeedingDeliveryStation2";
            this.labelFeedingDeliveryStation2.Size = new System.Drawing.Size(120, 30);
            this.labelFeedingDeliveryStation2.TabIndex = 9;
            this.labelFeedingDeliveryStation2.Text = "N/A";
            this.labelFeedingDeliveryStation2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Gainsboro;
            this.label15.Location = new System.Drawing.Point(8, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 21);
            this.label15.TabIndex = 1;
            this.label15.Text = "Mã:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Gainsboro;
            this.label16.Location = new System.Drawing.Point(8, 136);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 21);
            this.label16.TabIndex = 8;
            this.label16.Text = "Trạm nhận:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Gainsboro;
            this.label17.Location = new System.Drawing.Point(6, 99);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 21);
            this.label17.TabIndex = 3;
            this.label17.Text = "Trạm cấp:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxFeedingShelf2
            // 
            this.comboBoxFeedingShelf2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFeedingShelf2.FormattingEnabled = true;
            this.comboBoxFeedingShelf2.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboBoxFeedingShelf2.Location = new System.Drawing.Point(106, 61);
            this.comboBoxFeedingShelf2.Name = "comboBoxFeedingShelf2";
            this.comboBoxFeedingShelf2.Size = new System.Drawing.Size(120, 29);
            this.comboBoxFeedingShelf2.TabIndex = 7;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Gainsboro;
            this.label18.Location = new System.Drawing.Point(6, 64);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 21);
            this.label18.TabIndex = 4;
            this.label18.Text = "Số lượng:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxFeedingStation2
            // 
            this.comboBoxFeedingStation2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFeedingStation2.FormattingEnabled = true;
            this.comboBoxFeedingStation2.Items.AddRange(new object[] {
            "1"});
            this.comboBoxFeedingStation2.Location = new System.Drawing.Point(106, 96);
            this.comboBoxFeedingStation2.Name = "comboBoxFeedingStation2";
            this.comboBoxFeedingStation2.Size = new System.Drawing.Size(120, 29);
            this.comboBoxFeedingStation2.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFeedingClear1);
            this.groupBox2.Controls.Add(this.comboBoxFeedingMaterialCode1);
            this.groupBox2.Controls.Add(this.labelFeedingDeliveryStation1);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.comboBoxFeedingShelf1);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.comboBoxFeedingStation1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.groupBox2.Location = new System.Drawing.Point(0, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 215);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Giá xe 1";
            // 
            // btnFeedingClear1
            // 
            this.btnFeedingClear1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFeedingClear1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnFeedingClear1.FlatAppearance.BorderSize = 0;
            this.btnFeedingClear1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnFeedingClear1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFeedingClear1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeedingClear1.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnFeedingClear1.Location = new System.Drawing.Point(147, 164);
            this.btnFeedingClear1.Name = "btnFeedingClear1";
            this.btnFeedingClear1.Size = new System.Drawing.Size(80, 40);
            this.btnFeedingClear1.TabIndex = 14;
            this.btnFeedingClear1.Text = "&Clear";
            this.btnFeedingClear1.UseVisualStyleBackColor = false;
            this.btnFeedingClear1.Click += new System.EventHandler(this.btnFeedingClear1_Click);
            // 
            // comboBoxFeedingMaterialCode1
            // 
            this.comboBoxFeedingMaterialCode1.FormattingEnabled = true;
            this.comboBoxFeedingMaterialCode1.Location = new System.Drawing.Point(109, 29);
            this.comboBoxFeedingMaterialCode1.Name = "comboBoxFeedingMaterialCode1";
            this.comboBoxFeedingMaterialCode1.Size = new System.Drawing.Size(121, 29);
            this.comboBoxFeedingMaterialCode1.TabIndex = 10;
            // 
            // labelFeedingDeliveryStation1
            // 
            this.labelFeedingDeliveryStation1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFeedingDeliveryStation1.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelFeedingDeliveryStation1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelFeedingDeliveryStation1.Location = new System.Drawing.Point(108, 131);
            this.labelFeedingDeliveryStation1.Name = "labelFeedingDeliveryStation1";
            this.labelFeedingDeliveryStation1.Size = new System.Drawing.Size(120, 30);
            this.labelFeedingDeliveryStation1.TabIndex = 9;
            this.labelFeedingDeliveryStation1.Text = "N/A";
            this.labelFeedingDeliveryStation1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gainsboro;
            this.label9.Location = new System.Drawing.Point(8, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 21);
            this.label9.TabIndex = 1;
            this.label9.Text = "Mã:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Gainsboro;
            this.label12.Location = new System.Drawing.Point(6, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 21);
            this.label12.TabIndex = 8;
            this.label12.Text = "Trạm nhận:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gainsboro;
            this.label10.Location = new System.Drawing.Point(7, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 21);
            this.label10.TabIndex = 3;
            this.label10.Text = "Trạm cấp:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxFeedingShelf1
            // 
            this.comboBoxFeedingShelf1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFeedingShelf1.FormattingEnabled = true;
            this.comboBoxFeedingShelf1.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboBoxFeedingShelf1.Location = new System.Drawing.Point(109, 64);
            this.comboBoxFeedingShelf1.Name = "comboBoxFeedingShelf1";
            this.comboBoxFeedingShelf1.Size = new System.Drawing.Size(120, 29);
            this.comboBoxFeedingShelf1.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gainsboro;
            this.label11.Location = new System.Drawing.Point(7, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 21);
            this.label11.TabIndex = 4;
            this.label11.Text = "Số lượng:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxFeedingStation1
            // 
            this.comboBoxFeedingStation1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFeedingStation1.FormattingEnabled = true;
            this.comboBoxFeedingStation1.Items.AddRange(new object[] {
            "1"});
            this.comboBoxFeedingStation1.Location = new System.Drawing.Point(109, 99);
            this.comboBoxFeedingStation1.Name = "comboBoxFeedingStation1";
            this.comboBoxFeedingStation1.Size = new System.Drawing.Size(120, 29);
            this.comboBoxFeedingStation1.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(233, 40);
            this.label8.TabIndex = 0;
            this.label8.Text = "Vật tư";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.panel4.Controls.Add(this.textBoxTest);
            this.panel4.Controls.Add(this.btnStopAgv);
            this.panel4.Controls.Add(this.btnStartAgv);
            this.panel4.Controls.Add(this.radioButtonAgv3);
            this.panel4.Controls.Add(this.radioButtonAgv2);
            this.panel4.Controls.Add(this.radioButtonAgv1);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(250, 300);
            this.panel4.TabIndex = 1;
            // 
            // textBoxTest
            // 
            this.textBoxTest.Location = new System.Drawing.Point(6, 138);
            this.textBoxTest.Multiline = true;
            this.textBoxTest.Name = "textBoxTest";
            this.textBoxTest.Size = new System.Drawing.Size(241, 92);
            this.textBoxTest.TabIndex = 6;
            // 
            // btnStopAgv
            // 
            this.btnStopAgv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStopAgv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnStopAgv.FlatAppearance.BorderSize = 0;
            this.btnStopAgv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnStopAgv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopAgv.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopAgv.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnStopAgv.IconChar = FontAwesome.Sharp.IconChar.Stop;
            this.btnStopAgv.IconColor = System.Drawing.Color.Firebrick;
            this.btnStopAgv.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStopAgv.IconSize = 20;
            this.btnStopAgv.Location = new System.Drawing.Point(167, 249);
            this.btnStopAgv.Name = "btnStopAgv";
            this.btnStopAgv.Size = new System.Drawing.Size(80, 45);
            this.btnStopAgv.TabIndex = 5;
            this.btnStopAgv.Text = "Stop";
            this.btnStopAgv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStopAgv.UseVisualStyleBackColor = false;
            // 
            // btnStartAgv
            // 
            this.btnStartAgv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStartAgv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnStartAgv.FlatAppearance.BorderSize = 0;
            this.btnStartAgv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnStartAgv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartAgv.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartAgv.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnStartAgv.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.btnStartAgv.IconColor = System.Drawing.Color.SeaGreen;
            this.btnStartAgv.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStartAgv.IconSize = 20;
            this.btnStartAgv.Location = new System.Drawing.Point(10, 249);
            this.btnStartAgv.Name = "btnStartAgv";
            this.btnStartAgv.Size = new System.Drawing.Size(80, 45);
            this.btnStartAgv.TabIndex = 4;
            this.btnStartAgv.Text = "Start";
            this.btnStartAgv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStartAgv.UseVisualStyleBackColor = false;
            // 
            // radioButtonAgv3
            // 
            this.radioButtonAgv3.AutoSize = true;
            this.radioButtonAgv3.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButtonAgv3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonAgv3.ForeColor = System.Drawing.Color.ForestGreen;
            this.radioButtonAgv3.Location = new System.Drawing.Point(0, 90);
            this.radioButtonAgv3.Name = "radioButtonAgv3";
            this.radioButtonAgv3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.radioButtonAgv3.Size = new System.Drawing.Size(250, 25);
            this.radioButtonAgv3.TabIndex = 3;
            this.radioButtonAgv3.TabStop = true;
            this.radioButtonAgv3.Text = "Agv3 sẵn sàng";
            this.radioButtonAgv3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioButtonAgv3.UseVisualStyleBackColor = true;
            // 
            // radioButtonAgv2
            // 
            this.radioButtonAgv2.AutoSize = true;
            this.radioButtonAgv2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButtonAgv2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonAgv2.ForeColor = System.Drawing.Color.Gainsboro;
            this.radioButtonAgv2.Location = new System.Drawing.Point(0, 65);
            this.radioButtonAgv2.Name = "radioButtonAgv2";
            this.radioButtonAgv2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.radioButtonAgv2.Size = new System.Drawing.Size(250, 25);
            this.radioButtonAgv2.TabIndex = 2;
            this.radioButtonAgv2.TabStop = true;
            this.radioButtonAgv2.Text = "Agv2 sẵn sàng";
            this.radioButtonAgv2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioButtonAgv2.UseVisualStyleBackColor = true;
            // 
            // radioButtonAgv1
            // 
            this.radioButtonAgv1.AutoSize = true;
            this.radioButtonAgv1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButtonAgv1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonAgv1.ForeColor = System.Drawing.Color.Gainsboro;
            this.radioButtonAgv1.Location = new System.Drawing.Point(0, 40);
            this.radioButtonAgv1.Name = "radioButtonAgv1";
            this.radioButtonAgv1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.radioButtonAgv1.Size = new System.Drawing.Size(250, 25);
            this.radioButtonAgv1.TabIndex = 1;
            this.radioButtonAgv1.TabStop = true;
            this.radioButtonAgv1.Text = "Agv1 sẵn sàng";
            this.radioButtonAgv1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioButtonAgv1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý xe";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mySqlCommandBuilder1
            // 
            this.mySqlCommandBuilder1.DataAdapter = null;
            this.mySqlCommandBuilder1.QuotePrefix = "`";
            this.mySqlCommandBuilder1.QuoteSuffix = "`";
            // 
            // FormDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1024, 561);
            this.Controls.Add(this.panel1);
            this.Name = "FormDelivery";
            this.Text = "Delivery";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonAgv1;
        private System.Windows.Forms.RadioButton radioButtonAgv3;
        private System.Windows.Forms.RadioButton radioButtonAgv2;
        private FontAwesome.Sharp.IconButton btnStartAgv;
        private FontAwesome.Sharp.IconButton btnStopAgv;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxFeedingShelf1;
        private System.Windows.Forms.ComboBox comboBoxFeedingStation1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelFeedingDeliveryStation1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelFeedingDeliveryStation2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox comboBoxFeedingShelf2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox comboBoxFeedingStation2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxFeedingMaterialCode1;
        private System.Windows.Forms.Button btnMaterialDiscard;
        private System.Windows.Forms.Button btnMaterialApply;
        private System.Windows.Forms.Button btnFeedingClear1;
        private System.Windows.Forms.Button btnFeedingClear2;
        private System.Windows.Forms.ComboBox comboBoxFeedingMaterialCode2;
        private System.Windows.Forms.TextBox textBoxTest;
        private MySqlConnector.MySqlCommandBuilder mySqlCommandBuilder1;
        private System.Windows.Forms.TableLayoutPanel tblLayoutPanelDelivery;
    }
}