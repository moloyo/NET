using System;
using System.Collections.Generic;
using Data.Database;
using Bussiness.Entities;
using Util;

namespace Bussiness.Logic {
    public class UserLogic : BusinessLogic {
        private readonly UserAdapter _userData = new UserAdapter();

        public User Read(User user) {
            return _userData.GetByUsername(user);
        }

        public void CheckUsername(User user) {
            _userData.CheckUsername(user);
        }

        public User CheckEmail(User user) {
            return _userData.GetByEmail(user);
        }

        public void Modify(User user) {
            CheckUsername(user);
            _userData.Update(user);
        }

        public void Delete(User user) {
            CheckUsername(user);
            _userData.Delete(user);
        }

        public List<User> GetAll() {
            return _userData.GetAll();
        }

        public User LogIn(User user) {
            try {
                Util.Logs.Logger("Logeando desde utiles2");
                User dbUser = Read(user);
                if (!String.Equals(dbUser.Password, user.Password)) {
                    throw new LoginException("Incorrect Password");
                }
                Application.GetInstancia().SetActiveUser(dbUser);
                return dbUser;
            } catch (NotFound) {
                throw new LoginException("Incorrect Username");
            }
        }

        public void Create(User user) {
            try {
                CheckUsername(user);
            } catch (NotFound) {
                _userData.Create(user);
            }
        }
    }
}
