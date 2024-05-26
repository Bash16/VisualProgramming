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
    /// Interaction logic for pgAdminSignUp1.xaml
    /// </summary>
    public partial class pgAdminSignUp1 : Page
    {
        private Frame mainFrame;
        public pgAdminSignUp1(Frame frame)
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

                    // Validate admin password against the database
                    string query = "SELECT COUNT(*) FROM Administrator WHERE [Password] = @Password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Password", txtPassword.Password);

                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Admin authentication successful!");
                            
                            pgAdminSignUp2 pg = new pgAdminSignUp2(mainFrame);
                            mainFrame.Content = pg;
                        }
                        else
                        {
                            MessageBox.Show("Invalid admin password. Please try again.");
                            txtPassword.Clear();
                        }
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
