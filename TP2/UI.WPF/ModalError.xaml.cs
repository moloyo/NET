using System.Windows;

namespace UI.WPF {

    public partial class ModalError : Window {
        public ModalError() {
            InitializeComponent();
            ErrorMessage.Text = "Unexpected error";
            ShowDialog();
        }

        public ModalError(string errorMessage) {
            InitializeComponent();
            ErrorMessage.Text = errorMessage;
            ShowDialog();
        }

        private void Close_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
