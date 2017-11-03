using Bussiness.Entities;
using Bussiness.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Util;

namespace UI.WPF {
    /// <summary>
    /// Interaction logic for ListAllPerson.xaml
    /// </summary>
    public partial class ListAllPerson : Page {

        private readonly PersonLogic _ctrlPerson = new PersonLogic();

        public ListAllPerson(PersonTypes personType) {
            try {
                InitializeComponent();
                List<Person> li = _ctrlPerson.GetAll(personType);
                AllPersonList.ItemsSource = li;
                Util.Util.AddGridViewColumns(li.First(), AllPersonGridView);
            } catch (NotFound) {
                ModalError errorModal = new ModalError("There are no persons");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }
    }
}
