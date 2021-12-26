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
using Core;

namespace WpfTattoo.Pages
{
    /// <summary>
    /// Interaction logic for PageAuthorization.xaml
    /// </summary>
    public partial class PageAuthorization : Page
    {
        public DataAccess dataAccess { get; set; }
        public PageAuthorization()
        {
            InitializeComponent();
            dataAccess = new DataAccess();
        }

        private void btnSignUpClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.PageRegistration());
        }

        private void btnSignInClick(object sender, RoutedEventArgs e)
        {
            var login = tbLogin.Text;
            var password = pbPassword.Password;

            if(dataAccess.IsCorrectLogin(login, password))
            {
                NavigationService.Navigate(new PageUser(dataAccess.GetUser(login, password)));
            }
            else
            {
                MessageBox.Show("Invalid login or password","Error");
            }
        }
    }
}
