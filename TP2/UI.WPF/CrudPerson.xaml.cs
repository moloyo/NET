using Bussiness.Entities;
using Bussiness.Logic;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Util;

namespace UI.WPF {

    public partial class CrudPerson : Page {
        private readonly PersonLogic _ctrlPerson = new PersonLogic();

        private readonly PlanLogic _ctrlPlan = new PlanLogic();

        private readonly SpecialtyLogic _ctrlSpecialties = new SpecialtyLogic();

        private PersonTypes PersonType { get; set; }

        public CrudPerson(PersonTypes typePerson) {
            InitializeComponent();
            PersonType = typePerson;
            if (PersonType == PersonTypes.Student) {
                StudentOnly.Visibility = Visibility.Visible;
                LoadSpecialties();
                DataContext = this;
            } else if (PersonType == PersonTypes.Teacher) {
            } else if (PersonType == PersonTypes.NonTeacher) {
            }
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

        private void MapToForm(Person person) {
            TxtName.Text = person.Name;
            TxtLastName.Text = person.LastName;
            TxtEmail.Text = person.Email;
            TxtAddress.Text = person.Address;
            TxtPhoneNumber.Text = person.PhoneNumber;
            TxtFileNumber.Text = person.FileNumber.ToString();
            DpBirthDate.SelectedDate = DateTime.Parse(person.BirthDate);
            person.TypePerson = (int)PersonType;

            if (PersonType == PersonTypes.Student) {
                try {
                    Plan plan = _ctrlPlan.Read(new Plan { Id = (int)person.Planid });
                    Specialty specialty = _ctrlSpecialties.GetByPlan(plan);
                    CboSpecialties.SelectedItem = CboSpecialties.Items.OfType<Specialty>()
                        .FirstOrDefault(item => item.Id == specialty.Id);
                    CboPlans.SelectedItem = CboPlans.Items.OfType<Plan>()
                        .FirstOrDefault(item => item.Id == plan.Id);
                } catch (Exception) {
                    ModalError errorWindow = new ModalError();
                }
            }
        }

        private Person MapFromForm() {
            Person person = new Person {
                Name = TxtName.Text,
                LastName = TxtLastName.Text,
                Email = TxtEmail.Text,
                Address = TxtAddress.Text,
                PhoneNumber = TxtPhoneNumber.Text,
                FileNumber = int.Parse(TxtFileNumber.Text),
                BirthDate = DpBirthDate.SelectedDate.Value.Date.ToShortDateString(),
                TypePerson = (int)PersonType
            };

            if (person.TypePerson == (int)PersonTypes.Student) {
                person.Planid = ((Plan)CboPlans.SelectedItem).Id;
            }
            return person;

        }

        private void Search_Click(object sender, RoutedEventArgs e) {
            try {
                Person person = new Person();
                person.FileNumber = int.Parse(TxtFileNumber.Text);
                person = _ctrlPerson.Read(person);
                if (person.TypePerson != (int)PersonType) {
                    ModalError errorWindow = new ModalError("Invalid File Number");
                    return;
                }
                MapToForm(person);
            } catch (NotFound userE) {
                ModalError errorWindow = new ModalError(userE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private void Modify_Click(object sender, RoutedEventArgs e) {
            try {
                Person person = MapFromForm();
                person.FileNumber = int.Parse(TxtFileNumber.Text);
                _ctrlPerson.Modify(person);
                Modal modal = new Modal("Person Updated");
            } catch (NotFound personE) {
                ModalError errorWindow = new ModalError(personE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private void Confirmation_Click(object sender, RoutedEventArgs e) {
            ModalConfirmation modalConfirmation =
                new ModalConfirmation("Are you sure you want to delete this person?", Delete_Click);
        }

        private void Delete_Click() {
            try {
                Person person = new Person();
                person.FileNumber = int.Parse(TxtFileNumber.Text);
                _ctrlPerson.Delete(person);
                Modal modal = new Modal("Person Deleted");
            } catch (NotFound personE) {
                ModalError errorWindow = new ModalError(personE.Message);
            } catch (Exception) {
                ModalError errorWindow = new ModalError();
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e) {
            if (DpBirthDate.SelectedDate == null || string.IsNullOrEmpty(TxtEmail.Text) ||
                string.IsNullOrEmpty(TxtFileNumber.Text) || string.IsNullOrEmpty(TxtName.Text) ||
                string.IsNullOrEmpty(TxtLastName.Text) || string.IsNullOrEmpty(TxtAddress.Text) ||
                string.IsNullOrEmpty(TxtPhoneNumber.Text)) {
                ModalError errorModal = new ModalError("You have to complete all fields");
                return;
            }

            if (Validators.isValidEmail(TxtEmail.Text)) {
                ModalError errorModal = new ModalError("Invalid email");
                return;
            }

            try {
                _ctrlPerson.CheckEmail(new Person { Email = TxtEmail.Text });
                ModalError errorModal = new ModalError("Email taken");
                return;
            } catch (NotFound) { } catch (Exception) {
                ModalError errorModal = new ModalError();
                return;
            }

            try {
                _ctrlPerson.CheckFileNumber(new Person { FileNumber = int.Parse(TxtFileNumber.Text) });
                ModalError errorModal = new ModalError("File Number used");
                return;
            } catch (NotFound) { } catch (Exception) {
                ModalError errorModal = new ModalError();
                return;
            }


            if (CboPlans.SelectedItem == null && PersonType == PersonTypes.Student) {
                ModalError errorModal = new ModalError("You have to provide a Plan");
                return;
            }

            try {
                Person person = MapFromForm();
                _ctrlPerson.Create(person);
                Modal modal = new Modal("Person Created");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }


    }
}
