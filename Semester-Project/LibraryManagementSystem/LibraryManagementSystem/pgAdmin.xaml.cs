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
    /// Interaction logic for pgAdmin.xaml
    /// </summary>
    public partial class pgAdmin : Page
    {
        private Frame mainFrame;
        public pgAdmin(Frame frame)
        {
            InitializeComponent();
            mainFrame = frame;
        }

        private void signUpBtn_Click(object sender, RoutedEventArgs e)
        {
            pgAdminSignUp1 pg = new pgAdminSignUp1(mainFrame);
            mainFrame.Content = pg;
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            pgAdminLogin pg = new pgAdminLogin(mainFrame);
            mainFrame.Content = pg;
        }
    }
}
