using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for pgAdminViewBooks.xaml
    /// </summary>
    public partial class pgAdminViewBooks : Page
    {
        private Frame mainFrame;
        public pgAdminViewBooks(Frame frame)
        {
            InitializeComponent();
            mainFrame = frame;
        }

        private string connectionString = "Data Source=DESKTOP-ERUUV97\\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True";

        private void btnLoadBooksData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Books";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();

                        // Fill the DataTable with the data from the Books table
                        dataAdapter.Fill(dataTable);

                        // Bind the DataTable to the DataGrid
                        dataGridBooks.ItemsSource = dataTable.DefaultView;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            pgAdminAddBook pg = new pgAdminAddBook(mainFrame);
            mainFrame.Content = pg;
        }
    }
}

