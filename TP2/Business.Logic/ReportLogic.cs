using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Data.Database;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Bussiness.Logic {
    public class ReportLogic {
        private static readonly Adapter adapters = new Adapter();
        public static DataTable BestStudentByYear(int year) {
            SqlCommand cmd = new SqlCommand("BestStudentByYear", adapters.Coon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@year", year);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable resultsTable = new DataTable();
            adapter.Fill(resultsTable);
            return resultsTable;
        }

        public static int StudentAverage(int filenumber) {
            SqlCommand cmd = new SqlCommand("StudentAverage");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@filenumber", filenumber);
            return adapters.ExecuteCommandScalar(cmd);
        }

        public static DataTable AttendingList(int filenumber, int course) {
            SqlCommand cmd = new SqlCommand("AttendingList", adapters.Coon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@filenumber", filenumber);
            cmd.Parameters.AddWithValue("@course", course);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable resultsTable = new DataTable();
            adapter.Fill(resultsTable);
            return resultsTable;
        }

        public static void Print(DataGrid grid) {

            PdfPTable table = new PdfPTable(grid.Columns.Count);
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter writer = PdfWriter.GetInstance(doc, new System.IO.FileStream("Test.pdf", System.IO.FileMode.Create));
            doc.Open();
            for (int j = 0; j < grid.Columns.Count; j++) {
                table.AddCell(new Phrase(grid.Columns[j].Header.ToString()));
            }
            table.HeaderRows = 1;
            IEnumerable itemsSource = grid.ItemsSource as IEnumerable;
            if (itemsSource != null) {
                foreach (var item in itemsSource) {
                    DataGridRow row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                    if (row != null) {
                        DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(row);
                        for (int i = 0; i < grid.Columns.Count; ++i) {
                            DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(i);
                            TextBlock txt = cell.Content as TextBlock;
                            if (txt != null) {
                                table.AddCell(new Phrase(txt.Text));
                            }
                        }
                    }
                }

                doc.Add(table);
                doc.Close();
            }
        }
        private static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++) {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    return (T)child;
                else {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
    }
}

