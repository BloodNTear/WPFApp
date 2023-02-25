using Services.Interface;
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

namespace WPFAPP
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private IUserService _userService;
        public LoginPage(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Password.Trim();
            var result = _userService.Login(username, password);
            if (result != null)
            {
                MessageBox.Show("Login successfully");
            }
            else
            {
                MessageBox.Show($"Invalid Username or Password");
            }
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnForgetPassword_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
