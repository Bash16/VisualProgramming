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
    /// Interaction logic for pgAdminAddBook.xaml
    /// </summary>
    public partial class pgAdminAddBook : Page
    {
        private Frame mainFrame;
        public pgAdminAddBook(Frame frame)
        {
            InitializeComponent();
            mainFrame = frame;

            comboBoxGenre.Items.Add("Horror");
            comboBoxGenre.Items.Add("Fiction");
            comboBoxGenre.Items.Add("Drama");
            comboBoxGenre.Items.Add("Computer Science");
            comboBoxGenre.Items.Add("Business");
            comboBoxGenre.Items.Add("Action");
            comboBoxGenre.Items.Add("Science");
            comboBoxGenre.Items.Add("Adventure");
            comboBoxGenre.Items.Add("Islam & Religion");

            comboBoxStatus.Items.Add("Available");
            comboBoxStatus.Items.Add("Not Available");
        }

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
            pgAdminHome pg = new pgAdminHome(mainFrame);
            mainFrame.Content = pg;
        }

        private void btnViewFineInfo_Click(object sender, RoutedEventArgs e)
        {
            pgAdminViewFineInfo pg = new pgAdminViewFineInfo(mainFrame);
            mainFrame.Content = pg;
        }

        private void btnViewBookDetail_Click(object sender, RoutedEventArgs e)
        {
            pgAdminViewBookDetail pg = new pgAdminViewBookDetail(mainFrame);
            mainFrame.Content = pg;
        }

        private void btnViewUserInfo_Click(object sender, RoutedEventArgs e)
        {
            pgAdminViewUserInfo pg = new pgAdminViewUserInfo(mainFrame);
            mainFrame.Content = pg;
        }

        private void btnViewBook_Click(object sender, RoutedEventArgs e)
        {
            pgAdminViewBooks pg = new pgAdminViewBooks(mainFrame);
            mainFrame.Content = pg;
        }

        private string connectionString = "Data Source=DESKTOP-ERUUV97\\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True";

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Books (Title, Author, Genre, Price, Quantity, AvailabilityStatus) " +
                                         "VALUES (@Title, @Author, @Genre, @Price, @Quantity, @AvailabilityStatus)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                        cmd.Parameters.AddWithValue("@Author", txtAuthor.Text);
                        cmd.Parameters.AddWithValue("@Genre", comboBoxGenre.SelectedItem?.ToString());
                        cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                        cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                        cmd.Parameters.AddWithValue("@AvailabilityStatus", comboBoxStatus.SelectedItem?.ToString());

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Book added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    // Clear the input fields
                    txtTitle.Clear();
                    txtAuthor.Clear();
                    comboBoxGenre.SelectedIndex = -1;
                    txtPrice.Clear();
                    txtQuantity.Clear();
                    comboBoxStatus.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}

