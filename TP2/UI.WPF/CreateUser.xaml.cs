using Bussiness.Entities;
using Bussiness.Logic;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Util;

namespace UI.WPF {

    public partial class CreateUser : Page {
        private readonly UserLogic _ctrlUser = new UserLogic();

        private readonly PersonLogic _ctrlPerson = new PersonLogic();

        public CreateUser() {
            InitializeComponent();
            LoadTypes();
        }

        private void LoadTypes() {
            CboTypes.ItemsSource = Enum.GetNames(typeof(PersonTypes));
        }

        private void Create_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(TxtUsername.Text) || string.IsNullOrEmpty(TxtPassword.Password) ||
                string.IsNullOrEmpty(TxtFileNumber.Text) || string.IsNullOrEmpty(TxtRePassword.Password)) {
                ModalError errorModal = new ModalError("You have to complete all fields");
                return;
            }

            if (CboTypes.SelectedItem == null) {
                ModalError errorModal = new ModalError("You have to provide a type");
                return;
            }

            if (!String.Equals(TxtPassword.Password, TxtRePassword.Password)) {
                ModalError errorModal = new ModalError("Passwords don't match");
                return;
            }

            try {
                _ctrlUser.CheckUsername(new User { Username = TxtUsername.Text });
                ModalError errorModal = new ModalError("Username taken");
                return;
            } catch (NotFound) { } catch (Exception) {
                ModalError errorModal = new ModalError();
                return;
            }

            try {
                Person per = _ctrlPerson.Read(new Person { FileNumber = int.Parse(TxtFileNumber.Text) });
                if (per.TypePerson != (int)Enum.Parse(typeof(PersonTypes), CboTypes.SelectedItem.ToString())) {
                    ModalError errorModal = new ModalError("File Number Does not correspond to the type");
                    return;
                }
            } catch (NotFound) {
                ModalError errorModal = new ModalError("File Number Not Found");
                return;
            } catch (Exception) {
                ModalError errorModal = new ModalError();
                return;
            }

            User user = new User {
                Username = TxtUsername.Text,
                Password = Util.Util.Sha1HashString(TxtPassword.Password),
                Person = int.Parse(TxtFileNumber.Text)
            };

            try {
                _ctrlUser.Create(user);
                Modal modal = new Modal("User Created");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }
    }
}
