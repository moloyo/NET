using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bussiness.Entities;
using Bussiness.Logic;
using Data.Database;
using Util;

namespace UI.WPF {
    /// <summary>
    /// Interaction logic for ReportAttendingList.xaml
    /// </summary>
    public partial class ReportAttendingList : Page {

        private readonly SubjectLogic _ctrlSubject = new SubjectLogic();

        private readonly CourseLogic _ctrlCourse = new CourseLogic();

        private readonly InscriptionLogic _ctrlInscription = new InscriptionLogic();

        private readonly SpecialtyLogic _ctrlSpecialties = new SpecialtyLogic();

        private readonly PlanLogic _ctrlPlan = new PlanLogic();

        private List<Subject> SubjectList { get; set; }

        private List<Course> CourseList { get; set; }

        private Person ActiveTeacher { get; set; }

        public ReportAttendingList() {
            InitializeComponent();
            ActiveTeacher = Bussiness.Logic.Application.GetInstancia().GetActivePerson();
            LoadSpecialties();
            DataContext = this;           
        }

        private void LoadSpecialties() {
            try {
                CboSpecialties.SelectedItem = null;
                CboSpecialties.ItemsSource = _ctrlSpecialties.GetByTeacher(ActiveTeacher);
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
            } else {
                CboPlans.SelectedItem = null;
            }
        }
        private void LoadPlans(Specialty specialty) {
            try {
                CboPlans.ItemsSource = _ctrlPlan.GetAllBySpecialtyAndTeacher(ActiveTeacher, specialty);
                CboSubjects.ItemsSource = null;
            } catch (NotFound) {
                ModalError errorModal = new ModalError("There are no plans with that specialty");
                CboPlans.ItemsSource = null;
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }

        private void CboPlans_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (CboPlans.SelectedItem != null) {
                LoadSubjects((Plan)CboPlans.SelectedItem);
            } else {
                CboSubjects.SelectedItem = null;
            }
        }

        private void LoadSubjects(Plan plan) {
            try {
                SubjectList = _ctrlSubject.GetAllByTeacherAndPlan(ActiveTeacher, plan);
                CboSubjects.ItemsSource = SubjectList;
                CboCourses.ItemsSource = null;
            } catch (NotFound) {
                ModalError errorModal = new ModalError("There are no subjects");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }

        private void CboSubjects_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (CboSubjects.SelectedItem != null) {
                LoadCourses((Subject)CboSubjects.SelectedItem);
            }
        }

        private void LoadCourses(Subject subject) {
            try {
                CourseList = _ctrlCourse.GetActualBySubjectByTeacher(subject, ActiveTeacher);
                CboCourses.ItemsSource = CourseList;
            } catch (NotFound) {
                ModalError errorModal = new ModalError("There are no courses");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }

        private void Show_Click(object sender, System.Windows.RoutedEventArgs e) {
            reportGrid.DataContext = ReportLogic.AttendingList(ActiveTeacher.FileNumber, ((Course)CboCourses.SelectedItem).Id).DefaultView;
            LoadSpecialties();
        }

        private void Export_Click(object sender, RoutedEventArgs e) {
            ReportLogic.Print(reportGrid);
        }
    }
}
