using System;
using System.Collections.Generic;
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
    /// Interaction logic for pgAdminHome.xaml
    /// </summary>
    public partial class pgAdminHome : Page
    {
        private Frame mainFrame;
        public pgAdminHome(Frame frame)
        {
            InitializeComponent();
            mainFrame = frame;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();
            }
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

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            pgAdminAddBook pg = new pgAdminAddBook(mainFrame);
            mainFrame.Content = pg;
        }
    }
}
