using Bussiness.Entities;
using Bussiness.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Util;

namespace UI.WPF {

    public partial class CrudPlans : Page {
        private readonly PlanLogic _ctrlPlan = new PlanLogic();
        private readonly SpecialtyLogic _ctrlSpecialty = new SpecialtyLogic();

        private List<Specialty> SpecialtyList { get; set; }

        public CrudPlans() {
            InitializeComponent();
            LoadSpecialties();
            DataContext = this;
            UpdateList();
        }

        private void LoadSpecialties() {
            try {
                SpecialtyList = _ctrlSpecialty.GetAll();
                CboSpecialties.ItemsSource = SpecialtyList;
            } catch (NotFound) {
                ModalError errorModal = new ModalError("There are no plans");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }

        private void UpdateList() {
            try {
                List<Plan> li = _ctrlPlan.GetAll();
                AllPlansList.ItemsSource = li;
                Util.Util.AddGridViewColumns(li.First(), AllPlansGridView);
            } catch (NotFound) {
                ModalError errorModal = new ModalError("There are no plans");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e) {
            try {
                Plan plan = new Plan();
                plan.Id = int.Parse(TxtId.Text);
                plan = _ctrlPlan.Read(plan);
                TxtDescription.Text = plan.Description;
                CboSpecialties.SelectedItem = CboSpecialties.Items.OfType<Specialty>()
                    .FirstOrDefault(item => item == _ctrlPlan.GetSpecialty(plan));
            } catch (NotFound planE) {
                ModalError errorWindow = new ModalError(planE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private void Modify_Click(object sender, RoutedEventArgs e) {
            try {
                Plan plan = new Plan {
                    Description = TxtDescription.Text,
                    Id = int.Parse(TxtId.Text),
                    Specialty = ((Specialty)CboSpecialties.SelectedItem).Id
                };
                _ctrlPlan.Modify(plan);
                UpdateList();
                Modal modal = new Modal("Plan Updated");
            } catch (NotFound planE) {
                ModalError errorWindow = new ModalError(planE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private void Confirmation_Click(object sender, RoutedEventArgs e) {
            ModalConfirmation modalConfirmation =
                new ModalConfirmation("Are you sure you want to delete this plan?", Delete_Click);
        }

        private void Delete_Click() {
            try {
                Plan plan = new Plan();
                plan.Id = int.Parse(TxtId.Text);
                _ctrlPlan.Delete(plan);
                UpdateList();
                Modal modal = new Modal("Plan Deleted");
            } catch (NotFound planE) {
                ModalError errorWindow = new ModalError(planE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(TxtDescription.Text)) {
                ModalError errorModal = new ModalError("You have to provide a Description");
                return;
            }

            if (CboSpecialties.SelectedItem == null) {
                ModalError errorModal = new ModalError("You have to provide a Specialty");
                return;
            }

            try {
                Plan plan = new Plan();
                plan.Description = TxtDescription.Text;
                plan.Specialty = ((Specialty)CboSpecialties.SelectedItem).Id;
                _ctrlPlan.Create(plan);
                UpdateList();
                Modal modal = new Modal("Plan Created");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }
    }
}
