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
    /// Interaction logic for PageRegistration.xaml
    /// </summary>
    public partial class PageRegistration : Page
    {
        public PageRegistration()
        {
            InitializeComponent();
        }

        private void btnSignUpClick(object sender, RoutedEventArgs e)
        {
            var da = new DataAccess();
            User user = new User
            {
                FirstName = tbFName.Text,
                LastName = tbLName.Text,
                Age = int.Parse(tbAge.Text),
                Login = tbLogin.Text,
                Password = pbPassword.Password
            };

            if (da.RegistrationUser(user))
            {
                MessageBox.Show("Registration is successful", "Successfully!");
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Registration failed", "Error");
            }

        }
    }
}
