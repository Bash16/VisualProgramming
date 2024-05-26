using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int var1 = int.Parse(textBox1.Text);
            int var2 = int.Parse(textBox2.Text);

            int res = var1 + var2;
            textBox3.Text = res.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int var1 = int.Parse(textBox1.Text);
            int var2 = int.Parse(textBox2.Text);

            int res = var1 - var2;
            textBox3.Text = res.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int var1 = int.Parse(textBox1.Text);
            int var2 = int.Parse(textBox2.Text);

            int res = var1 * var2;
            textBox3.Text = res.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int var1 = int.Parse(textBox1.Text);
            int var2 = int.Parse(textBox2.Text);

            int res = var1 / var2;
            textBox3.Text = res.ToString();
        }
    }
}
