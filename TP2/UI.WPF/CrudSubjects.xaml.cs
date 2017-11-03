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
    /// Interaction logic for CrudSubjects.xaml
    /// </summary>
    public partial class CrudSubjects : Page {

        private readonly SubjectLogic _ctrlSubject = new SubjectLogic();

        private readonly PlanLogic _ctrlPlan = new PlanLogic();

        private readonly SpecialtyLogic _ctrlSpecialties = new SpecialtyLogic();

        private List<Plan> PlanList { get; set; }

        public CrudSubjects() {
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
                List<Subject> li = _ctrlSubject.GetAll();
                AllSubjectsList.ItemsSource = li;
                Util.Util.AddGridViewColumns(li.First(), AllSubjectsGridView);
            } catch (NotFound) {
                ModalError errorModal = new ModalError("There are no subjects");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e) {
            try {
                Subject subject = new Subject();
                subject.Id = int.Parse(TxtId.Text);
                subject = _ctrlSubject.Read(subject);
                MapToForm(subject);
            } catch (NotFound subjectE) {
                ModalError errorWindow = new ModalError(subjectE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private void MapToForm(Subject subject) {
            TxtDescription.Text = subject.Description;
            TxtWhs.Text = subject.WeeklyHs.ToString();
            TxtThs.Text = subject.TotalHs.ToString();
            try {
                Plan plan = _ctrlPlan.Read(new Plan { Id = subject.Planid });
                Specialty specialty = _ctrlSpecialties.GetByPlan(plan);
                CboSpecialties.SelectedItem = CboSpecialties.Items.OfType<Specialty>()
                .FirstOrDefault(item => item.Id == specialty.Id);
                CboPlans.SelectedItem = CboPlans.Items.OfType<Plan>()
                .FirstOrDefault(item => item.Id == plan.Id);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private Subject MapFromForm() {
            return new Subject {
                Description = TxtDescription.Text,
                WeeklyHs = int.Parse(TxtWhs.Text),
                TotalHs = int.Parse(TxtThs.Text),
                Planid = ((Plan)CboPlans.SelectedItem).Id
            };
        }

        private void Modify_Click(object sender, RoutedEventArgs e) {
            try {
                Subject subject = MapFromForm();
                subject.Id = int.Parse(TxtId.Text);
                _ctrlSubject.Modify(subject);
                UpdateList();
                Modal modal = new Modal("Subject Updated");
            } catch (NotFound subjectE) {
                ModalError errorWindow = new ModalError(subjectE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private void Confirmation_Click(object sender, RoutedEventArgs e) {
            ModalConfirmation modalConfirmation =
                new ModalConfirmation("Are you sure you want to delete this subject?", Delete_Click);
        }

        private void Delete_Click() {
            try {
                Subject subject = new Subject();
                subject.Id = int.Parse(TxtId.Text);
                _ctrlSubject.Delete(subject);
                UpdateList();
                Modal modal = new Modal("Subject Deleted");
            } catch (NotFound subjectE) {
                ModalError errorWindow = new ModalError(subjectE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(TxtDescription.Text)) {
                ModalError errorModal = new ModalError("You have to provide a Description");
                return;
            }

            if (string.IsNullOrEmpty(TxtWhs.Text) || string.IsNullOrEmpty(TxtThs.Text)) {
                ModalError errorModal = new ModalError("You have to provide Weekly hours and Total hours");
                return;
            }

            if (CboPlans.SelectedItem == null) {
                ModalError errorModal = new ModalError("You have to provide a Plan");
                return;
            }

            try {
                Subject subject = MapFromForm();
                _ctrlSubject.Create(subject);
                UpdateList();
                Modal modal = new Modal("Subject Created");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }
    }
}
