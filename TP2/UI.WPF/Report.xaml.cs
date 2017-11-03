using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using Data.Database;
using Microsoft.Reporting.WinForms;

namespace UI.WPF {
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window {
        public Report() {
            InitializeComponent();
            Adapter adapters = new Adapter();
            SqlCommand cmd = new SqlCommand("AttendingList", adapters.Coon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@filenumber", 42701);
            cmd.Parameters.AddWithValue("@course", 6);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ResultsTable = new DataTable();
            adapter.Fill(ResultsTable);
            //gridEmployees.DataContext = ResultsTable.DefaultView;
        }
    }
}
