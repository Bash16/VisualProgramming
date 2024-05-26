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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateFinesAutomatically();
        }

        private string connectionString = "Data Source=DESKTOP-ERUUV97\\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True";

        private void userBtn_Click(object sender, RoutedEventArgs e)
        {
            pgUser pg = new pgUser(mainFrame);
            mainFrame.Content = pg;
        }

        private void adminBtn_Click(object sender, RoutedEventArgs e)
        {
            pgAdmin pg = new pgAdmin(mainFrame);
            mainFrame.Content = pg;
        }

        public void UpdateFinesAutomatically()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Get overdue books
                    string selectOverdueBooksQuery = "SELECT IssuedBookID, IssueDate FROM IssuedBooks WHERE IsReturned = 0 AND DATEDIFF(day, IssueDate, GETDATE()) > 14";

                    using (SqlCommand cmd = new SqlCommand(selectOverdueBooksQuery, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int issuedBooksID = reader.GetInt32(0);
                                DateTime issueDate = reader.GetDateTime(1);

                                // Calculate fine amount (Rs. 500 for each overdue book)
                                int fineAmount = 500;

                                // Update the Fines table
                                UpdateFineInDatabase(issuedBooksID, fineAmount);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateFineInDatabase(int issuedBooksID, int fineAmount)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Update the Fines table
                    string updateFineQuery = "UPDATE Fines SET FineAmount = @FineAmount WHERE IssuedBookID = @IssuedBookID";

                    using (SqlCommand cmd = new SqlCommand(updateFineQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@FineAmount", fineAmount);
                        cmd.Parameters.AddWithValue("@IssuedBookID", issuedBooksID);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

