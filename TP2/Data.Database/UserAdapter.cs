using System.Collections.Generic;
using Bussiness.Entities;
using System.Data.SqlClient;
using System.Data;
using Util;
using System.Linq;

namespace Data.Database {

    public class UserAdapter : Adapter {

        public void Update(User user) {
            string query = "update users set lastname=@LASTNAME, name=@NAME, email=@EMAIL where username=@USERNAME;";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@NAME", user.Name);
            command.Parameters.AddWithValue("@LASTNAME", user.LastName);
            command.Parameters.AddWithValue("@EMAIL", user.EMail);
            command.Parameters.AddWithValue("@USERNAME", user.Username);
            ExecuteCommandNonQuery(command);
        }

        public void Delete(User user) {
            string query = "delete from users where username=@ID;";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@USERNAME", user.Username);
            ExecuteCommandNonQuery(command);
        }

        public List<User> GetAll() {
            return GetAll<User>("users");
        }

        public User GetByUsername(User user) {
            string query = @"
                    SELECT TOP 1 * 
                    FROM users us
                    left join _permissions ps
                        on us.permission = ps.idp 
                    where username = @USERNAME
                    ";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@USERNAME", user.Username);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<User> users = Util.Util.DataReaderMapToList<User>(results);
            if (users.Count == 0) {
                throw new NotFound();
            }
            return users.First();
        }

        public void CheckUsername(User user) {
            string query = @"
                    SELECT Count(*) 
                    FROM users us
                    left join _permissions ps
                        on us.permission = ps.idp 
                    where username = @USERNAME
                    ";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@USERNAME", user.Username);
            int results = ExecuteCommandScalar(command);
            if (results == 0) {
                throw new NotFound();
            }
        }


        public void Create(User user) {
            string query = "INSERT INTO users (username, password, person) " +
                "values(@USERNAME, @PASSWORD, @PERSON); ";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@USERNAME", user.Username);
            command.Parameters.AddWithValue("@PASSWORD", user.Password);
            command.Parameters.AddWithValue("@PERSON", user.Person);
            ExecuteCommandNonQuery(command);
        }

        public User GetByEmail(User user) {
            string query = "SELECT TOP 1 * FROM users where email = @EMAIL";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@EMAIL", user.EMail);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<User> users = Util.Util.DataReaderMapToList<User>(results);
            if (users.Count == 0) {
                throw new NotFound();
            }
            return users.First();
        }
    }
}
