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
    /// Interaction logic for pgUserReturnBook.xaml
    /// </summary>
    public partial class pgUserReturnBook : Page
    {
        private Frame mainFrame;
        public pgUserReturnBook(Frame frame)
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

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username.");
                return;
            }
            if (!IsUsernameValid(username))
            {
                MessageBox.Show("Invalid username. Please enter a valid username.");
                return;
            }

            int userId = GetUserId(username);
            if (userId != -1)
            {
                List<int> bookIds = GetBookIds(userId);

                if (bookIds.Count > 0)
                {
                    List<string> bookTitles = GetBookTitles(bookIds);
                    comboBoxBooks.Items.Clear(); // Clear existing items
                    foreach (string title in bookTitles)
                    {
                        comboBoxBooks.Items.Add(title);
                    }
                }
                else
                {
                    MessageBox.Show("No books have been issued by you.");
                }
            }
            else
            {
                MessageBox.Show("User not found.");
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
        private List<int> GetBookIds(int userID)
        {
            List<int> bookIds = new List<int>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectBookIdsQuery = "SELECT BookID FROM IssuedBooks WHERE UserID = @UserID";

                    using (SqlCommand cmd = new SqlCommand(selectBookIdsQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int bookId = reader.GetInt32(0);
                                bookIds.Add(bookId);
                            }
                        }
                    }
                }
                return bookIds;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return new List<int>(); // Return an empty list in case of an error
            }
        }

        private List<string> GetBookTitles(List<int> bookIds)
        {
            List<string> bookTitles = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Use string.Join to create a comma-separated list of book IDs
                    string bookIdList = string.Join(",", bookIds);

                    // Query the Books table to get titles based on book IDs
                    string selectBookTitlesQuery = $"SELECT Title FROM Books WHERE BookID IN ({bookIdList})";

                    using (SqlCommand cmd = new SqlCommand(selectBookTitlesQuery, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string bookTitle = reader.GetString(0);
                                bookTitles.Add(bookTitle);
                            }
                        }
                    }
                }
                return bookTitles;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return new List<string>(); // Return an empty list in case of an error
            }
        }
        private int GetBookId(string bookTitle)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectBookIdQuery = "SELECT BookID FROM Books WHERE Title = @Title";

                    using (SqlCommand cmd = new SqlCommand(selectBookIdQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Title", bookTitle);

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
        private void btnReturnBook1_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string selectedBook = comboBoxBooks.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(selectedBook))
            {
                MessageBox.Show("Please enter a username and select a book title.");
                return;
            }

            int userId = GetUserId(username);
            int bookId = GetBookId(selectedBook);

            if (userId != -1 && bookId != -1)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string insertIssuedBookQuery = "INSERT INTO IssuedBooks (ReturnDate, IsReturned) VALUES (@ReturnDate, @IsReturned)";

                        using (SqlCommand cmd = new SqlCommand(insertIssuedBookQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@ReturnDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("@IsReturned", true);

                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Book returned successfully!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while returning the book.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

