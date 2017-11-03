using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Bussiness.Entities;
using Bussiness.Logic;
using Util;

namespace UI.WPF {
    public partial class ListAll : Page {
        private readonly UserLogic _ctrlUser = new UserLogic();

        public ListAll() {
            try {
                InitializeComponent();
                List<User> li = _ctrlUser.GetAll();
                AllUserList.ItemsSource = li;
                Util.Util.AddGridViewColumns(li.First(), AllUserGridView);
            } catch (NotFound) {
                ModalError errorModal = new ModalError("There are no users");
            } catch (Exception) {
                ModalError errorModal = new ModalError();
            }
        }
    }
}