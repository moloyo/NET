using Bussiness.Entities;

namespace Bussiness.Logic {
    public class Application {
        private static Application _instancia;

        private readonly PersonLogic _ctrlPerson = new PersonLogic();

        private User _activeUser = null;
        private Person _activePerson = null;

        public User GetActiveUser() {
            return _activeUser;
        }

        public void SetActiveUser(User activeUser) {
            _activeUser = activeUser;
            _activePerson = _ctrlPerson.GetByUser(_activeUser);
        }

        public void LogOutUser() {
            IsLoggedIn();
            _activeUser = null;
        }

        public bool IsLoggedIn() {
            return _activeUser == null;
        }

        private Application() { }

        public static Application GetInstancia() {
            return Application._instancia ?? (Application._instancia = new Application());
        }

        public Person GetActivePerson() {
            return _activePerson;
        }
    }
}
