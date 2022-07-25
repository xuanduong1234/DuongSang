using System;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.Linq;

//
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//
//using System.Text;


namespace rangdong_agv
{
    public partial class FormMain : Form
    {
        private String comPortName = "";
        //private SerialPort comPort = new SerialPort("COM1", 115200, Parity.None, 8, StopBits.One); // default settings for comport
        private SerialPort comPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One); // default settings for comport
        private CancellationTokenSource readComPortThread_cts;

        private FormAgvOverview formAgvOverview;
        private FormDelivery formDelivery;
        private FormReport formReport;
        private FormSchedule formSchedule;
        private FormSetting formSetting;
        private FormAbout formAbout;
        private Chart formChart;
        private FormDoThi formDoThi;
        private FormError formError;
        private Calender frormCalender;

        private AgvInfo agvInfo;
        private AgvParams agvParams;

        public FormMain()
        {
            this.readComPortThread_cts = new CancellationTokenSource();
            InitializeComponent();

            this.comPort = new SerialPort();
            this.agvInfo = new AgvInfo();
            this.agvParams = new AgvParams();

            this.formAgvOverview = new FormAgvOverview();
            //this.formDelivery = new FormDelivery(this);
            this.formDelivery = new FormDelivery(this.agvParams, this.comPort);
            this.formReport = new FormReport();
            this.formSchedule = new FormSchedule();
            this.formSetting = new FormSetting();
            this.formAbout = new FormAbout();
            this.formChart = new Chart();
            this.formDoThi = new FormDoThi();
            this.formError = new FormError();
            this.frormCalender = new Calender();
            this.openChildForm(formAgvOverview);
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

            this.comboBoxComPort.Items.Clear();
            ArrayComPortsNames = SerialPort.GetPortNames();
            if (ArrayComPortsNames.Length > 0)
            {
                // Add com port if found new
                do
                {
                    index += 1;

                    if (!this.comboBoxComPort.Items.Contains(ArrayComPortsNames[index]))
                    {
                        this.comboBoxComPort.Items.Add(ArrayComPortsNames[index]);
                    }
                }
                while (!((ArrayComPortsNames[index] == ComPortName) ||
                        (index == ArrayComPortsNames.GetUpperBound(0))));
            }
            else
            {
                MessageBox.Show("No COM port is available!");
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string comPortNameTemp = "";
            if (this.comboBoxComPort.SelectedItem != null)
                comPortNameTemp = this.comboBoxComPort.SelectedItem.ToString();
            else
            {
                MessageBox.Show("No COM port is available!");
            }

            if (comPortNameTemp.Length == 0)
            {
                MessageBox.Show("Please select a COM port in the list!");
            }
            else
            {
                if (this.comPort.IsOpen)
                {
                    try
                    {
                        this.closeComPort(false);
                    }
                    catch (IOException ex) {
                        MessageBox.Show("COM port is already closed!");
                    }
                    
                }

                if (this.comPortName != comPortNameTemp)
                {
                    this.comPortName = comPortNameTemp;
                }

                try
                {
                    this.comPort.PortName = comPortName;
                    comPort.Open();
                    if (comPort.IsOpen)
                    {
                        this.btnConnect.Enabled = false;
                        this.btnDisconnect.Enabled = true;
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }


                if (this.comPort.IsOpen)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.ReadComPort), this.readComPortThread_cts.Token);
                }
            }
        }

        /*
         * read data from comport
         */
        private void ReadComPort(object obj)
        {
            byte[] data_buffer = new byte[4096];
            int data_count = 0;
            bool first_byte = true;

            CancellationToken token = (CancellationToken)obj;

            int messageComplete = 0; // 0: incomplete; 1: complete; 2: error

            while (true)
            {
                if (token.IsCancellationRequested) // if requesting to stop this thread, break the loop
                {
                    break;
                }

                // try to read from buffer
                try
                {
                    int count = 0;
                    byte[] buffer = new byte[comPort.ReadBufferSize];
                    count = comPort.Read(buffer, 0, buffer.Length);

                    string raw_message1 = System.Text.Encoding.Default.GetString(buffer, 0, count);
                    raw_message1 = BitConverter.ToString(buffer, 0, count).Replace("-", " ");
                    Console.WriteLine("Buffer count: " + count.ToString());
                    Console.WriteLine(raw_message1);

                    if (buffer[0] == LoraGenericPacket.START_BYTE && data_count == 0)
                    {
                        data_count = count;
                        Buffer.BlockCopy(buffer, 0, data_buffer, 0, count);
                    }
                    else
                    {
                        if (data_count > 0)
                        {
                            Buffer.BlockCopy(buffer, 0, data_buffer, data_count, count);
                            data_count += count;


                            if (data_buffer[data_count - 1] == LoraGenericPacket.END_BYTE && data_count == data_buffer[1]) // complete packet
                            {
                                messageComplete = 1;
                            }
                            if (data_count > data_buffer[1])
                            {
                                messageComplete = 2;

                                string raw_message = "";
                                string parsed_message = "";
                                AppendTextBox(raw_message, parsed_message);
                            }
                        }
                    }

                    if (messageComplete == 1)
                    {
                        // convert byte array into string
                        string raw_message = System.Text.Encoding.Default.GetString(data_buffer, 0, data_count);
                        raw_message = BitConverter.ToString(data_buffer, 0, data_count).Replace("-", " ");

                        string parsed_message = "";
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
                                agvParams.updateAgvParams(agvParamPacket);

                                // show on FormAgvOverview
                                this.formAgvOverview.AgvParams = agvParams;
                                //this.formAgvOverview.updateAgvDetails();
                                // insert into database
                            }
                        }

                        if (message_type == LoraGenericPacket.REPLY_AGV_CALL_PACKET_TYPE)
                        {
                            ReplyAgvCall replyAgvCall = new ReplyAgvCall();
                            if (replyAgvCall.isReplyAgvCall(data_buffer))
                            {
                                parsed_message = replyAgvCall.getPayloadString(data_buffer); ;
                            }
                        }

                        if (message_type == LoraGenericPacket.AGV_FEEDING_STATUS_TYPE)
                        {
                            AgvFeedingStatus agvFeedingStatus = new AgvFeedingStatus();
                            if (agvFeedingStatus.isAgvFeedingStatus(data_buffer))
                            {
                                parsed_message = agvFeedingStatus.getPayloadString(data_buffer); ;
                            }
                        }

                        if (message_type == LoraGenericPacket.AGV_DELIVERY_STATUS_TYPE)
                        {
                            AgvDeliveryStatus agvDeliveryStatus = new AgvDeliveryStatus();
                            if (agvDeliveryStatus.isAgvDeliveryStatus(data_buffer))
                            {
                                parsed_message = agvDeliveryStatus.getPayloadString(data_buffer); ;
                            }
                        }

                        if (message_type == LoraGenericPacket.AGV_EMPTY_TRAY_COLLECT_TYPE)
                        {
                            AgvEmptyTrayCollect agvEmptyTrayCollect = new AgvEmptyTrayCollect();
                            if (agvEmptyTrayCollect.isAgvEmptyTrayCollect(data_buffer))
                            {
                                parsed_message = agvEmptyTrayCollect.getPayloadString(data_buffer); ;
                            }
                        }

                        if (message_type == LoraGenericPacket.AGV_EMPTY_TRAY_RETURN_TYPE)
                        {
                            AgvEmptyTrayReturn agvEmptyTrayReturn = new AgvEmptyTrayReturn();
                            if (agvEmptyTrayReturn.isAgvEmptyTrayReturn(data_buffer))
                            {
                                parsed_message = agvEmptyTrayReturn.getPayloadString(data_buffer); ;
                            }
                        }

                        if (message_type == LoraGenericPacket.DELIVERY_STATION_REQUEST_MATERIAL_TYPE)
                        {
                            DeliveryStationRequestMaterial deliveryStationRequestMaterial = new DeliveryStationRequestMaterial();
                            if (deliveryStationRequestMaterial.isDeliveryStationRequestMaterial(data_buffer))
                            {
                                parsed_message = deliveryStationRequestMaterial.getPayloadString(data_buffer); ;
                            }
                        }

                        // for testing only
                        Console.WriteLine(raw_message);
                        if (parsed_message.Length > 0)
                            Console.WriteLine(parsed_message);
                        AppendTextBox(raw_message, parsed_message);
                    }

                    if (messageComplete != 0)
                    {
                        // for reading the next message
                        data_buffer = new byte[4096];
                        data_count = 0;
                        first_byte = true;
                        messageComplete = 0;
                    }

                    //// E90: byte array - first byte is read individually, next read will get the rest of the packet
                    //if (first_byte && count == 1) // to deal with getting the first byte only
                    //{
                    //    data_buffer[0] = buffer[0];
                    //    first_byte = false;
                    //    data_count = 1;
                    //}
                    //else
                    //{
                    //    if (data_count == 1)
                    //    {
                    //        Buffer.BlockCopy(buffer, 0, data_buffer, 1, count);

                    //        // convert byte array into string
                    //        string raw_message = System.Text.Encoding.Default.GetString(data_buffer, 0, count + 1);
                    //        raw_message = BitConverter.ToString(data_buffer, 0, count + 1).Replace("-", " ");

                    //        string parsed_message = "";
                    //        LoraGenericPacket rxLoraPacket = new LoraGenericPacket();

                    //        byte message_type = rxLoraPacket.getMessageType(data_buffer);
                    //        // get current timestamp

                    //        if (message_type == LoraGenericPacket.PARAM_PACKET_TYPE)
                    //        {
                    //            AgvParamPacket agvParamPacket = new AgvParamPacket();
                    //            //byte[] byteArrayToReceive = convertStringToHex(value);

                    //            // depends on message type, the message will be parsed accordingly
                    //            if (agvParamPacket.isAgvParamPacket(data_buffer))
                    //            {
                    //                parsed_message = agvParamPacket.getPayloadString(data_buffer);
                    //                //AgvParams agvParams = new AgvParams();
                    //                agvParams.updateAgvParams(agvParamPacket);

                    //                // show on FormAgvOverview
                    //                this.formAgvOverview.AgvParams=agvParams;
                    //                //this.formAgvOverview.updateAgvDetails();
                    //                // insert into database
                    //            }
                    //        }
                    //        //if (message_type == LoraGenericPacket.)

                    //        // for testing only
                    //        Console.WriteLine(raw_message);
                    //        if (parsed_message.Length > 0)
                    //            Console.WriteLine(parsed_message);
                    //        AppendTextBox(raw_message, parsed_message);

                    //        // for reading the next message
                    //        data_count = 0;
                    //        first_byte = true;
                    //    }
                }
                catch (TimeoutException) { }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Some errors: " + ex.Message);
                    //if (!comPort.IsOpen)
                    //{
                    //    comPort.Open();
                    //}                    
                }
                catch (System.IO.IOException) { }
                finally
                {

                }
            }
            //comPort.Close();
        }


        // For testing only
        public void AppendTextBox(string raw_value, string parsed_value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string, string>(AppendTextBox), new object[] { raw_value, parsed_value });
                return;
            }
            txtBoxRxMsgTest.Text += raw_value;

            if (parsed_value.Length > 0)
            {
                txtBoxRxMsgTest.Text = parsed_value;
            }
            else
                txtBoxRxMsgTest.Text = "Cannot parse! " + raw_value;
        }

        private void closeComPort(bool isExit)
        {
            // close the current reading thread as well
            try
            {
                this.readComPortThread_cts.Cancel();
                Thread.Sleep(500); // need to change back to 2000 ms later
                this.readComPortThread_cts.Dispose();
                if (!isExit)
                    this.readComPortThread_cts = new CancellationTokenSource(); // renew cancellation requets 
            }
            catch (ObjectDisposedException ex)
            {
                // do nothing
            }

            // close the comport
            if (this.comPort.IsOpen)
            {
                try
                {
                    //this.closeComPort(false);
                    this.comPort.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show("COM port is already closed!");
                }
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            this.closeComPort(false);
            this.btnConnect.Enabled = true;
            this.btnDisconnect.Enabled = false;
        }

        private void comboxComPort_DropDown(object sender, EventArgs e)
        {
            this.getComPortList();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to exit the program?", "Exit", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                this.closeComPort(true);
                Environment.Exit(Environment.ExitCode); // to close everything including running threads!
                //Application.Exit();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Form activeForm = null;

        public AgvParams AgvParams { get => agvParams; set => agvParams = value; }

        private void openChildForm(Form childForm)
        {
            //if (activeForm != null) activeForm.Close();            
            if (activeForm != null) activeForm.Hide();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnOverview_Click(object sender, EventArgs e)
        {
            this.openChildForm(formAgvOverview);
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            this.openChildForm(formDelivery);
        }
     
        private void btnAbout_Click(object sender, EventArgs e)
        {
            this.openChildForm(formAbout);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.openChildForm(formReport);
        }
           
        private void btnError_Click(object sender, EventArgs e)
        {
            this.openChildForm(formError);
            
        }

        private void btnChart_Click_1(object sender, EventArgs e)
        {
            this.openChildForm(formDoThi);
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            this.openChildForm(formDoThi);
        }

        private void btnSchedule_Click_1(object sender, EventArgs e)
        {
            this.openChildForm(frormCalender);
        }

        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            this.openChildForm(formSetting);
        }
    }
}
