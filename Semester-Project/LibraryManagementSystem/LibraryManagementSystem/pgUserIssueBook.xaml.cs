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
    /// Interaction logic for pgUserIssueBook.xaml
    /// </summary>
    public partial class pgUserIssueBook : Page
    {
        private Frame mainFrame;
        public pgUserIssueBook(Frame frame)
        {
            InitializeComponent();
            mainFrame = frame;
            LoadGenre();
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

        private void LoadGenre()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectBooksQuery = "SELECT Genre FROM Books";

                    using (SqlCommand cmd = new SqlCommand(selectBooksQuery, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            comboBoxGenre.Items.Add(reader["Genre"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void comboBoxGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                comboBoxBooks.Items.Clear();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (!string.IsNullOrEmpty(comboBoxGenre.SelectedItem?.ToString()))
                    {
                        string selectBooksQuery = "SELECT Title FROM Books WHERE Genre = @Genre";

                        using (SqlCommand cmd = new SqlCommand(selectBooksQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Genre", comboBoxGenre.SelectedItem?.ToString());

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    comboBoxBooks.Items.Add(reader["Title"].ToString());
                                }
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

        private void btnIssueBook1_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string selectedBook = comboBoxBooks.SelectedItem?.ToString();
            string selectedGenre = comboBoxGenre.SelectedItem?.ToString();

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
            if (string.IsNullOrEmpty(selectedBook) || string.IsNullOrEmpty(selectedGenre))
            {
                MessageBox.Show("Please select a book and genre.");
                return;
            }

            int userId = GetUserId(username);
            int bookId = GetBookId(selectedBook, selectedGenre);

            if (userId != -1 && bookId != -1)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string insertIssuedBookQuery = "INSERT INTO IssuedBooks (UserID, BookID, IssueDate, IsReturned) VALUES (@UserID, @BookID, @IssueDate, @IsReturned)";

                        using (SqlCommand cmd = new SqlCommand(insertIssuedBookQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@UserID", userId);
                            cmd.Parameters.AddWithValue("@BookID", bookId);
                            cmd.Parameters.AddWithValue("@IssueDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("@IsReturned", false);

                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Book issued successfully!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while issuing the book.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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

        private int GetBookId(string bookTitle, string genre)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectBookIdQuery = "SELECT BookID FROM Books WHERE Title = @Title AND Genre = @Genre";

                    using (SqlCommand cmd = new SqlCommand(selectBookIdQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Title", bookTitle);
                        cmd.Parameters.AddWithValue("@Genre", genre);

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
    }
}
