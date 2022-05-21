/* 
 * Copyright (C) Hanoi University of Science and Technology - All Rights Reserved
 * This file is written as part of Automated Guided Vehicles (AGV) Management System project. 
 * The project is developed and managed by the team in Department of Industrial Automation (DIA), 
 * School of Electrical and Computer Engineering (SEE), 
 * Hanoi University of Science and Technology (HUST).
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Hoang Duc Chinh <dc.hoang.vn@gmail.com>, 2020 November
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace rangdong_agv
{
    public partial class FormMain_test : Form
    {
        private String com_port_name = "";
        //private List<Vehicle> vehicleList;
        // private List<Station> stationList;
        private SerialPort ComPort = new SerialPort("COM1", 115200, Parity.None, 8, StopBits.One);
        //private Thread readThread;
        //private bool stopReadThread = true;
        private CancellationTokenSource readComPortThread_cts;
        private byte trip_id = 0;

        public FormMain_test()
        {
            InitializeComponent();
            
            this.readComPortThread_cts = new CancellationTokenSource();
            this.comboBoxMaterial1.SelectedIndex = 0;
            this.comboBoxMaterial2.SelectedIndex = 0;
            this.comboBoxAgvMode.SelectedIndex = 0;
            
            // for test layout
            this.checkBoxAGV1.Checked = true;
            this.checkBoxAGV2.Enabled = false;
            this.checkBoxAGV3.Enabled = false;
            this.radioButtonTestAGV1.Checked = true;
            this.radioButtonTestAGV2.Enabled = false;
            this.radioButtonTestAGV3.Enabled = false;

            this.comboBoxRfidBw1.SelectedIndex = 0;
            this.comboBoxRfidBw2.SelectedIndex = 0;
            this.comboBoxRfidBw3.SelectedIndex = 0;
            this.comboBoxRfidBw4.SelectedIndex = 0;
            this.comboBoxRfidBw5.SelectedIndex = 0;
            this.comboBoxRfidBw6.SelectedIndex = 0;
            this.comboBoxRfidBw7.SelectedIndex = 0;

            this.comboBoxRfidFw1.SelectedIndex = 0;
            this.comboBoxRfidFw2.SelectedIndex = 0;
            this.comboBoxRfidFw3.SelectedIndex = 0;
            this.comboBoxRfidFw4.SelectedIndex = 0;
            this.comboBoxRfidFw5.SelectedIndex = 0;
            this.comboBoxRfidFw6.SelectedIndex = 0;
            this.comboBoxRfidFw7.SelectedIndex = 0;

            this.getComPortList();
        }
        
        /*********************************************************************
         * A function to get all the COM port available and show in the combo
         * box COM port
         ********************************************************************/
        private void getComPortList()
        {
            string[] ArrayComPortsNames = null;
            int index = -1;
            string ComPortName = null;

            this.comboxCommPort.Items.Clear();
            ArrayComPortsNames = SerialPort.GetPortNames();
            if (ArrayComPortsNames.Length > 0) { 
                // Add com port if found new
                do
                {
                    index += 1;

                    bool itemExists = false;

                    //foreach (ComboBoxItem cbi in this.comboxCommPort.Items)
                    //{

                    //}
                    if (!this.comboxCommPort.Items.Contains(ArrayComPortsNames[index])) {
                        this.comboxCommPort.Items.Add(ArrayComPortsNames[index]);
                    }
                    // rtbIncoming.Text += ArrayComPortsNames[index] + "\n";
                }
                while (!((ArrayComPortsNames[index] == ComPortName) ||
                        (index == ArrayComPortsNames.GetUpperBound(0))));

                // remove COM port if not exist
                //String[] portListToRemove = new String[] { };
                //foreach (var item in this.comboxCommPort.Items)
                //{
                //    if (!ArrayComPortsNames.Contains(item.ToString()))
                //    {
                //        portListToRemove.Append(item.ToString());                        
                //    }
                //}

                //if (portListToRemove.Length > 0)
                //{
                //    foreach (string portName in portListToRemove)
                //    {
                //        this.comboxCommPort.Items.Remove(portName);
                //    }
                //}
            }
            else
            {
                MessageBox.Show("No COM port is available!");
                this.comboxCommPort.Items.Clear(); // Clear the COM port list if nothing exists
            }
        }

        private void pictureAGV1_Click(object sender, EventArgs e)
        {
            var b = sender as PictureBox;
            // MessageBox.Show(string.Format("{0} Clicked", b.Text));
        }

        private void pictureAGV2_Click(object sender, EventArgs e)
        {

        }

        private void btnStation1_Click(object sender, EventArgs e)
        {
            var b = sender as Button;
            MessageBox.Show(string.Format("{0} call AGV!", b.Text));
        }

        /* Once Connect button is click, 
         * try to connect to the selected COM port
         * if success, start a thread to receive message
         */
        private void btnComPortConnect_Click(object sender, EventArgs e)
        {
            string com_port_name_temp = "";
            if (this.comboxCommPort.SelectedItem != null)
                com_port_name_temp = this.comboxCommPort.SelectedItem.ToString();
            else
            {
                MessageBox.Show("No COM port is available!");
            }

            if (com_port_name_temp.Length == 0)
            {
                MessageBox.Show("Please select a COM port in the list!");
            }
            else
            {
                if (this.ComPort.IsOpen)
                {
                    this.closingCOMport();
                }

                if (this.com_port_name != com_port_name_temp)
                {
                    this.com_port_name = com_port_name_temp;
                }

                try
                {
                    ComPort.PortName = com_port_name;
                    ComPort.Open();
                    if (ComPort.IsOpen)
                    {
                        this.btnComPortConnect.Enabled = false;
                        this.btnComPortDisconnect.Enabled = true;
                        this.btnScanCOM.Enabled = false;
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (this.ComPort.IsOpen)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.ReadComPort), this.readComPortThread_cts.Token);
                }
            }
        }

        //private void Read(SerialPort _serialPort)
        private void ReadComPort(object obj)
        {
            byte[] data_buffer = new byte[4096];
            int data_count = 0;
            bool first_byte = true;

            CancellationToken token = (CancellationToken)obj;

            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }

                try
                {
                    int count = 0;
                    byte[] buffer = new byte[ComPort.ReadBufferSize];
                    count = ComPort.Read(buffer, 0, buffer.Length);

                    if (first_byte && count == 1)
                    {
                        data_buffer[0] = buffer[0];
                        first_byte = false;
                        data_count = 1;
                    }
                    else
                    {
                        if (data_count == 1)
                        {
                            Buffer.BlockCopy(buffer, 0, data_buffer, 1, count);
                            string raw_message = System.Text.Encoding.Default.GetString(data_buffer, 0, count+1);
                            raw_message = BitConverter.ToString(data_buffer, 0, count+1).Replace("-", " ");

                            string parsed_message = "";
                            //AgvParamPacket agvParamPacket = new AgvParamPacket();
                            ////byte[] byteArrayToReceive = convertStringToHex(value);
                            //if (agvParamPacket.isAgvParamPacket(data_buffer))
                            //{
                            //    parsed_message = agvParamPacket.getPayloadString(data_buffer);
                            //}


                            LoraGenericPacket rxLoraPacket = new LoraGenericPacket();

                            byte message_type = rxLoraPacket.getMessageType(data_buffer);
                            // get current timestamp

                            if (message_type == LoraGenericPacket.PARAM_PACKET_TYPE)
                            {
                                AgvParamPacket agvParamPacket = new AgvParamPacket();
                                //byte[] byteArrayToReceive = convertStringToHex(value);

                                // depends on message type, the message will be parsed accordingly
                                if (agvParamPacket.isAgvParamPacket(data_buffer))
                                {
                                    parsed_message = agvParamPacket.getPayloadString(data_buffer);
                                    //AgvParams agvParams = new AgvParams();
                                    //agvParams.updateAgvParams(agvParamPacket);

                                    // show on FormAgvOverview
                                    //this.formAgvOverview.AgvParams = agvParams;
                                    //this.formAgvOverview.updateAgvDetails();
                                    // insert into database
                                }
                            }

                            Console.WriteLine(raw_message);
                            if (parsed_message.Length > 0)
                                Console.WriteLine(parsed_message);
                            AppendTextBox(raw_message, parsed_message);
                            data_count = 0;
                            first_byte = true;
                        }
                    }
                }
                catch (TimeoutException) { }
                catch (InvalidOperationException)
                {
                    //if (!ComPort.IsOpen)
                    //{
                    //    ComPort.Open();
                    //}                    
                }
                catch (System.IO.IOException) { }
                finally
                {

                }
            }
            //ComPort.Close();
        }

        public void AppendTextBox(string raw_value, string parsed_value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string, string>(AppendTextBox), new object[] { raw_value, parsed_value });
                return;
            }
            txtBoxRxMsg.Text += raw_value;

            if (parsed_value.Length > 0)
            {
                txtBoxRxMsgTest.Text = parsed_value;
            }
            else
                txtBoxRxMsgTest.Text = "Cannot parse! " + raw_value;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.closingCOMport();
            Environment.Exit(Environment.ExitCode); // to close everything including running threads!
        }

        private void btnClearRxMsg_Click(object sender, EventArgs e)
        {
            this.txtBoxRxMsg.Text = "";
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            if (this.txtBoxSendMsg.Text.Length > 0)
            {
                string message = this.txtBoxSendMsg.Text;
                byte[] byteArrayToSend = convertStringToHex(message);

                ComPort.Write(byteArrayToSend, 0, byteArrayToSend.Length);
            }
        }

        private byte[] convertStringToHex(string inputString)
        {            
            char[] values = inputString.ToCharArray();
            byte[] outputArray = new byte[values.Length];
            int i = 0;
            foreach (char letter in values)
            {
                outputArray[i] = Convert.ToByte(letter);
                i++;
                // Get the integral value of the character.
                //int value = Convert.ToInt32(letter);
                // Convert the integer value to a hexadecimal value in string form.
                //Console.WriteLine($"Hexadecimal value of {letter} is {value:X}");
            }
            return outputArray;
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The system is developed by Department of Industrial Automation, SEE, HUST. The team are: Dr. Hoang Duc Chinh, ...");
        }

        private void closingCOMport()
        {
            if (this.ComPort.IsOpen)
            {
                this.ComPort.Close();
            }
            this.readComPortThread_cts.Cancel();
            Thread.Sleep(2000);
            this.readComPortThread_cts.Dispose();
            this.readComPortThread_cts = new CancellationTokenSource(); // renew cancellation requets 
        }

        private void btnComPortDisconnect_Click(object sender, EventArgs e)
        {
            this.closingCOMport();
            this.btnComPortConnect.Enabled = true;
            this.btnComPortDisconnect.Enabled = false;
            this.btnScanCOM.Enabled = true;
        }

        private void btnAGV3_Click(object sender, EventArgs e)
        {

        }

        private void buttonTestConfirmMaterial_Click(object sender, EventArgs e)
        {
            string strMaterial1 = this.comboBoxMaterial1.SelectedItem.ToString();
            string strMaterial2 = this.comboBoxMaterial2.SelectedItem.ToString();
            AgvMaterialPacket agvMaterialPacket = new AgvMaterialPacket();
            byte deliveryStation1 = 0x01;
            byte deliveryStation2 = 0x02;

            if (!checkBoxTestStation1.Checked & !checkBoxTestStation2.Checked)
            {
                MessageBox.Show("Please select a station!");
                return;
            }

            if (strMaterial1 == "None" & strMaterial2 == "None")
            {
                MessageBox.Show("Please select 1 material");
                return;
            }

            if (strMaterial1 != "None" & strMaterial2 != "None")
            {
                agvMaterialPacket.setMaterialAndReceiver(0x01, deliveryStation1, convertStringToHex(strMaterial1), deliveryStation2, convertStringToHex(strMaterial2));
            }
            else
            {
                if (strMaterial1 != "None")
                {
                    //if (!checkBoxTestStation1.Checked)
                    //{
                    //    MessageBox.Show("Please select station 1!");
                    //    return;
                    //}
                    agvMaterialPacket.setMaterialAndReceiver(0x01, deliveryStation1, convertStringToHex(strMaterial1));
                    
                }

                if (strMaterial2 != "None")
                {
                    if (!checkBoxTestStation2.Checked)
                    {
                        MessageBox.Show("Please select station 2!");
                        return;
                    }
                    agvMaterialPacket.setMaterialAndReceiver(0x02, deliveryStation2, convertStringToHex(strMaterial2));
                }
            }
            Console.WriteLine(BitConverter.ToString(agvMaterialPacket.OutputPacket));
            ComPort.Write(agvMaterialPacket.OutputPacket, 0, agvMaterialPacket.OutputPacket.Length);
        }

        private void buttonTestStartDelivery_Click(object sender, EventArgs e)
        {
            CheckBox[] routeTagList = new CheckBox[] { checkBoxRfid1, checkBoxRfid2, checkBoxRfid3, checkBoxRfid4, checkBoxRfid5, checkBoxRfid6, checkBoxRfid7, checkBoxTestStation1, checkBoxTestStation2, checkBoxRfid10 };
            ComboBox[] forwardCmdList = new ComboBox[] { comboBoxRfidFw1, comboBoxRfidFw2, comboBoxRfidFw3, comboBoxRfidFw4, comboBoxRfidFw5, comboBoxRfidFw6, comboBoxRfidFw7, comboBoxRfidFw10 };
            ComboBox[] backwardCmdList = new ComboBox[] { comboBoxRfidBw1, comboBoxRfidBw2, comboBoxRfidBw3, comboBoxRfidBw4, comboBoxRfidBw5, comboBoxRfidBw6, comboBoxRfidBw7, comboBoxRfidBw8, comboBoxRfidBw9, comboBoxRfidFw10 };

            var tagCmdList = new List<TagCommand>();
            var tagCmdBackwardList = new List<TagCommand>();
                        
            for (int i = 0; i < 9; i++)
            {
                if (routeTagList[i].Checked)
                {
                    TagCommand tagCmdTemp = new TagCommand();
                    TagCommand tagCmdBwTemp = new TagCommand();
                    tagCmdTemp.TagId = (byte) (i + 1);
                    tagCmdBwTemp.TagId = tagCmdTemp.TagId;
                    if (i != 7 & i != 8 & i!=9)
                    {
                        tagCmdTemp.setTagCommand(forwardCmdList[i].Text); // Going forward
                        tagCmdBwTemp.setTagCommand(backwardCmdList[i].Text); // Going backward
                    }
                    if (i == 7 | i == 8)
                    {
                        tagCmdTemp.setTagCommand("DeliverLeft"); // Going forward
                        // tagCmdBwTemp.setTagCommand("Deliver");
                        tagCmdBwTemp.setTagCommand(backwardCmdList[i].Text); // Going backward
                    }
                    if (i == 10)
                    {
                        // not decided yet
                    }
                    tagCmdList.Add(tagCmdTemp);
                    tagCmdBackwardList.Add(tagCmdBwTemp);
                }
            }

            if (tagCmdBackwardList.Count > 0)
                tagCmdBackwardList.Reverse();

            foreach (TagCommand _tagCommand in tagCmdBackwardList)
            {
                tagCmdList.Add(_tagCommand);
            }

            // build route message based on selected check box in GUI
            if (tagCmdList.Count > 0)
            {
                byte[] tripRouteData = new byte[tagCmdList.Count*2];
                int idx = 0;

                foreach (TagCommand _tagCommand in tagCmdList)
                {
                    byte[] idCmdPair = _tagCommand.getIdCmdPair();
                    Buffer.BlockCopy(idCmdPair, 0, tripRouteData, idx, idCmdPair.Length);
                    idx += idCmdPair.Length;
                }
                RoutePacket routePacket = new RoutePacket();
                //routePacket.setTripRouteAndReceiver(0x01, payloadData);
                if (trip_id > 50)
                    trip_id = 0;
                else
                    trip_id++;

                routePacket.setTripRouteAndReceiver(0x01, trip_id, tripRouteData);
                Console.WriteLine(BitConverter.ToString(routePacket.OutputPacket).Replace("-", " "));
                ComPort.Write(routePacket.OutputPacket, 0, routePacket.OutputPacket.Length);
            }
        }

        private void buttonTestCallAGV_Click(object sender, EventArgs e)
        {
            if (!checkBoxAGV1.Checked & !checkBoxAGV2.Checked & !checkBoxAGV3.Checked)
            {
                MessageBox.Show("Please select 1 AGV");
            }

            //byte agvMode = 0x01;
            //string strAgvMode = this.comboBoxAgvMode.SelectedItem.ToString();
            byte agvMode = (byte) (this.comboBoxAgvMode.SelectedIndex + 1);

            AgvCallPacket agvCallPacket = new AgvCallPacket();
            agvCallPacket.setReceiverAndCommand(0x04, agvMode);

            Console.WriteLine(BitConverter.ToString(agvCallPacket.OutputPacket));
            ComPort.Write(agvCallPacket.OutputPacket, 0, agvCallPacket.OutputPacket.Length);
        }

        private void radioButtonTestAGV1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTestAGV1.Checked)
            {
                checkBoxAGV1.Checked = true;
            }
            //else
            //{
            //    checkBoxAGV1.Checked = false;
            //}
        }

        private void radioButtonTestAGV2_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (radioButtonTestAGV2.Checked)
                {
                    checkBoxAGV2.Checked = true;
                }
            }
        }

        private void radioButtonTestAGV3_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (radioButtonTestAGV3.Checked)
                {
                    checkBoxAGV3.Checked = true;
                }
            }
        }

        private void comboBoxMaterial1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strMaterial = this.comboBoxMaterial1.SelectedItem.ToString();
            if (strMaterial == "None")
            {
                checkBoxTestStation1.Checked = false;
            }
            else
            {
                checkBoxTestStation1.Checked = true;
            }
        }

        private void comboBoxMaterial2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strMaterial = this.comboBoxMaterial2.SelectedItem.ToString();
            if (strMaterial == "None")
            {
                checkBoxTestStation2.Checked = false;
            }
            else
            {
                checkBoxTestStation2.Checked = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnClearRxMsgTest_Click(object sender, EventArgs e)
        {
            this.txtBoxRxMsgTest.Text = "";
        }

        private void btnScanCOM_Click(object sender, EventArgs e)
        {
            this.getComPortList();
        }

        private void comboxCommPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.getComPortList();
        }

        private void comboxCommPort_DropDown(object sender, EventArgs e)
        {
            this.getComPortList();
        }
    }
}
