using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Number   Square \r\n";

            string text = string.Empty;

            for(int i = 1; i <= 10; i++)
            {
                string sq = calcSquare(i).ToString();
                text = text + i + "\t" + sq + "\r\n";
            }

            textBox1.Text += text;  
        }

        int calcSquare(int var)
        {
            return (var * var);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox1.Multiline = true;
        }
    }
}
