﻿using System;
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
    /// Interaction logic for PageCreateRequests.xaml
    /// </summary>
    public partial class PageCreateRequests : Page
    {
        public User currentUser { get; set; }
        public DataAccess dataAccess { get; set; }
        public List<BodyPart> bodyParts { get; set; }
        public PageCreateRequests(User user)
        {
            InitializeComponent();
            currentUser = user;
            dataAccess = new DataAccess();
            bodyParts = dataAccess.GetBodyParts();
            this.DataContext = this;
        }

        private void btnTattooClick(object sender, RoutedEventArgs e)
        {
            Windows.WindowSelectTattoo dialog = new Windows.WindowSelectTattoo();
            if (dialog.ShowDialog() == true)
            {
                btnTattoo.Content = $"{(dialog.lvTattoos.SelectedItem as Tattoo).Name}";
            }
        }

        private void btnCreateClick(object sender, RoutedEventArgs e)
        {
            Request request = new Request
            {
                IdUser = currentUser.IdUser,
                IdBodyPart = (cbBody.SelectedItem as BodyPart).IdBodyPart,
                Date = dpDate.SelectedDate,
                IdTattoo = dataAccess.GetTattoo(btnTattoo.Content.ToString()).IdTattoo
            };

            dataAccess.AddNewRequest(request);
        }

        private void btnBaclClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}