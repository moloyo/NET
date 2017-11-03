using Bussiness.Entities;
using Bussiness.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Util;

namespace UI.WPF {

    public partial class CrudCourses : Page {
        private readonly CourseLogic _ctrlCourse = new CourseLogic();

        private readonly SubjectLogic _ctrlSubject = new SubjectLogic();

        private readonly CommissionLogic _ctrlCommission = new CommissionLogic();

        private readonly SpecialtyLogic _ctrlSpecialties = new SpecialtyLogic();

        private readonly PlanLogic _ctrlPlan = new PlanLogic();

        private List<Subject> SubjectList { get; set; }
        private List<Commission> CommissionList { get; set; }

        public CrudCourses() {
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
            }
        }

        private void LoadSubjects(Plan plan) {
            try {
                SubjectList = _ctrlSubject.GetAllByPlan(plan);
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
            }
        }

        private void LoadCommissions(Subject subject) {
            try {
                CommissionList = _ctrlCommission.GetAllBySubject(subject);
                CboCommissions.ItemsSource = CommissionList;
            } catch (NotFound) {
                ModalError errorModal = new ModalError("There are no commissions");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }


        private void UpdateList() {
            try {
                List<Course> li = _ctrlCourse.GetAll();
                AllCoursesList.ItemsSource = li;
                Util.Util.AddGridViewColumns(li.First(), AllCoursesGridView);
            } catch (NotFound) {
                ModalError errorModal = new ModalError("There are no courses");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e) {
            try {
                Course course = new Course();
                course.Id = int.Parse(TxtId.Text);
                course = _ctrlCourse.Read(course);
                MapToForm(course);
            } catch (NotFound courseE) {
                ModalError errorWindow = new ModalError(courseE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private void MapToForm(Course course) {
            TxtYear.Text = course.YearCourse.ToString();
            TxtQuota.Text = course.Quota.ToString();
            try {
                CboCommissions.SelectedItem = CboCommissions.Items.OfType<Commission>()
                .FirstOrDefault(item => item == _ctrlCourse.GetCommission(course));
                CboSubjects.SelectedItem = CboSubjects.Items.OfType<Subject>()
                .FirstOrDefault(item => item == _ctrlCourse.GetSubject(course));
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private Course MapFromForm() {
            return new Course {
                YearCourse = int.Parse(TxtYear.Text),
                Quota = int.Parse(TxtQuota.Text),
                Commission = ((Commission)CboCommissions.SelectedItem).Id,
                Subject = ((Subject)CboSubjects.SelectedItem).Id
            };
        }

        private void Modify_Click(object sender, RoutedEventArgs e) {
            try {
                Course course = MapFromForm();
                course.Id = int.Parse(TxtId.Text);
                _ctrlCourse.Modify(course);
                UpdateList();
                Modal modal = new Modal("Course Updated");
            } catch (NotFound courseE) {
                ModalError errorWindow = new ModalError(courseE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private void Confirmation_Click(object sender, RoutedEventArgs e) {
            ModalConfirmation modalConfirmation =
                new ModalConfirmation("Are you sure you want to delete this course?", Delete_Click);
        }

        private void Delete_Click() {
            try {
                Course course = new Course();
                course.Id = int.Parse(TxtId.Text);
                _ctrlCourse.Delete(course);
                UpdateList();
                Modal modal = new Modal("Course Deleted");
            } catch (NotFound courseE) {
                ModalError errorWindow = new ModalError(courseE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e) {

            if (string.IsNullOrEmpty(TxtYear.Text)) {
                ModalError errorModal = new ModalError("You have to provide the Year");
                return;
            }

            if (string.IsNullOrEmpty(TxtQuota.Text)) {
                ModalError errorModal = new ModalError("You have to provide a Quota");
                return;
            }

            if (CboSubjects.SelectedItem == null) {
                ModalError errorModal = new ModalError("You have to provide a Subject");
                return;
            }

            if (CboCommissions.SelectedItem == null) {
                ModalError errorModal = new ModalError("You have to provide a Commission");
                return;
            }

            try {
                Course course = MapFromForm();
                _ctrlCourse.Create(course);
                UpdateList();
                Modal modal = new Modal("Course Created");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }


    }
}
