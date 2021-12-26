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
    /// Interaction logic for PageRequests.xaml
    /// </summary>
    public partial class PageRequests : Page
    {
        public List<Request> requests { get; set; }
        public DataAccess dataAccess { get; set; }
        public User currentUser { get; set; }
        public PageRequests(User user)
        {
            InitializeComponent();
            currentUser = user;
            dataAccess = new DataAccess();
            requests = dataAccess.GetRequests(currentUser);

            this.DataContext = this;
        }

        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
