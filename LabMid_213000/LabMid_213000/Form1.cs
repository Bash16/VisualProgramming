namespace LabMid_213000
{
    public partial class Form1 : Form
    {
        private int salary = 0;
        public int Salary { get { return salary; } set { salary = value; } }
        public void incrementSalary(int value)
        {
           salary = salary + value;
        }
        public void decrementSalary(int value)
        {
            salary = salary - value;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            switch (textBox2.Text)
            {
                case "Provident Fund Deduction":
                    decrementSalary(10000);
                    break;
                case "Medical Deduction":
                    decrementSalary(5000);
                    break;
                default:
                    break;
            }

            switch (textBox3.Text)
            {
                case "Provident Fund Deduction":
                    decrementSalary(10000);
                    break;
                case "Medical Deduction":
                    decrementSalary(5000);
                    break;
                default:
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            string[] GradeLevel = { "Director", "Manager", "Project Manager", "Programmer" };

            foreach (string level in GradeLevel)
            {
                comboBox1.Items.Add(level);
            }

            string[] bonuses = { "Project Completion Bonus", "Year End Bonus", "Performance Bonus", "Customer Appreciation Bonus" };
            
            foreach(string bonus in bonuses)
            {
                checkedListBox1.Items.Add(bonus);
            }
      
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Director")
            {
                radioButton1.Checked = true;
                incrementSalary(100000);
            }
            else if (comboBox1.SelectedItem.ToString() == "Manager")
            {
                radioButton2.Checked = true;
                incrementSalary(50000);
            }
            else if (comboBox1.SelectedItem.ToString() == "Project Manager")
            {
                radioButton3.Checked = true;
                incrementSalary(40000);
            }
            else if (comboBox1.SelectedItem.ToString() == "Programmer")
            {
                radioButton4.Checked = true;
                incrementSalary(30000);
            }  
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                incrementSalary(20000);
            if (checkBox2.Checked)
                incrementSalary(15000);
            if (checkBox3.Checked)
                incrementSalary(10000);
            if (checkBox4.Checked)
                incrementSalary(10000);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.ToString();

            MessageBox.Show("Salary of " + name + $" is Rs.{Salary}", "Salary");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, ItemCheckEventArgs e)
        {
            string checkedItem = checkedListBox1.Items[e.Index].ToString();

            switch (checkedItem)
            {
                case "Project Completion Bonus":
                    if (e.NewValue == CheckState.Checked)
                        incrementSalary(20000);
                    else if (e.NewValue == CheckState.Unchecked)
                        decrementSalary(20000);
                    break;
                case "Year End Bonus":
                    if (e.NewValue == CheckState.Checked)
                        incrementSalary(30000);
                    else if (e.NewValue == CheckState.Unchecked)
                        decrementSalary(30000);
                    break;
                case "Performance Bonus":
                    if (e.NewValue == CheckState.Checked)
                        incrementSalary(25000);
                    else if (e.NewValue == CheckState.Unchecked)
                        decrementSalary(25000);
                    break;
                case "Customer Appreciation Bonus":
                    if (e.NewValue == CheckState.Checked)
                        incrementSalary(15000);
                    else if (e.NewValue == CheckState.Unchecked)
                        decrementSalary(15000);
                    break;
            }
        }

        
    }
}

