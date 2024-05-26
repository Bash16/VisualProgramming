namespace Q2
{
    public partial class Form1 : Form
    {
        private List<string> data = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string item = textBox1.Text;
            data.Add(item);
            listBox1.Items.Add(item);
            textBox1.Clear();
            MessageBox.Show(item + " has been added to list.", "Notice");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                data.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            data.Clear();
            listBox1.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (string item in data)
            {
                listBox1.Items.Add(item);
            }
        }
    }
}