using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rangdong_agv
{
    public partial class FormDelivery : Form
    {
        private int agvIdSelected;
        private AgvInfo agvInfo;
        private AgvParams agvParams;
        //private FormMain formMain;

        public FormDelivery()
        {
            InitializeComponent();
            this.agvInfo = new AgvInfo();
            this.agvParams = new AgvParams();
            //this.formMain = new FormMain();
            this.agvIdSelected = 0x01;
        }

        public FormDelivery(AgvParams _agvParams)
        {
            InitializeComponent();
            this.agvInfo = new AgvInfo();
            this.agvParams = _agvParams;
            //this.formMain = new FormMain();
            this.agvIdSelected = 0x01;
        }

        //public FormDelivery(FormMain _formMain)
        //{
        //    InitializeComponent();
        //    this.agvInfo = new AgvInfo();
        //    this.formMain = _formMain;
        //    this.agvParams = _formMain.AgvParams;
        //    this.agvIdSelected = 0x01;
        //}

        private void updateFeedingDeliveryStation(string deliveryStationId)
        {
            if (this.labelFeedingDeliveryStation1.Text.Length == 0 ^ this.labelFeedingDeliveryStation1.Text.Contains("N/A"))
            {
                this.labelFeedingDeliveryStation1.Text = deliveryStationId;
            }
            else
            {
                if (this.labelFeedingDeliveryStation1.Text != deliveryStationId)
                {
                    if (this.labelFeedingDeliveryStation2.Text.Length == 0 ^ this.labelFeedingDeliveryStation2.Text.Contains("N/A"))
                    {
                        this.labelFeedingDeliveryStation2.Text = deliveryStationId;
                    }
                    else
                    {
                        if (this.labelFeedingDeliveryStation2.Text != deliveryStationId)
                            MessageBox.Show("None of the shelf is available!");
                    }

                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string deliveryStationId = "1";
            this.updateFeedingDeliveryStation(deliveryStationId);   
        }

        private void groupBoxStation1_Enter(object sender, EventArgs e)
        {

        }

        private void clearFeeding1()
        {
            this.comboBoxFeedingMaterialCode1.Text = "";
            this.comboBoxFeedingStation1.Text = "";
            this.comboBoxFeedingShelf1.Text = "";
            this.labelFeedingDeliveryStation1.Text = "N/A";
        }

        private void clearFeeding2()
        {
            this.comboBoxFeedingMaterialCode2.Text = "";
            this.comboBoxFeedingStation2.Text = "";
            this.comboBoxFeedingShelf2.Text = "";
            this.labelFeedingDeliveryStation2.Text = "N/A";
        }

        private void btnFeedingClear1_Click(object sender, EventArgs e)
        {
            this.clearFeeding1();
        }

        private void btnFeedingClear2_Click(object sender, EventArgs e)
        {
            this.clearFeeding2();
        }

        private void btnMaterialDiscard_Click(object sender, EventArgs e)
        {
            this.clearFeeding1();
            this.clearFeeding2();
            this.btnFeedingClear1.Enabled = true;
            this.btnFeedingClear2.Enabled = true;
        }

        private void btnMaterialApply_Click(object sender, EventArgs e)
        {
            this.agvParams.Shelf1 = this.comboBoxFeedingMaterialCode1.Text;
            this.agvParams.Shelf2 = this.comboBoxFeedingMaterialCode2.Text;
            //this.textBoxTest.Text = this.agvParams.Shelf1 + "\r\n" + this.agvParams.Shelf2;
            this.btnFeedingClear1.Enabled = false;
            this.btnFeedingClear2.Enabled = false;
        }
    }
}
