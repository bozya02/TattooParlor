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
using System.Windows.Shapes;
using Core;
using System.Collections.ObjectModel;

namespace WpfTattoo.Windows
{
    /// <summary>
    /// Interaction logic for WindowSelectTattoo.xaml
    /// </summary>
    public partial class WindowSelectTattoo : Window
    {
        public List<Tattoo> tattoos { get; set; }
        public ObservableCollection<TattooType> tattooTypes { get; set; }
        public WindowSelectTattoo()
        {
            InitializeComponent();
            tattooTypes = DataAccess.GetTattooTypes();
            this.DataContext = this;
        }

        private void btnReadyClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void cbTattooTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var t = cbTattooType.SelectedItem as TattooType;
            tattoos = DataAccess.GetTattoos(t.IdTattoType);
            lvTattoos.ItemsSource = tattoos;
        }
    }
}
