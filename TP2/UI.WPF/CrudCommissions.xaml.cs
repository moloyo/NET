using Bussiness.Entities;
using Bussiness.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Util;

namespace UI.WPF {
    /// <summary>
    /// Interaction logic for CrudCommission.xaml
    /// </summary>
    public partial class CrudCommissions : Page {

        private readonly CommissionLogic _ctrlCommission = new CommissionLogic();

        private readonly PlanLogic _ctrlPlan = new PlanLogic();

        private readonly SpecialtyLogic _ctrlSpecialties = new SpecialtyLogic();

        private List<Plan> PlanList { get; set; }

        public CrudCommissions() {
            InitializeComponent();
            LoadSpecialties();
            DataContext = this;
            UpdateList();
        }

        private void LoadSpecialties() {
            try {
                CboSpecialties.ItemsSource = _ctrlSpecialties.GetAll();
                CboPlans.ItemsSource = null;
            } catch (NotFound) {
                ModalError errorModal = new ModalError("There are no Specialties");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }
        private void CboSpecialties_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (CboSpecialties.SelectedItem != null) {
                LoadPlans((Specialty)CboSpecialties.SelectedItem);
            }
        }

        private void LoadPlans(Specialty specialty) {
            try {
                CboPlans.ItemsSource = _ctrlPlan.GetAllBySpecialty(specialty);
            } catch (NotFound) {
                ModalError errorModal = new ModalError("There are no plans with that specialty");
                CboPlans.ItemsSource = null;
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }

        private void UpdateList() {
            try {
                List<Commission> li = _ctrlCommission.GetAll();
                AllCommissionsList.ItemsSource = li;
                Util.Util.AddGridViewColumns(li.First(), AllCommissionsGridView);
            } catch (NotFound) {
                ModalError errorModal = new ModalError("There are no commissions");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e) {
            try {
                Commission commission = new Commission();
                commission.Id = int.Parse(TxtId.Text);
                commission = _ctrlCommission.Read(commission);
                MapToForm(commission);
            } catch (NotFound commissionE) {
                ModalError errorWindow = new ModalError(commissionE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private void MapToForm(Commission commission) {
            TxtDescription.Text = commission.Description;
            TxtYear.Text = commission.YearSpecialty.ToString();
            try {
                Plan plan = _ctrlPlan.Read(new Plan { Id = commission.Planid });
                Specialty specialty = _ctrlSpecialties.GetByPlan(plan);
                CboSpecialties.SelectedItem = CboSpecialties.Items.OfType<Specialty>()
                .FirstOrDefault(item => item.Id == specialty.Id);
                CboPlans.SelectedItem = CboPlans.Items.OfType<Plan>()
                .FirstOrDefault(item => item.Id == plan.Id);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private Commission MapFromForm() {
            return new Commission {
                Description = TxtDescription.Text,
                YearSpecialty = int.Parse(TxtYear.Text),
                Planid = ((Plan)CboPlans.SelectedItem).Id
            };
        }

        private void Modify_Click(object sender, RoutedEventArgs e) {
            try {
                Commission commission = MapFromForm();
                commission.Id = int.Parse(TxtId.Text);
                _ctrlCommission.Modify(commission);
                UpdateList();
                Modal modal = new Modal("Commission Updated");
            } catch (NotFound commissionE) {
                ModalError errorWindow = new ModalError(commissionE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private void Confirmation_Click(object sender, RoutedEventArgs e) {
            ModalConfirmation modalConfirmation =
                new ModalConfirmation("Are you sure you want to delete this commission?", Delete_Click);
        }

        private void Delete_Click() {
            try {
                Commission commission = new Commission();
                commission.Id = int.Parse(TxtId.Text);
                _ctrlCommission.Delete(commission);
                UpdateList();
                Modal modal = new Modal("Commission Deleted");
            } catch (NotFound commissionE) {
                ModalError errorWindow = new ModalError(commissionE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(TxtDescription.Text)) {
                ModalError errorModal = new ModalError("You have to provide a Description");
                return;
            }

            if (string.IsNullOrEmpty(TxtYear.Text)) {
                ModalError errorModal = new ModalError("You have to provide the Year");
                return;
            }

            if (CboPlans.SelectedItem == null) {
                ModalError errorModal = new ModalError("You have to provide a Plan");
                return;
            }

            try {
                Commission commission = MapFromForm();
                _ctrlCommission.Create(commission);
                UpdateList();
                Modal modal = new Modal("Commission Created");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }
    }
}
