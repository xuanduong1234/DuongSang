using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;


namespace rangdong_agv
{
    public partial class FormDelivery : Form
    {      
        private int agvIdSelected;
        private AgvInfo agvInfo;
        private AgvParams agvParams;
        //private FormMain formMain;
        private SerialPort comport1;      
        //List<Station> Sta = new List<Station>();
        
        public FormDelivery()
        {
            InitializeComponent();
            this.agvInfo = new AgvInfo();
            this.agvParams = new AgvParams();
            //this.formMain = new FormMain();
            this.agvIdSelected = 0x01;
            
        }

        public FormDelivery(AgvParams _agvParams, SerialPort _comPort)
        {       
            InitializeComponent();
            this.agvInfo = new AgvInfo();
            this.agvParams = _agvParams;
            //this.formMain = new FormMain();
            this.agvIdSelected = 0x01;
            this.comport1 = _comPort;
          

            MySqlDAO sqlDAO = new MySqlDAO();
            //var data = sqlDAO.GetStations();
            //var lis = new UserControl1[data.Count];
            List<Station> Sta = sqlDAO.GetStations();
            AddStations(Sta);
            
        }
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
        // User Control lay so tram tu CSDL
        void AddStations(List<Station> list)
        {
            int c = 0, r = 0;
            foreach (Station s in list)
            {
                UserControl1 u = new UserControl1();               
                u.AddStation(s);
                //u.btnStnCallAgv1_Click(s);
                u.SendData = new UserControl1.SendFormDelivery(updateFeedingDeliveryStation);

                //u.Location = new System.Drawing.Point(1, 1);
                tblLayoutPanelDelivery.Controls.Add(u, c, r);
                c++;
                if (c > 3)
                {
                    c = 0;
                    r++;
                }
            }           
        }



        //public FormDelivery(FormMain _formMain)
        //{
        //    InitializeComponent();
        //    this.agvInfo = new AgvInfo();
        //    this.formMain = _formMain;
        //    this.agvParams = _formMain.AgvParams;
        //    this.agvIdSelected = 0x01;
        //}



        //private void iconbutton1_click(object sender, eventargs e)
        //{
        //    string deliverystationid = "1";
        //    this.updatefeedingdeliverystation(deliverystationid);
        //}

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
