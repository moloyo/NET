using Bussiness.Entities;
using Bussiness.Logic;
using System;
using System.Windows;
using System.Windows.Controls;
using Util;

namespace UI.WPF {

    public partial class ReadUser : Page {
        private readonly UserLogic _ctrlUser = new UserLogic();

        public ReadUser() {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e) {
            try {
                User user = new User();
                user.Username = TxtUsername.Text;
                user = _ctrlUser.Read(user);
                LblName.Content = user.Name;
                LblLastName.Content = user.LastName;
                LblUsername.Content = user.Username;
                LblFileNumber.Content = user.Person;
            } catch (NotFound userE) {
                ModalError errorWindow = new ModalError(userE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }
    }
}
