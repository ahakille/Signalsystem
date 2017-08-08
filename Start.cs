using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signalsystem
{
    public partial class Start : Form
    {
        int procent;
        public Start()
        {
            InitializeComponent();
            procent = 0;
        }

        private void Progressbartimer_Tick(object sender, EventArgs e)
        {
            
            
            if (progressBar1.Value != 100)
            {
                progressBar1.Increment(1);
                procent++;
                label2.Text = Convert.ToString(procent)+"%";
            }
        }
    }
}
