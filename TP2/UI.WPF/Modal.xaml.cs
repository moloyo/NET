using System.Windows;

namespace UI.WPF {

    public partial class Modal : Window {

        public Modal(string message) {
            InitializeComponent();
            Message.Text = message;
            ShowDialog();
        }
        private void Close_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
