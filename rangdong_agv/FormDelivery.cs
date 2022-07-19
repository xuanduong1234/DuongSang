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
                            MessageBox.Show("Không có kệ trống");
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

            //Trạm D01 (Kí hiệu: 07, STT: 1)
            //AGV1
            if (radioButtonAgv1.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "1") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "1")))
            {
                textBoxTest.Text = "7A 23 01 01 FE 00 01 01 1A 01 01 02 02 07 03 02 04 03 05 02 07 06 07 02 05 02 04 02 03 01 02 01 01 09 7F";
            }

            ////AGV2
            if (radioButtonAgv2.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "1") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "1")))
            {
                textBoxTest.Text = "7A 23 01 02 FE 00 01 01 1A 01 01 02 02 07 03 02 04 03 05 02 07 06 07 02 05 02 04 02 03 01 02 01 01 09 7F";
            }

            ////AGV3
            if (radioButtonAgv3.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "1") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "1")))
            {
                textBoxTest.Text = "7A 23 01 03 FE 00 01 01 1A 01 01 02 02 07 03 02 04 03 05 02 07 06 07 02 05 02 04 02 03 01 02 01 01 09 7F";
            }

            //Trạm D02 (Kí hiệu: 08, STT: 2)
            //AGV1
            if (radioButtonAgv1.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "2") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "2")))
            {
                textBoxTest.Text = "7A 27 01 01 FE 00 02 01 1E 01 01 02 02 07 03 02 04 03 05 02 07 02 08 06 08 02 07 02 05 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV2
            if (radioButtonAgv2.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "2") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "2")))
            {
                textBoxTest.Text = "7A 27 01 02 FE 00 02 01 1E 01 01 02 02 07 03 02 04 03 05 02 07 02 08 06 08 02 07 02 05 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV3
            if (radioButtonAgv3.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "2") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "2")))
            {
                textBoxTest.Text = "7A 27 01 03 FE 00 02 01 1E 01 01 02 02 07 03 02 04 03 05 02 07 02 08 06 08 02 07 02 05 02 04 02 03 01 02 01 01 09 7F";
            }


            //Trạm D03 (Kí hiệu: 09, STT: 3)
            //AGV1
            if (radioButtonAgv1.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "3") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "3")))
            {
                textBoxTest.Text = "7A 2B 01 01 FE 00 03 01 22 01 01 02 02 07 03 02 04 03 05 02 07 02 08 02 09 06 09 02 08 02 07 02 05 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV2
            if (radioButtonAgv2.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "3") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "3")))
            {
                textBoxTest.Text = "7A 2B 01 02 FE 00 03 01 22 01 01 02 02 07 03 02 04 03 05 02 07 02 08 02 09 06 09 02 08 02 07 02 05 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV3
            if (radioButtonAgv3.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "3") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "3")))
            {
                textBoxTest.Text = "7A 2B 01 03 FE 00 03 01 22 01 01 02 02 07 03 02 04 03 05 02 07 02 08 02 09 06 09 02 08 02 07 02 05 02 04 02 03 01 02 01 01 09 7F";
            }

            //Trạm D04 (Kí hiệu: 0A, STT: 4)
            //AGV1
            if (radioButtonAgv1.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "4") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "4")))
            {
                textBoxTest.Text = "7A 2F 01 01 FE 00 04 01 26 01 01 02 02 07 03 02 04 03 05 02 07 02 08 02 09 02 0A 06 0A 06 09 02 08 02 07 02 05 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV2
            if (radioButtonAgv2.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "4") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "4")))
            {
                textBoxTest.Text = "7A 2F 01 02 FE 00 04 01 26 01 01 02 02 07 03 02 04 03 05 02 07 02 08 02 09 02 0A 06 0A 06 09 02 08 02 07 02 05 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV3
            if (radioButtonAgv3.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "4") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "4")))
            {
                textBoxTest.Text = "7A 2F 01 03 FE 00 04 01 26 01 01 02 02 07 03 02 04 03 05 02 07 02 08 02 09 02 0A 06 0A 06 09 02 08 02 07 02 05 02 04 02 03 01 02 01 01 09 7F";
            }

            //Trạm D05 (kí hiệu: 0B, STT: 5)
            //AGV1
            if (radioButtonAgv1.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "5") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "5")))
            {
                textBoxTest.Text = "7A 33 01 01 FE 00 05 01 2A 01 01 02 02 07 03 02 04 03 05 02 07 02 08 02 09 02 0A 02 0B 06 0B 06 0A 02 09 02 08 02 07 02 05 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV2
            if (radioButtonAgv2.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "5") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "5")))
            {
                textBoxTest.Text = "7A 33 01 02 FE 00 05 01 2A 01 01 02 02 07 03 02 04 03 05 02 07 02 08 02 09 02 0A 02 0B 06 0B 06 0A 02 09 02 08 02 07 02 05 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV3
            if (radioButtonAgv3.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "5") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "5")))
            {
                textBoxTest.Text = "7A 33 01 03 FE 00 05 01 2A 01 01 02 02 07 03 02 04 03 05 02 07 02 08 02 09 02 0A 02 0B 06 0B 06 0A 02 09 02 08 02 07 02 05 02 04 02 03 01 02 01 01 09 7F";
            }

            //Trạm D06 (Kí hiệu: 0C, STT: 6)
            //AGV1
            if (radioButtonAgv1.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "6") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "6")))
            {
                textBoxTest.Text = "7A 37 01 01 FE 00 06 01 2E 01 01 02 02 07 03 02 04 03 05 02 07 02 08 02 09 02 0A 02 0B 02 0C 06 0C 06 0B 02 0A 02 09 02 08 02 07 02 05 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV2
            if (radioButtonAgv2.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "6") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "6")))
            {
                textBoxTest.Text = "7A 37 01 02 FE 00 06 01 2E 01 01 02 02 07 03 02 04 03 05 02 07 02 08 02 09 02 0A 02 0B 02 0C 06 0C 06 0B 02 0A 02 09 02 08 02 07 02 05 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV3
            if (radioButtonAgv3.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "6") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "6")))
            {
                textBoxTest.Text = "7A 37 01 03 FE 00 06 01 2E 01 01 02 02 07 03 02 04 03 05 02 07 02 08 02 09 02 0A 02 0B 02 0C 06 0C 06 0B 02 0A 02 09 02 08 02 07 02 05 02 04 02 03 01 02 01 01 09 7F";
            }

            //Trạm D07 (Kí hiệu: 0D, STT: 7)
            //AGV1
            if (radioButtonAgv1.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "7") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "7")))
            {
                textBoxTest.Text = "7A 3B 01 01 FE 00 07 01 32 01 01 02 02 07 03 02 04 03 05 02 07 02 08 02 09 02 0A 02 0B 02 0C 02 0D 06 0D 06 0C 02 0B 02 0A 02 09 02 08 02 07 02 05 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV2
            if (radioButtonAgv2.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "7") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "7")))
            {
                textBoxTest.Text = "7A 3B 01 02 FE 00 07 01 32 01 01 02 02 07 03 02 04 03 05 02 07 02 08 02 09 02 0A 02 0B 02 0C 02 0D 06 0D 06 0C 02 0B 02 0A 02 09 02 08 02 07 02 05 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV3
            if (radioButtonAgv3.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "7") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "7")))
            {
                textBoxTest.Text = "7A 3B 01 03 FE 00 07 01 32 01 01 02 02 07 03 02 04 03 05 02 07 02 08 02 09 02 0A 02 0B 02 0C 02 0D 06 0D 06 0C 02 0B 02 0A 02 09 02 08 02 07 02 05 02 04 02 03 01 02 01 01 09 7F";
            }

            //Trạm D11 (Kí hiệu: C1, STT: 8)
            //AGV1
            if (radioButtonAgv1.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "8") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "8")))
            {
                textBoxTest.Text = "7A 23 01 01 FE 00 08 01 1A 01 01 02 02 07 03 02 04 03 06 02 C1 06 C1 02 06 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV2
            if (radioButtonAgv2.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "8") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "8")))
            {
                textBoxTest.Text = "7A 23 01 02 FE 00 08 01 1A 01 01 02 02 07 03 02 04 03 06 02 C1 06 C1 02 06 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV3
            if (radioButtonAgv3.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "8") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "8")))
            {
                textBoxTest.Text = "7A 23 01 03 FE 00 08 01 1A 01 01 02 02 07 03 02 04 03 06 02 C1 06 C1 02 06 02 04 02 03 01 02 01 01 09 7F";
            }

            //Trạm D12 (Kí hiệu: C2, STT: 9)
            //AGV1
            if (radioButtonAgv1.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "9") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "9")))
            {
                textBoxTest.Text = "7A 27 01 01 FE 00 09 01 1E 01 01 02 02 07 03 02 04 03 06 02 C1 02 C2 06 C2 02 C1 02 06 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV2
            if (radioButtonAgv2.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "9") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "9")))
            {
                textBoxTest.Text = "7A 27 01 02 FE 00 09 01 1E 01 01 02 02 07 03 02 04 03 06 02 C1 02 C2 06 C2 02 C1 02 06 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV3
            if (radioButtonAgv3.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "9") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "9")))
            {
                textBoxTest.Text = "7A 27 01 03 FE 00 09 01 1E 01 01 02 02 07 03 02 04 03 06 02 C1 02 C2 06 C2 02 C1 02 06 02 04 02 03 01 02 01 01 09 7F";
            }


            //Trạm D13 (Kí hiệu: C3, STT: 10)
            //AGV1
            if (radioButtonAgv1.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "10") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "10")))
            {
                textBoxTest.Text = "7A 2B 01 01 FE 00 03 01 22 01 01 02 02 07 03 02 04 03 06 02 C1 02 C2 02 C3 06 C3 02 C2 02 C1 02 06 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV2
            if (radioButtonAgv2.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "10") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "10")))
            {
                textBoxTest.Text = "7A 2B 01 02 FE 00 03 01 22 01 01 02 02 07 03 02 04 03 06 02 C1 02 C2 02 C3 06 C3 02 C2 02 C1 02 06 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV3
            if (radioButtonAgv3.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "10") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "10")))
            {
                textBoxTest.Text = "7A 2B 01 03 FE 00 03 01 22 01 01 02 02 07 03 02 04 03 06 02 C1 02 C2 02 C3 06 C3 02 C2 02 C1 02 06 02 04 02 03 01 02 01 01 09 7F";
            }


            //Trạm D14 (Kí hiệu: C4, STT: 11)
            //AGV1
            if (radioButtonAgv1.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "11") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "11")))
            {
                textBoxTest.Text = "7A 2F 01 01 FE 00 04 01 26 01 01 02 02 07 03 02 04 03 06 02 C1 02 C2 02 C3 02 C4 06 C4 06 C3 02 C2 02 C1 02 06 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV2
            if (radioButtonAgv2.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "11") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "11")))
            {
                textBoxTest.Text = "7A 2F 01 02 FE 00 04 01 26 01 01 02 02 07 03 02 04 03 06 02 C1 02 C2 02 C3 02 C4 06 C4 06 C3 02 C2 02 C1 02 06 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV3
            if (radioButtonAgv3.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "11") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "11")))
            {
                textBoxTest.Text = "7A 2F 01 03 FE 00 04 01 26 01 01 02 02 07 03 02 04 03 06 02 C1 02 C2 02 C3 02 C4 06 C4 06 C3 02 C2 02 C1 02 06 02 04 02 03 01 02 01 01 09 7F";
            }

            //Trạm D15 (kí hiệu: C5, STT: 12)
            //AGV1
            if (radioButtonAgv1.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "12") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "12")))
            {
                textBoxTest.Text = "7A 33 01 01 FE 00 05 01 2A 01 01 02 02 07 03 02 04 03 06 02 C1 02 C2 02 C3 02 C4 02 C5 06 C5 06 C4 02 C3 02 C2 02 C1 02 06 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV2
            if (radioButtonAgv2.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "12") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "12")))
            {
                textBoxTest.Text = "7A 33 01 02 FE 00 05 01 2A 01 01 02 02 07 03 02 04 03 06 02 C1 02 C2 02 C3 02 C4 02 C5 06 C5 06 C4 02 C3 02 C2 02 C1 02 06 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV3
            if (radioButtonAgv1.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "12") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "12")))
            {
                textBoxTest.Text = "7A 33 01 03 FE 00 05 01 2A 01 01 02 02 07 03 02 04 03 06 02 C1 02 C2 02 C3 02 C4 02 C5 06 C5 06 C4 02 C3 02 C2 02 C1 02 06 02 04 02 03 01 02 01 01 09 7F";
            }

            //Trạm D16 (Kí hiệu: C6, STT: 13)
            //AGV1
            if (radioButtonAgv1.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "13") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "13")))
            {
                textBoxTest.Text = "7A 37 01 01 FE 00 06 01 2E 01 01 02 02 07 03 02 04 03 06 02 C1 02 C2 02 C3 02 C4 02 C5 02 C6 06 C6 02 C5 02 C4 02 C3 02 C2 02 C1 02 06 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV2
            if (radioButtonAgv2.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "13") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "13")))
            {
                textBoxTest.Text = "7A 37 01 02 FE 00 06 01 2E 01 01 02 02 07 03 02 04 03 06 02 C1 02 C2 02 C3 02 C4 02 C5 02 C6 06 C6 02 C5 02 C4 02 C3 02 C2 02 C1 02 06 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV3
            if (radioButtonAgv3.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "13") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "13")))
            {
                textBoxTest.Text = "7A 37 01 03 FE 00 06 01 2E 01 01 02 02 07 03 02 04 03 06 02 C1 02 C2 02 C3 02 C4 02 C5 02 C6 06 C6 02 C5 02 C4 02 C3 02 C2 02 C1 02 06 02 04 02 03 01 02 01 01 09 7F";
            }

            //Trạm D17 (Kí hiệu: C7, STT: 14)
            //AGV1
            if (radioButtonAgv1.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "14") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "14")))
            {
                textBoxTest.Text = "7A 3B 01 01 FE 00 07 01 32 01 01 02 02 07 03 02 04 03 06 02 C1 02 C2 02 C3 02 C4 02 C5 02 C6 02 C7 06 C7 02 C6 02 C5 02 C4 02 C3 02 C2 02 C1 02 06 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV2
            if (radioButtonAgv2.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "14") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "14")))
            {
                textBoxTest.Text = "7A 3B 01 02 FE 00 07 01 32 01 01 02 02 07 03 02 04 03 06 02 C1 02 C2 02 C3 02 C4 02 C5 02 C6 02 C7 06 C7 02 C6 02 C5 02 C4 02 C3 02 C2 02 C1 02 06 02 04 02 03 01 02 01 01 09 7F";
            }

            //AGV3
            if (radioButtonAgv3.Checked == true && ((comboBoxFeedingStation1.Text == "1" && labelFeedingDeliveryStation1.Text == "14") || (comboBoxFeedingStation2.Text == "1" && labelFeedingDeliveryStation2.Text == "14")))
            {
                textBoxTest.Text = "7A 3B 01 02 FE 00 07 01 32 01 01 02 02 07 03 02 04 03 06 02 C1 02 C2 02 C3 02 C4 02 C5 02 C6 02 C7 06 C7 02 C6 02 C5 02 C4 02 C3 02 C2 02 C1 02 06 02 04 02 03 01 02 01 01 09 7F";
            }
        }
       
    }
}
