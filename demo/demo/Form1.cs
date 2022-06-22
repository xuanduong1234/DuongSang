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
    }
}
