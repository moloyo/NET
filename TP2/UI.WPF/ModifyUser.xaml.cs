using Bussiness.Entities;
using Bussiness.Logic;
using System;
using System.Windows;
using System.Windows.Controls;
using Util;

namespace UI.WPF {

    public partial class ModifyUser : Page {
        private readonly UserLogic _ctrlUser = new UserLogic();

        public ModifyUser() {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e) {
            try {
                User user = new User();
                user.Username = TxtUsername.Text;
                MapToForm(_ctrlUser.Read(user));
                TxtUsername.IsEnabled = false;
            } catch (NotFound userE) {
                ModalError errorWindow = new ModalError(userE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private void MapToForm(User user) {
            TxtName.Text = user.Name;
            TxtLastName.Text = user.LastName;
            TxtEmail.Text = user.EMail;
        }

        private void Modify_Click(object sender, RoutedEventArgs e) {
            try {
                User user = MapFromForm();
                _ctrlUser.Modify(user);
                Modal modal = new Modal("User Updated");
            } catch (NotFound userE) {
                ModalError errorWindow = new ModalError(userE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private User MapFromForm() {
            return new User {
                Username = TxtUsername.Text,
                Name = TxtName.Text,
                LastName = TxtLastName.Text,
                EMail = TxtEmail.Text
            };
        }
    }
}
