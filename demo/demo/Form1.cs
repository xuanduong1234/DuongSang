using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace demo
{
    public partial class Form1 : Form
    {
        byte[] Saochep = new byte[4096];
        byte ROUTE_PACKET_TYPE = 0x01;

        //Line trạm nhận 1
        byte TramNhan_D01 = 0x07;
        byte TramNhan_D02 = 0x08;
        byte TramNhan_D03 = 0x09;
        byte TramNhan_D04 = 0x0A;
        byte TramNhan_D05 = 0x0B;
        byte TramNhan_D06 = 0x0C;
        byte TramNhan_D07 = 0x0D;

        //Line trạm nhận 2
        byte TramNhan_D11 = 0xC1;
        byte TramNhan_D12 = 0xC2;
        Byte TramNhan_D13 = 0xC3;
        byte TramNhan_D14 = 0xC4;
        byte TramNhan_D15 = 0xC5;
        byte TramNhan_D16 = 0xC6;
        byte TramNhan_D17 = 0xC7;

        int Message_type_ofset = 7;
        int State_ofset = 11;
        int TripId_ofset = 9;
        int Position_ofset = 10;
        int Count = 0;
        float Bat_cap = 100;

        private String comPortName = "";
        public SerialPort comPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One); // default settings for comport
        private CancellationTokenSource readComPortThread_cts;

        public Form1()
        {
            InitializeComponent();
            this.readComPortThread_cts = new CancellationTokenSource();
            this.getComPortList();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

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

        private void BtnConnect_Click(object sender, EventArgs e)
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
                    catch (IOException)
                    {
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
                        this.BtnConnect.Enabled = false;
                        this.BtnDisconnect.Enabled = true;
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

        private void closeComPort(bool isExit)
        {
            try
            {
                this.readComPortThread_cts.Cancel();
                Thread.Sleep(500); // need to change back to 2000 ms later
                this.readComPortThread_cts.Dispose();
                if (!isExit)
                    this.readComPortThread_cts = new CancellationTokenSource(); // renew cancellation requets 
            }
            catch (ObjectDisposedException)
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
                catch (IOException)
                {
                    MessageBox.Show("COM port is already closed!");
                }
            }
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            this.closeComPort(false);
            this.BtnConnect.Enabled = true;
            this.BtnDisconnect.Enabled = false;
            txtBoxRxMsgTest.Text = "";
        }

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
                txtBoxRxMsgTest.Text = "Cannot parse! abc" + raw_value;
        }

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

                    if (data_count == 0)
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

                            if (data_count == data_buffer[1]) // complete packet
                            {
                                messageComplete = 1;
                                Saochep = data_buffer;
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
                        Console.WriteLine(raw_message);
                        txtBoxRxMsgTest.Text = raw_message;
                    }

                    if (messageComplete != 0)
                    {
                        // for reading the next message
                        data_buffer = new byte[4096];
                        data_count = 0;
                        first_byte = true;
                        messageComplete = 0;
                    }
                }
                catch (TimeoutException) { }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Some errors: " + ex.Message);
                }
                catch (System.IO.IOException) { }
                finally
                {

                }
            }

            
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            DialogResult answer = MessageBox.Show("Do you want to exit program?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //State
            txtSate.Text = Saochep[State_ofset].ToString();
            State_ofset += 2;

            //TripId
            txtTrip_Id.Text = Saochep[TripId_ofset].ToString();

            //Position
            txtPosition.Text = Saochep[Position_ofset].ToString();
            Position_ofset +=2;

            //Speed
            Random _Speed1 = new Random();
            int Speed1 = _Speed1.Next(0, 3);
            byte speed1 = (byte)Speed1;

            Random _Speed2 = new Random();
            int Speed2 = _Speed1.Next(0, 5);
            byte speed2 = (byte)Speed2;

            ushort Speed = 0;
            Speed = (ushort)(speed1 * 16 * 16 + speed2);

            txtSpeed.Text = Speed.ToString();

            //Batt_cap
            txtBatt_cap.Text = Bat_cap.ToString();
            byte bat_cap=(byte)Bat_cap;

            //Batt_voltage
            Random _BattVoltage1 = new Random();
            int BattVoltage1 = _BattVoltage1.Next(0, 5);
            byte battVoltage1 = (byte)Speed1;

            Random _BattVoltage2 = new Random();
            int BattVoltage2 = _BattVoltage2.Next(0, 10);
            byte battVoltage2 = (byte)Speed2;

            ushort BattVoltage = 0;
            Speed = (ushort)(battVoltage1 * 16 * 16 + battVoltage2);

            txtSpeed.Text = BattVoltage.ToString();

            ///Gửi thông tin xe lên Form quản lí
            Console.WriteLine("Testing!");

            //Xe AGV1
            if (comboBoxAGV.Text == "AGV1")
            {
                byte[] output = new byte[] { 0x7A, 0x12, 0x01, 0xFE, 0x02, 0x00, 0x02, 0x10, 0x09, Saochep[State_ofset], Saochep[TripId_ofset], Saochep[Position_ofset], speed1, speed2, bat_cap, battVoltage1, battVoltage2, 0x7F };
                comPort.Write(output, 0, output.Length);
            }

            //Xe AGV2
            if (comboBoxAGV.Text == "AGV2")
            {
                byte[] output = new byte[] { 0x7A, 0x12, 0x02, 0xFE, 0x02, 0x00, 0x02, 0x10, 0x09, Saochep[State_ofset], Saochep[TripId_ofset], Saochep[Position_ofset], speed1, speed2, bat_cap, battVoltage1, battVoltage2, 0x7F };
                comPort.Write(output, 0, output.Length);
            }

            //Xe AGV3
            if (comboBoxAGV.Text == "AGV3")
            {
                byte[] output = new byte[] { 0x7A, 0x12, 0x03, 0xFE, 0x02, 0x00, 0x02, 0x10, 0x09, Saochep[State_ofset], Saochep[TripId_ofset], Saochep[Position_ofset], speed1, speed2, bat_cap, battVoltage1, battVoltage2, 0x7F };
                comPort.Write(output, 0, output.Length);
            }

            //Tăng giá trị biến đếm Count
            Count++;

            if (Count == 12)
            {
                timer1.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Nhận biết trạm nhận D01 -> D17
            if (Saochep[Message_type_ofset] == ROUTE_PACKET_TYPE && Saochep[20] == TramNhan_D01)
            {
                timer1.Start();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
