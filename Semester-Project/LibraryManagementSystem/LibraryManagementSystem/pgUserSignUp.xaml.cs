using System;
using System.Collections;
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
    /// Interaction logic for pgUserSignUp.xaml
    /// </summary>
    public partial class pgUserSignUp : Page
    {
        private Frame mainFrame;
        public pgUserSignUp(Frame frame)
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

                    // Insert user data into the Users table
                    string query = "INSERT INTO Users (FirstName, LastName, Username, [Password], Email) VALUES (@FirstName, @LastName, @Username, @Password, @Email)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        command.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        command.Parameters.AddWithValue("@Username", txtUsername.Text);
                        command.Parameters.AddWithValue("@Password", txtPassword.Password);
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);

                        command.ExecuteNonQuery();

                        MessageBox.Show("User created successfully!\nLogin with newly created credentials.");
                        pgUserLogin pg = new pgUserLogin(mainFrame);
                        mainFrame.Content = pg;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}