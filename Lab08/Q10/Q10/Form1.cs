using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q10
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int generatedToken;
        public int currentToken;
        public int queuePeople;

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            generatedToken++;
            label6.Text = generatedToken.ToString();

            queuePeople = generatedToken - currentToken;
            label3.Text = generatedToken.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            generatedToken = 0;
            currentToken = 0;
            queuePeople = 0;

            label6.Text = generatedToken.ToString();
            textBox1.Text = currentToken.ToString();
            label3.Text = queuePeople.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentToken++;
            textBox1.Text = currentToken.ToString();

            queuePeople = generatedToken - currentToken;
            label3.Text = queuePeople.ToString();
        }
    }
}
