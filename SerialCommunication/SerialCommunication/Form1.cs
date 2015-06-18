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

namespace SerialCommunication
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            chart1.Series[0].BorderWidth = 3;
            chart1.Series[1].BorderWidth = 3;
        }


        #region Received Data from Serial Port


        #region Variables

        // buffer variable
        private string bufferSerial; 
        
        // Counter for X-axis
        private static double xCounter = 0;
        #endregion


        #region Received Data 


        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            bufferSerial = serialPort1.ReadLine();
            this.Invoke(new EventHandler(displayText));
        }


        private void displayText(object sender, EventArgs e) 
        {
            try
            {
                if (checkPause.Checked)
                {
                    //textBox1.AppendText(Environment.NewLine + "RX:" + bufferSerial);
                }
                else
                {
            /*       chart1.Series[0].Points.AddXY(xCounter, Convert.ToDouble(Convert.ToString(setPoint.Value)));
                    chart1.Series[1].Points.AddXY(xCounter, Convert.ToDouble(bufferSerial));
                    chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(bufferSerial) + 4000;
                    chart1.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(bufferSerial) - 4000;
                    if (xCounter-10 > 0)
                    {
                        chart1.ChartAreas[0].AxisX.Minimum = xCounter - 10;
                    }
                    xCounter += 0.1;*/
                    textBox1.AppendText(Environment.NewLine + "RX:" + bufferSerial);
                }
            }
            catch (Exception)
            {
                
                
            }
           
           
        }

        #endregion 


        #endregion


        #region Get Available Ports

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string[] avPorts=SerialPort.GetPortNames();
            foreach (var port in avPorts)
            {
                comboBox1.Items.Add(port);
            }
        }
        #endregion


        #region ComboBoxes: Select Baudrate, Select Port


        #region Select BaudRate

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.BaudRate = Convert.ToInt32(comboBox2.SelectedItem);
        }

        #endregion

        #region Select Port


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = Convert.ToString(comboBox1.SelectedItem);
        }

        #endregion


        #endregion


        #region Buttons: Write, Connect, Disconnect, Pause, Write Configurations


        #region Write Button


        private void buttonWrite_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.WriteLine("S");
                serialPort1.WriteLine(Convert.ToString(setPoint.Value));
                //serialPort1.WriteLine("S" + Convert.ToString(setPoint.Value));
                textBox1.AppendText("\r\nTX: " + Convert.ToString(setPoint.Value) + Environment.NewLine); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        #endregion

        #region Connect Button
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Open();
                textBox1.Text = "Connected";
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
            
        }
        #endregion

        #region Disconnect Button

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                
                textBox1.AppendText("\r\nDisconnected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Clear TextBox Button

        private void buttonClearText_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            xCounter = 0;
        }
        #endregion

        #region Pause Button (checkBox with Appereance of a button)


        private void checkPause_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPause.Checked)
            {
                checkPause.BackColor = Color.Red;
            }
            else
            {
                checkPause.BackColor = Color.Lime;
            }
        }

        #endregion

        #region Write Configurations Button


        private void buttonWriteConfigurations_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.WriteLine("C");
                serialPort1.WriteLine(Convert.ToString(KpValue.Value));
                serialPort1.WriteLine(Convert.ToString(KiValue.Value));
                serialPort1.WriteLine(Convert.ToString(KdValue.Value));
               /* serialPort1.WriteLine("C" + Convert.ToString(KpValue.Value) + 
                                             Convert.ToString(KiValue.Value) +
                                             Convert.ToString(KdValue.Value));*/
                textBox1.AppendText("\r\nTX: " + Convert.ToString(KpValue.Value) + ", "
                                                + Convert.ToString(KiValue.Value) + ", "
                                                + Convert.ToString(KdValue.Value) + ", "
                                                + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion


        #endregion

    }
}
