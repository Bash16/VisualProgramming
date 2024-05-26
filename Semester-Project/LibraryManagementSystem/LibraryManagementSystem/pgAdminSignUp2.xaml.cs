using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Interaction logic for pgAdminSignUp2.xaml
    /// </summary>
    public partial class pgAdminSignUp2 : Page
    {
        private Frame mainFrame;
        public pgAdminSignUp2(Frame frame)
        {
            InitializeComponent();
            mainFrame = frame;
        }

        private string connectionString = "Data Source=DESKTOP-ERUUV97\\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Insert admin data into the Admins table
                    string query = "INSERT INTO Administrator ([Name], [Password]) VALUES (@Name, @Password)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", txtName.Text);
                        command.Parameters.AddWithValue("@Password", txtPassword.Password);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Admin account created successfully!\nLogin with newly created credentials.");

                        pgAdminLogin pg = new pgAdminLogin(mainFrame);
                        mainFrame.Content = pg;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                txtName.Clear();
                txtPassword.Clear();
            }
        }
    }
}

