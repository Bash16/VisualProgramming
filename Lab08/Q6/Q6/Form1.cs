using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q6
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
        }

        private decimal counter;

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = counter.ToString() + " Seconds.";

            counter--;

            if (counter < 0)
                timer1.Stop();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            counter = numericUpDown1.Value;

            label3.Text = counter.ToString() + " Seconds.";

            timer1.Start();
        }
    }
}
