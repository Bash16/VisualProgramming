using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLexample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlCommand cmd = new SqlCommand();
        string connectionString = "Data Source=DESKTOP-ERUUV97\\SQLEXPRESS;Initial Catalog=ProductDB;Integrated Security=True";
        

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            
            // TODO: This line of code loads data into the 'productDBDataSet.Table_Product' table. You can move, or remove it, as needed.
            this.table_ProductTableAdapter.Fill(this.productDBDataSet.Table_Product);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                cmd.Connection = connection;
                connection.Open();

                cmd.CommandText = "INSERT INTO Table_Product (Name, UnitPrice, QuantityInStock) VALUES ('Pins', 5, 500)";
                int totalRowsAffected = cmd.ExecuteNonQuery();
                MessageBox.Show("Total Rows Inserted = " + totalRowsAffected, "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                cmd.Connection = connection;
                connection.Open();

                cmd.CommandText = "DELETE FROM Table_Product WHERE Name = 'Pins'";
                int totalRowsAffected = (int)cmd.ExecuteNonQuery();
                MessageBox.Show("Total Rows Deleted = " + totalRowsAffected, "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                cmd.Connection = connection;
                connection.Open();

                string Query = "SELECT * FROM Table_Product";

                SqlDataAdapter adapter = new SqlDataAdapter(Query, connectionString);
                DataSet set = new DataSet();

                adapter.Fill(set, "Table_Product");
                dataGridView1.DataSource = set.Tables["Table_Product"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                cmd.Connection = connection;
                connection.Open();

                cmd.CommandText = "UPDATE Table_Product SET QuantityInStock = 0 WHERE Name = 'Pencil'";
                int totalRowsAffected = (int)cmd.ExecuteNonQuery();
                MessageBox.Show("Total Rows Updated = " + totalRowsAffected, "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
