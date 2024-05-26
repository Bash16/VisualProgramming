using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value = int.Parse(textBox1.Text);

            textBox2.Text = factorial(value).ToString();
        }

        int factorial (int val)
        {
            int fact = 1;
            for(int i=val; i>0; i--)
            {
                fact *= i;
            }
            return fact;
        }
    }
}
