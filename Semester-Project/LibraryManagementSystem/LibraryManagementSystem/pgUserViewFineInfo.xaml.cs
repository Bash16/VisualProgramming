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
    /// Interaction logic for pgUserViewFineInfo.xaml
    /// </summary>
    public partial class pgUserViewFineInfo : Page
    {
        private Frame mainFrame;
        public pgUserViewFineInfo(Frame frame)
        {
            InitializeComponent();
            mainFrame = frame;
        }

        private string connectionString = "Data Source=DESKTOP-ERUUV97\\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True";

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();
            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            pgUserHome pg = new pgUserHome(mainFrame);
            mainFrame.Content = pg;
        }

        private void btnViewBooks_Click(object sender, RoutedEventArgs e)
        {
            pgUserViewBooks pg = new pgUserViewBooks(mainFrame);
            mainFrame.Content = pg;
        }

        private void btnIssueBook_Click(object sender, RoutedEventArgs e)
        {
            pgUserIssueBook pg = new pgUserIssueBook(mainFrame);
            mainFrame.Content = pg;
        }

        private void btnReturnBook_Click(object sender, RoutedEventArgs e)
        {
            pgUserReturnBook pg = new pgUserReturnBook(mainFrame);
            mainFrame.Content = pg;
        }

        private void btnViewFineInfo_Click(object sender, RoutedEventArgs e)
        {
            pgUserViewFineInfo pg = new pgUserViewFineInfo(mainFrame);
            mainFrame.Content = pg;
        }

        private void btnViewFine_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username.");
                return;
            }
            // Check if the selected username is valid
            if (!IsUsernameValid(username))
            {
                MessageBox.Show("Invalid username. Please enter a valid username.");
                return;
            }

            int userId = GetUserId(username);
            if (userId != -1)
            {
                List<int> issuedBookIds = GetIssuedBookIds(userId);

                if (issuedBookIds.Count > 0)
                {
                    int totalFineAmount = CalculateTotalFine(issuedBookIds);

                    MessageBox.Show($"Total fine amount for {username}: Rs. {totalFineAmount}", "Fine Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show($"No books issued for {username}.", "Fine Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show($"User {username} not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool IsUsernameValid(string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectUserQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";

                    using (SqlCommand cmd = new SqlCommand(selectUserQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        int userCount = (int)cmd.ExecuteScalar();

                        return userCount > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        private int GetUserId(string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectUserIdQuery = "SELECT UserID FROM Users WHERE Username = @Username";

                    using (SqlCommand cmd = new SqlCommand(selectUserIdQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        var result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return -1;
            }
        }
        private List<int> GetIssuedBookIds(int userID)
        {
            List<int> issuedBookIds = new List<int>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectIssuedBookIdsQuery = "SELECT IssuedBookID FROM IssuedBooks WHERE UserID = @UserID";

                    using (SqlCommand cmd = new SqlCommand(selectIssuedBookIdsQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int issuedBookId = reader.GetInt32(0);
                                issuedBookIds.Add(issuedBookId);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return issuedBookIds;
        }
        private int CalculateTotalFine(List<int> issuedBookIds)
        {
            int totalFineAmount = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Step 4: Sum the FineAmount for each IssuedBookID
                    foreach (int issuedBookId in issuedBookIds)
                    {
                        string selectFineAmountQuery = "SELECT FineAmount FROM Fines WHERE IssuedBookID = @IssuedBookID";

                        using (SqlCommand cmd = new SqlCommand(selectFineAmountQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@IssuedBookID", issuedBookId);

                            object result = cmd.ExecuteScalar();

                            if (result != null && result != DBNull.Value)
                            {
                                totalFineAmount += Convert.ToInt32(result);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return totalFineAmount;
        }
    }
}
