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
using Bussiness.Entities;
using Bussiness.Logic;

namespace UI.WPF {
    /// <summary>
    /// Interaction logic for ReportStudentAverage.xaml
    /// </summary>
    public partial class ReportStudentAverage : Page {
        public ReportStudentAverage() {
            InitializeComponent();
        }
        private void Show_Click(object sender, System.Windows.RoutedEventArgs e) {
            TxtAverage.Text = ReportLogic.StudentAverage(int.Parse(TxtFileNumber.Text)).ToString();
        }
    }
}
