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
    /// Interaction logic for pgUser.xaml
    /// </summary>
    public partial class pgUser : Page
    {
        private Frame mainFrame;
        public pgUser(Frame frame)
        {
            InitializeComponent();
            mainFrame = frame;
        }
        private void signUpBtn_Click(object sender, RoutedEventArgs e)
        {
            pgUserSignUp pg = new pgUserSignUp(mainFrame);
            mainFrame.Content = pg;
        }
        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            pgUserLogin pg = new pgUserLogin(mainFrame);
            mainFrame.Content = pg;
        }
    }
}
