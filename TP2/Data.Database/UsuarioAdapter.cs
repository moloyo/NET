using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
//using Business.Entities;

namespace Data.Database
{
    public class UserAdapter:Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<User> _Users;

        private static List<User> Users
        {
            get
            {
                if (_Users == null)
                {
                    _Users = new List<User>();
                    Business.Entities.User usr;
                    usr = new Business.Entities.User();
                    usr.ID = 1;
                    usr.State = BusinessEntity.States.Unmodified;
                    usr.Name = "Casimiro";
                    usr.LastName = "Cegado";
                    usr.UserName = "casicegado";
                    usr.Password = "miro";
                    usr.EMail = "casimirocegado@gmail.com";
                    usr.Enable = true;
                    _Users.Add(usr);

                    usr = new Business.Entities.User();
                    usr.ID = 2;
                    usr.State = BusinessEntity.States.Unmodified;
                    usr.Name = "Armando Esteban";
                    usr.LastName = "Quito";
                    usr.UserName = "aequito";
                    usr.Password = "carpintero";
                    usr.EMail = "armandoquito@gmail.com";
                    usr.Enable = true;
                    _Users.Add(usr);

                    usr = new Business.Entities.User();
                    usr.ID = 3;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Name = "Alan";
                    usr.LastName = "Brado";
                    usr.UserName = "alanbrado";
                    usr.Password = "abrete sesamo";
                    usr.EMail = "alanbrado@gmail.com";
                    usr.Enable = true;
                    _Users.Add(usr);

                }
                return _Users;
            }
        }
        #endregion

        public List<User> GetAll()
        {
            return new List<User>(Users);
        }

        public Business.Entities.User GetOne(int ID)
        {
            return Users.Find(delegate(User u) { return u.ID == ID; });
        }

        public void Delete(int ID)
        {
            Users.Remove(this.GetOne(ID));
        }

        public void Save(User User)
        {
            if (User.State == BusinessEntity.States.New)
            {
                int NextID = 0;
                foreach (User usr in Users)
                {
                    if (usr.ID > NextID)
                    {
                        NextID = usr.ID;
                    }
                }
                User.ID = NextID + 1;
                Users.Add(User);
            }
            else if (User.State == BusinessEntity.States.Deleted)
            {
                this.Delete(User.ID);
            }
            else if (User.State == BusinessEntity.States.Modified)
            {
                Users[Users.FindIndex(delegate(User u) { return u.ID == User.ID; })]=User;
            }
            User.State = BusinessEntity.States.Unmodified;            
        }
    }
}
