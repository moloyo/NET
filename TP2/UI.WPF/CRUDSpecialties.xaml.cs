using Bussiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Bussiness.Logic;
using Util;

namespace UI.WPF {

    public partial class CrudSpecialties : Page {

        private readonly SpecialtyLogic _ctrlSpecialty = new SpecialtyLogic();

        public CrudSpecialties() {
            InitializeComponent();
            UpdateList();
        }

        private void UpdateList() {
            try {
                List<Specialty> li = _ctrlSpecialty.GetAll();
                AllSpecialtiesList.ItemsSource = li;
                Util.Util.AddGridViewColumns(li.First(), AllSpecialtiesGridView);
            } catch (NotFound) {
                ModalError errorModal = new ModalError("There are no plans");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e) {
            try {
                Specialty specialty = new Specialty();
                specialty.Id = int.Parse(TxtId.Text);
                specialty = _ctrlSpecialty.Read(specialty);
                TxtDescription.Text = specialty.Description;
            } catch (NotFound specialtyE) {
                ModalError errorWindow = new ModalError(specialtyE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private void Modify_Click(object sender, RoutedEventArgs e) {
            try {
                Specialty specialty = new Specialty {
                    Description = TxtDescription.Text,
                    Id = int.Parse(TxtId.Text)
                };
                _ctrlSpecialty.Modify(specialty);
                UpdateList();
                Modal modal = new Modal("Specialty Updated");
            } catch (NotFound specialtyE) {
                ModalError errorWindow = new ModalError(specialtyE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private void Confirmation_Click(object sender, RoutedEventArgs e) {
            ModalConfirmation modalConfirmation =
                new ModalConfirmation("Are you sure you want to delete this specialty?", Delete_Click);
        }

        private void Delete_Click() {
            try {
                Specialty specialty = new Specialty();
                specialty.Id = int.Parse(TxtId.Text);
                _ctrlSpecialty.Delete(specialty);
                UpdateList();
                Modal modal = new Modal("Specialty Deleted");
            } catch (NotFound specialtyE) {
                ModalError errorWindow = new ModalError(specialtyE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(TxtDescription.Text)) {
                ModalError errorModal = new ModalError("You have to provide a Description");
                return;
            }

            try {
                Specialty specialty = new Specialty();
                specialty.Description = TxtDescription.Text;
                _ctrlSpecialty.Create(specialty);
                UpdateList();
                Modal modal = new Modal("Specialty Created");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }
    }
}
