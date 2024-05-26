using System.Data;
using System.Data.SqlClient;

namespace E4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string CS = "Data Source=DESKTOP-ERUUV97\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True";
            SqlConnection connection = new SqlConnection(CS);

            try
            {
                connection.Open();

                MessageBox.Show("Connection Successfull...");

                string query = "SELECT * FROM Student";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    MessageBox.Show(reader["Roll_no"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
