using System.Windows;
using Bussiness.Entities;
using UI.WPF;
using Util;
using System.Windows.Forms;
using Bussiness.Logic;

//using Report;


namespace UI.WPF {

    public partial class MainWindow : Window {
        public static MainWindow Window;

        public MainWindow() {
            Util.Logs.Logger("Estoy usando Logger desde Útiles");
            InitializeComponent();
            MainFrame.Navigate(new LandPage());
            LogIn.Visibility = Visibility.Visible;
            LogOut.Visibility = Visibility.Collapsed;
            MainWindow.Window = this;
            LockAll();
        }

        private void _logIn_Click(object sender, RoutedEventArgs e) {
            MainFrame.Navigate(new LogInPage());
        }
        private void _logOut_Click(object sender, RoutedEventArgs e) {
            MainFrame.Navigate(new LandPage());
            LockAll();
        }

        private void CreateUserMenu_Click(object sender, RoutedEventArgs e) {
            MainFrame.Navigate(new CreateUser());
        }
        private void DeleteUserMenu_Click(object sender, RoutedEventArgs e) {
            MainFrame.Navigate(new DeleteUser());
        }
        private void ModifyUserMenu_Click(object sender, RoutedEventArgs e) {
            MainFrame.Navigate(new ModifyUser());
        }
        private void ReadUserMenu_Click(object sender, RoutedEventArgs e) {
            MainFrame.Navigate(new ReadUser());
        }
        private void ListAllUserMenu_Click(object sender, RoutedEventArgs e) {
            MainFrame.Navigate(new ListAll());
        }

        public void UnlockAll() {
            User activeUser = Bussiness.Logic.Application.GetInstancia().GetActiveUser();
            LogIn.Visibility = Visibility.Collapsed;
            LogOut.Visibility = Visibility.Visible;
            UserMenu.IsEnabled = Validators.UserHasPermission(activeUser, Privileges.AnyUser);
            PlanMenu.IsEnabled = Validators.UserHasPermission(activeUser, Privileges.AnyPlan);
            SubjectMenu.IsEnabled = Validators.UserHasPermission(activeUser, Privileges.AnySubject);
            InscriptionMenu.IsEnabled = Validators.UserHasPermission(activeUser, Privileges.AnyInscription);
            StudentsMenu.IsEnabled = Validators.UserHasPermission(activeUser, Privileges.AnyPerson);
            CommissionMenu.IsEnabled = Validators.UserHasPermission(activeUser, Privileges.AnyCommission);
            SpecialtyMenu.IsEnabled = Validators.UserHasPermission(activeUser, Privileges.AnySpecialty);
            CourseMenu.IsEnabled = Validators.UserHasPermission(activeUser, Privileges.AnyCourse);
            TeachersMenu.IsEnabled = Validators.UserHasPermission(activeUser, Privileges.AnyPerson);
            QualificationsMenu.IsEnabled = Validators.UserHasPermission(activeUser, Privileges.AnyPerson);
            ReportsMenu.IsEnabled = Validators.UserHasPermission(activeUser, Privileges.AnyPerson);
            TeacherCourseMenu.IsEnabled = Validators.UserHasPermission(activeUser, Privileges.AnyPerson);
            TxtUsername.Header = activeUser.Username;
            TxtUsername.Visibility = Visibility.Visible;
            MainFrame.Navigate(new LandPage());
        }
        private void LockAll() {
            LogIn.Visibility = Visibility.Visible;
            LogOut.Visibility = Visibility.Collapsed;
            UserMenu.IsEnabled = false;
            PlanMenu.IsEnabled = false;
            StudentsMenu.IsEnabled = false;
            CommissionMenu.IsEnabled = false;
            SubjectMenu.IsEnabled = false;
            InscriptionMenu.IsEnabled = false;
            SpecialtyMenu.IsEnabled = false;
            CourseMenu.IsEnabled = false;
            TxtUsername.Visibility = Visibility.Collapsed;
            TeachersMenu.IsEnabled = false;
            TeacherCourseMenu.IsEnabled = false;
            QualificationsMenu.IsEnabled = false;
            ReportsMenu.IsEnabled = false;
        }

        private void SpecialtyMenu_Click(object sender, RoutedEventArgs e) {
            MainFrame.Navigate(new CrudSpecialties());
        }

        private void PlanMenu_Click(object sender, RoutedEventArgs e) {
            MainFrame.Navigate(new CrudPlans());
        }

        private void SubjectMenu_Click(object sender, RoutedEventArgs e) {
            MainFrame.Navigate(new CrudSubjects());
        }

        private void CommissionMenu_Click(object sender, RoutedEventArgs e) {
            MainFrame.Navigate(new CrudCommissions());
        }
        private void CourseMenu_Click(object sender, RoutedEventArgs e) {
            MainFrame.Navigate(new CrudCourses());
        }

        private void CreateStudentMenu_Click(object sender, RoutedEventArgs e) {
            MainFrame.Navigate(new CrudPerson(Bussiness.Entities.PersonTypes.Student));
        }
        private void CreateTeacherMenu_Click(object sender, RoutedEventArgs e) {
            MainFrame.Navigate(new CrudPerson(Bussiness.Entities.PersonTypes.Teacher));
        }

        private void ListAllTeacherItem_Click(object sender, RoutedEventArgs e) {
            MainFrame.Navigate(new ListAllPerson(Bussiness.Entities.PersonTypes.Teacher));
        }

        private void ListAllStudentItem_Click(object sender, RoutedEventArgs e) {
            MainFrame.Navigate(new ListAllPerson(Bussiness.Entities.PersonTypes.Student));
        }

        private void InscriptionMenu_Click(object sender, RoutedEventArgs e) {
            MainFrame.Navigate(new CrudInscriptions());
        }

        private void TeacherCourseMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CrudTeacherCourses());
        }

        private void ReportsMenu_Checked(object sender, RoutedEventArgs e) {
            Report reports = new Report();
            reports.Show();
        }

        private void QualificationsMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CrudQualifications());
        }

        private void AttendingList_Click(object sender, RoutedEventArgs e) {
            // System.Windows.Forms.Application.EnableVisualStyles();
            // System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            // System.Windows.Forms.Application.Run(new AttendingReport(42701, 6));
            MainFrame.Navigate(new ReportAttendingList());
        }

        private void StudentAverage_Click(object sender, RoutedEventArgs e) {
            // System.Windows.Forms.Application.EnableVisualStyles();
            // System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            // System.Windows.Forms.Application.Run(new StudentAverageReport(42703));
            MainFrame.Navigate(new ReportStudentAverage());
        }

        private void BestStudents_Click(object sender, RoutedEventArgs e) {
            // System.Windows.Forms.Application.EnableVisualStyles();
            // System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            // System.Windows.Forms.Application.Run(new BestStudentByYearReport(2017));
            MainFrame.Navigate(new ReportBestStudents());
        }

        private void ReportsMenu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
