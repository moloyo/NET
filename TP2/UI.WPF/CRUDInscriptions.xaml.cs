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
    /// Interaction logic for CRUDInscriptions.xaml
    /// </summary>
    public partial class CrudInscriptions : Page {

        private readonly SubjectLogic _ctrlSubject = new SubjectLogic();

        private readonly CourseLogic _ctrlCourse = new CourseLogic();

        private readonly InscriptionLogic _ctrlInscription = new InscriptionLogic();

        private List<Subject> SubjectList { get; set; }

        private List<Course> CourseList { get; set; }

        public CrudInscriptions() {
            InitializeComponent();
            LoadSubjects();
            UpdateList();
            DataContext = this;
        }

        private void UpdateList() {
            try {
                List<Inscription> li = _ctrlInscription.GetAll(Bussiness.Logic.Application.GetInstancia().GetActivePerson());
                AllInscriptionsList.ItemsSource = li;
                Util.Util.AddGridViewColumns(li.First(), AllInscriptionsGridView);
            } catch (NotFound) {
                AllInscriptionsList.ItemsSource = null;
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }

        private void LoadSubjects() {
            try {
                SubjectList = _ctrlSubject.GetAllByStudent(Bussiness.Logic.Application.GetInstancia().GetActivePerson());
                CboSubjects.ItemsSource = SubjectList;
                CboCourses.ItemsSource = null;
            } catch (NotFound) {
                ModalError errorModal = new ModalError("There are no subjects");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }

        private void LoadCourses(Subject subject) {
            try {
                CourseList = _ctrlCourse.GetAllFreeBySubject(subject);
                CboCourses.ItemsSource = CourseList;
            } catch (NotFound) {
                ModalError errorModal = new ModalError("There are no courses");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }

        private void CboSubjects_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (CboSubjects.SelectedItem != null) {
                LoadCourses((Subject)CboSubjects.SelectedItem);
            }
        }

        private void Enroll_Click(object sender, System.Windows.RoutedEventArgs e) {

            if (CboSubjects.SelectedItem == null) {
                ModalError errorModal = new ModalError("You have selected a subject");
                return;
            }

            if (CboCourses.SelectedItem == null) {
                ModalError errorModal = new ModalError("You have selected a comission");
                return;
            }
            
            Inscription inscription = new Inscription {
                Student = Bussiness.Logic.Application.GetInstancia().GetActivePerson().FileNumber,
                Course = ((Course)CboCourses.SelectedItem).Id
            };

            _ctrlInscription.Create(inscription);
            LoadSubjects();
            UpdateList();
            Modal Modal = new Modal("Inscription Successfully created");
        }

        private void Confirmation_Click(object sender, RoutedEventArgs e) {
            ModalConfirmation modalConfirmation =
                new ModalConfirmation("Are you sure you want to delete this subject?", Delete_Click);
        }

        private void Delete_Click() {
            if (string.IsNullOrEmpty(TxtId.Text)) {
                ModalError errorModal = new ModalError("You have to provided an ID");
            }

            try {
                Inscription ins = _ctrlInscription.Read(new Inscription { Id = int.Parse(TxtId.Text) });
                if (ins.Student != Bussiness.Logic.Application.GetInstancia().GetActivePerson().FileNumber) {
                    ModalError errorWindow = new ModalError("You have no permission to delete that inscription");
                    return;
                }
            } catch (NotFound insE) {
                ModalError errorWindow = new ModalError(insE.Message);
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }

            try {
                _ctrlInscription.Delete(new Inscription { Id = int.Parse(TxtId.Text) });
                LoadSubjects();
                UpdateList();
                Modal Modal = new Modal("Inscription Successfully Deleted");
            } catch (NotFound insE) {
                ModalError errorWindow = new ModalError(insE.Message);
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }
    }
}
