using Bussiness.Entities;
using Bussiness.Logic;
using System;
using System.Windows;
using System.Windows.Controls;
using Util;

namespace UI.WPF {
    public partial class DeleteUser : Page {

        private readonly UserLogic _ctrlUser = new UserLogic();

        public DeleteUser() {
            InitializeComponent();
        }

        private void Confirmation_Click(object sender, RoutedEventArgs e) {
            ModalConfirmation modalConfirmation =
                new ModalConfirmation("Are you sure you want to delete this user?", Delete_Click);
        }

        private void Delete_Click() {
            try {
                User user = new User();
                user.Username = TxtUsername.Text;
                _ctrlUser.Delete(user);
                Modal modal = new Modal("User Deleted");
            } catch (NotFound userE) {
                ModalError errorWindow = new ModalError(userE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }
    }
}
