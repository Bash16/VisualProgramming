using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int val = 1;
            textBox1.Text += val.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int val = 2;
            textBox1.Text += val.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int val = 3;
            textBox1.Text += val.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int val = 4;
            textBox1.Text += val.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int val = 5;
            textBox1.Text += val.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int val = 6;
            textBox1.Text += val.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int val = 7;
            textBox1.Text += val.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int val = 8;
            textBox1.Text += val.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int val = 9;
            textBox1.Text += val.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            char val = '.';
            textBox1.Text += val.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int val = 0;
            textBox1.Text += val.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            char val = '+';
            textBox1.Text += val.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            char val = '-';
            textBox1.Text += val.ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            char val = '*';
            textBox1.Text += val.ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            char val = '/';
            textBox1.Text += val.ToString();
        }
        private void button17_Click(object sender, EventArgs e)
        {
            string exp = textBox1.Text;

            DataTable table = new DataTable();
            var result = table.Compute(exp, "");

            textBox1.Text = result.ToString();
        }
    }
}
