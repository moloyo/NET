using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Bussiness.Entities;
using Bussiness.Logic;
using Util;
using Application = Bussiness.Logic.Application;

namespace UI.WPF {
    /// <summary>
    /// Interaction logic for CrudTeacherCourse.xaml
    /// </summary>
    public partial class CrudTeacherCourses : Page {

        private readonly CourseLogic _ctrlCourse = new CourseLogic();

        private readonly TeacherCourseLogic _ctrlTeacherCourse = new TeacherCourseLogic();

        private readonly SubjectLogic _ctrlSubject = new SubjectLogic();

        private readonly CommissionLogic _ctrlCommission = new CommissionLogic();

        private readonly SpecialtyLogic _ctrlSpecialties = new SpecialtyLogic();

        private readonly PlanLogic _ctrlPlan = new PlanLogic();

        private List<Subject> SubjectList { get; set; }

        private List<Course> CourseList { get; set; }

        private List<Commission> CommissionList { get; set; }

        public CrudTeacherCourses() {
            InitializeComponent();
            LoadSpecialties();
            DataContext = this;
            UpdateList();
        }

        private void UpdateList() {
            try {
                AllTeacherCoursesList.ItemsSource = null;
                List<TeacherCourse> li = _ctrlTeacherCourse.GetAll();
                AllTeacherCoursesList.ItemsSource = li;
                Util.Util.AddGridViewColumns(li.First(), AllTeacherCoursesGridView);
            } catch (NotFound) {
                ModalError errorModal = new ModalError("There are no courses");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }
        private void LoadSpecialties() {
            try {
                CboSpecialties.SelectedItem = null;
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
                if (string.IsNullOrEmpty(TxtFileNumber.Text)){
                    ModalError errorModal = new ModalError("You have to provide a File Number");
                    return;
                }
                LoadPlans((Specialty)CboSpecialties.SelectedItem);
            } else {
                CboPlans.SelectedItem = null;
            }
        }
        private void LoadPlans(Specialty specialty) {
            try {
                CboPlans.ItemsSource = _ctrlPlan.GetAllBySpecialty(specialty);
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
                LoadSubjects();
            } else {
                CboSubjects.SelectedItem = null;
            }
        }

        private void LoadSubjects() {
            try {
                SubjectList = _ctrlSubject.GetAllByTeacher(new Person { FileNumber = int.Parse(TxtFileNumber.Text) });
                CboSubjects.ItemsSource = SubjectList;
            } catch (NotFound) {
                ModalError errorModal = new ModalError("There are no subjects");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }

        private void CboSubjects_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (CboSubjects.SelectedItem != null) {
                LoadCommissions((Subject)CboSubjects.SelectedItem);
            } else {
                CboCommissions.SelectedItem = null;
            }
        }

        private void LoadCommissions(Subject subject) {
            try {
                CourseList = _ctrlCourse.GetAllBySubjectByTeacher(subject, new Person { FileNumber = int.Parse(TxtFileNumber.Text) });
                CboCommissions.ItemsSource = CourseList;
            } catch (NotFound) {
                ModalError errorModal = new ModalError("There are no commissions");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }

        private void CboCommissions_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (CboCommissions.SelectedItem != null) {
                LoadPositions();
            } else {
                CboPositions.ItemsSource = null;
            }
        }

        private void LoadPositions() {
            CboPositions.ItemsSource = Enum.GetNames(typeof(Positions));
        }

        private void Confirmation_Click(object sender, RoutedEventArgs e) {
            ModalConfirmation modalConfirmation =
                new ModalConfirmation("Are you sure you want to delete this course?", Delete_Click);
        }

        private void Delete_Click() {
            try {
                TeacherCourse teacherCourse = new TeacherCourse();
                teacherCourse.Id = int.Parse(TxtFileNumber2.Text);
                _ctrlTeacherCourse.Delete(teacherCourse);
                UpdateList();
                Modal modal = new Modal("Course Deleted");
            } catch (NotFound courseE) {
                ModalError errorWindow = new ModalError(courseE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private void Asign_Click(object sender, RoutedEventArgs e) {

            if (string.IsNullOrEmpty(TxtFileNumber.Text))
            {
                ModalError errorModal = new ModalError("You have to complete all fields");
                return;
            }

            if (CboSpecialties.SelectedItem == null)
            {
                ModalError errorModal = new ModalError("You have to select a specialty");
                return;
            }

            if (CboPlans.SelectedItem == null)
            {
                ModalError errorModal = new ModalError("You have to select a plan");
                return;
            }

            if (CboSubjects.SelectedItem == null) {
                ModalError errorModal = new ModalError("You have to select a subject");
                return;
            }

            if (CboCommissions.SelectedItem == null) {
                ModalError errorModal = new ModalError("You have to select a course");
                return;
            }

            if (CboPositions.SelectedItem == null) {
                ModalError errorModal = new ModalError("You have to select a position");
                return;
            }

            TeacherCourse teacherCourse = new TeacherCourse {
                Teacher = int.Parse(TxtFileNumber.Text),
                Course = ((Course)CboCommissions.SelectedItem).Id,
                Position = (int)Enum.Parse(typeof(Positions), CboPositions.SelectedItem.ToString())
            };

            _ctrlTeacherCourse.Create(teacherCourse);
            LoadSpecialties();
            Modal Modal = new Modal("Teacher Successfully assigned");
            UpdateList();
        }
    }
}
