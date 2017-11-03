using Bussiness.Entities;
using Bussiness.Logic;
using System;
using System.Windows;
using System.Windows.Controls;
using Util;

namespace UI.WPF {

    public partial class LogInPage : Page {
        private readonly UserLogic _ctrlUser = new UserLogic();
        public LogInPage() {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e) {
            try {
                User user = new User {
                    Username = TxtUsername.Text,
                    Password = Util.Util.Sha1HashString(TxtPassword.Password)
                };
                _ctrlUser.LogIn(user);
                MainWindow.Window.UnlockAll();
                Modal modal = new Modal("Sucessfully Logged In");
            } catch (LoginException logE) {
                ModalError errorWindow = new ModalError(logE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }
    }
}
