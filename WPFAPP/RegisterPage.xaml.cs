using Microsoft.Win32;
using Services.BusinessModel;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private UserModel _user;
        public RegisterPage()
        {
            if (!Directory.Exists($"./Images"))
            {
                Directory.CreateDirectory(".//Images");
            }
            InitializeComponent();
        }

        private void btnChooseAvt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images|*.png; *.jpg|All Files|*.*";
            openFileDialog.ShowDialog();
            var fileName = openFileDialog.FileName;

            try {
                string destination = $"./Images/";
                string extendsion = System.IO.Path.GetExtension(fileName) ;
                destination += txtUsername.Text + extendsion;
                File.Copy(fileName, destination, true);
                imgAvatar.Source = new BitmapImage(new Uri(destination.Replace("\\","/"), UriKind.RelativeOrAbsolute));
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
