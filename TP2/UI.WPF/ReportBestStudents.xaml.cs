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
using Bussiness.Logic;

namespace UI.WPF {
    /// <summary>
    /// Interaction logic for ReportBestStudents.xaml
    /// </summary>
    public partial class ReportBestStudents : Page {
        public ReportBestStudents() {
            InitializeComponent();
        }

        private void Show_Click(object sender, System.Windows.RoutedEventArgs e) {
            reportGrid.DataContext = ReportLogic.BestStudentByYear(int.Parse(TxtYear.Text));
        }

        private void Export_Click(object sender, RoutedEventArgs e) {
            ReportLogic.Print(reportGrid);
        }
    }
}
