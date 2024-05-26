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
    /// Interaction logic for pgUserHome.xaml
    /// </summary>
    public partial class pgUserHome : Page
    {
        private Frame mainFrame;
        public pgUserHome(Frame frame)
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
    }
}
