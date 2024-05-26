using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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


///////////////Need to add table here or something


namespace LibraryManagementSystem
{
    /// <summary>
    /// Interaction logic for pgAdminViewBookDetail.xaml
    /// </summary>
    public partial class pgAdminViewBookDetail : Page
    {
        private Frame mainFrame;
        public pgAdminViewBookDetail(Frame frame)
        {
            InitializeComponent();
            mainFrame = frame;
        }

        private string connectionString = "Data Source=DESKTOP-ERUUV97\\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True";

        private void btnLoadDetails_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                                    SELECT 
                                        IB.IssuedBookID,
                                        U.Username,
                                        B.Title,
                                        B.Author,
                                        IB.IssueDate,
                                        IB.ReturnDate,
                                        IB.IsReturned,
                                        F.FineAmount
                                    FROM 
                                        IssuedBooks IB
                                        INNER JOIN Users U ON IB.UserID = U.UserID
                                        INNER JOIN Books B ON IB.BookID = B.BookID
                                        LEFT JOIN Fines F ON IB.IssuedBookID = F.IssuedBookID
                                ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();

                        // Fill the DataTable with the data from the Books table
                        dataAdapter.Fill(dataTable);

                        // Bind the DataTable to the DataGrid
                        dataGridDetails.ItemsSource = dataTable.DefaultView;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private void btnViewUserInfo_Click(object sender, RoutedEventArgs e)
        {
            pgAdminViewUserInfo pg = new pgAdminViewUserInfo(mainFrame);
            mainFrame.Content = pg;
        }

        private void btnViewBooks_Click(object sender, RoutedEventArgs e)
        {
            pgAdminViewBooks pg = new pgAdminViewBooks(mainFrame);
            mainFrame.Content = pg;
        }

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            pgAdminAddBook pg = new pgAdminAddBook(mainFrame);
            mainFrame.Content = pg;
        }
    }
}
