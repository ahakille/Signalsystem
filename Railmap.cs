using ArduinoDriver.SerialProtocol;
using ArduinoUploader.Hardware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signalsystem
{
    
    public partial class Railmap : Form
    {
        

        ArduinoDriver.ArduinoDriver driver;
        bool vxl1;
        bool vxl2;
        bool vxl3;
        bool vxl4;
        bool vxl5;
        bool vxl6;
        bool vxl7;
        bool vxl8;
        bool vxl9;
        int time;

        public Railmap()
        {
            Thread t = new Thread(new ThreadStart(splashstart));
            t.Start();
            bool check;
            string message;
            Start(out check, out message); 
            t.Abort();
            InitializeComponent();
            if (check)
            {
                Error(message);
            }
            
      
        }
        private void splashstart()
        {
            Application.Run(new Start());
        }
        private void Error(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Btnvxl1.Enabled = false;
            Btnvxl2.Enabled = false;
            Btnvxl3.Enabled = false;
            Btnvxl4.Enabled = false;
            Btnvxl5.Enabled = false;
            Btnvxl6.Enabled = false;
            Btnvxl7.Enabled = false;
            Btnvxl8.Enabled = false;
            Btnvxl9.Enabled = false;
        }
        private void Change(int nummer)
        {
            byte b = Convert.ToByte(nummer);
            driver.Send(new DigitalWriteRequest(b, ArduinoDriver.DigitalValue.High));
            Task.Delay(time).Wait();
            driver.Send(new DigitalWriteRequest(b, ArduinoDriver.DigitalValue.Low));
        }
        private void Start(out bool check , out string message)
        {
            vxl1 = false;
            vxl2 = false;
            vxl3 = false;
            vxl4 = false;
            vxl5 = false;
            vxl6 = false;
            vxl7 = false;
            vxl8 = false;
            vxl9 = false;
            options options = new options();
            string port = options.XmltoString("port");
            time = Convert.ToInt16(options.XmltoString("time"));
            try
            {
                driver = new ArduinoDriver.ArduinoDriver(ArduinoModel.UnoR3, port, true);
                for (int i = 1; i < 14; i++)
                {
                    byte b = Convert.ToByte(i);
                    driver.Send(new DigitalWriteRequest(b, ArduinoDriver.DigitalValue.High));
                    driver.Send(new AnalogWriteRequest(b, 1));
                    driver.Send(new DigitalWriteRequest(b, ArduinoDriver.DigitalValue.Low));
                }
                for (int i = 1; i < 14; i++)
                {

                    byte b = Convert.ToByte(i);
                    driver.Send(new DigitalWriteRequest(b, ArduinoDriver.DigitalValue.High));
                    Task.Delay(300).Wait();
                    driver.Send(new DigitalWriteRequest(b, ArduinoDriver.DigitalValue.Low));
                    i++;

                }
                message = "";
                check = false;
                
            }
            catch (Exception dv)
            {
                Task.Delay(4000).Wait();
                message = dv.Message;
                check = true;
               
            }
            
            
        }
        private void Btnvxl1_Click(object sender, EventArgs e)
        {
           if (vxl1)
            {
                Btnvxl1.Text = "----";
                vxl1 = false;
                Change(3);
            }
           else
            {
                Btnvxl1.Text = "/ /";
                vxl1 = true;
                Change(4);
            }
        }

        private void Btnvxl2_Click(object sender, EventArgs e)
        {
            if (vxl2)
            {
                Btnvxl2.Text = "----";
                vxl2 = false;
                Change(5);
            }
            else
            {
                Btnvxl2.Text = "/ /";
                vxl2 = true;
                Change(6);
            }
        }
        private void Btnvxl3_Click(object sender, EventArgs e)
        {
            if (vxl3)
            {
                Btnvxl3.Text = "----";
                vxl3 = false;
                Change(7);
            }
            else
            {
                Btnvxl3.Text = @"\ \";
                vxl3 = true;
                Change(8);
            }
        }

        private void Btnvxl4_Click(object sender, EventArgs e)
        {
            if (vxl4)
            {
                Btnvxl4.Text = "----";
                vxl4 = false;
                Change(9);
            }
            else
            {
                Btnvxl4.Text = @"\ \";
                vxl4 = true;
                Change(10);
            }
        }

        private void Btnvxl5_Click(object sender, EventArgs e)
        {
            if (vxl5)
            {
                Btnvxl5.Text = "----";
                vxl5 = false;
                Change(11);
            }
            else
            {
                Btnvxl5.Text = @"\ \";
                vxl5 = true;
                Change(12);
            }
        }

        private void startaOmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void omToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 0.2", "Om signalsystem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void avslutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btnvxl9_Click(object sender, EventArgs e)
        {
            if (vxl9)
            {
                Btnvxl9.Text = "|   |";
                vxl9 = false;
              //  Change(11);
            }
            else
            {
                Btnvxl9.Text = @"\ \";
                vxl9 = true;
             //   Change(12);
            }
        }

        private void inställningarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
