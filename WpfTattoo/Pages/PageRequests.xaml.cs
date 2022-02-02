using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace WpfTattoo.Pages
{
    /// <summary>
    /// Interaction logic for PageRequests.xaml
    /// </summary>
    public partial class PageRequests : Page
    {
        public ObservableCollection<SpecialRequest> Requests { get; set; }
        public User currentUser { get; set; }
        
        public PageRequests(User user)
        {
            InitializeComponent();
            currentUser = user;

            Requests = DataAccess.GetSpecialRequests(currentUser);
            this.DataContext = this;
        }

        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnExcelClick(object sender, RoutedEventArgs e)
        {
            var application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = application.Worksheets.Item[1];
            worksheet.Name = "Requests";

            int startRowIndex = 1;

            worksheet.Cells[1][startRowIndex] = "IdRequest";
            worksheet.Cells[2][startRowIndex] = "IdUser";
            worksheet.Cells[3][startRowIndex] = "IdTattoo";
            worksheet.Cells[4][startRowIndex] = "IdBodyPart";
            worksheet.Cells[5][startRowIndex] = "Date";

            for (int i = 0; i < Requests.Count(); i++)
            {
                ++startRowIndex;
                worksheet.Cells[1][startRowIndex] = Requests[i].IdRequest;
                worksheet.Cells[2][startRowIndex] = Requests[i].IdUser;
                worksheet.Cells[3][startRowIndex] = Requests[i].IdTattoo;
                worksheet.Cells[4][startRowIndex] = Requests[i].IdBodyPart;
                worksheet.Cells[5][startRowIndex] = Requests[i].Date;
            }

            worksheet.Columns.AutoFit();

            application.Visible = true;
        }

        private void btnWordClick(object sender, RoutedEventArgs e)
        {
            var application = new Word.Application();
            Word.Document document = application.Documents.Add();

            application.Visible = true;
        }
    }
}
