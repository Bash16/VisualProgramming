using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q9
{
    public partial class Form1 : Form
    {
        public int max;
        public Form1()
        {
            InitializeComponent();
            textBox1.MaxLength = 160;
            max = 160;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            max--;
            label2.Text = max.ToString();
        }
    }
}
