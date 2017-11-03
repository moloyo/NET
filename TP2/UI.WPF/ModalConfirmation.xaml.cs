using System;
using System.Windows;

namespace UI.WPF {
    public partial class ModalConfirmation : Window {

        private readonly Action _callMethod;
        public ModalConfirmation(string message, Action method) {
            InitializeComponent();
            Message.Text = message;
            _callMethod = method;
            ShowDialog();
        }

        private void Close_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void Accept_Click(object sender, RoutedEventArgs e) {
            Close();
            _callMethod();
        }
    }
}
