using Bussiness.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Util;

namespace Data.Database {

    public class PersonAdapter : Adapter {

        public void Update(Person person) {
            string query = "update persons set lastname=@LASTNAME, name=@NAME, email=@EMAIL, address=@ADDRESS, " +
                "birthdate=@BIRTHDATE, phonenumber=@PHONENUMBER, typeperson=@TYPEPERSON, planid=@PLANID " +
                "where filenumber=@FILENUMBER;";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@NAME", person.Name);
            command.Parameters.AddWithValue("@LASTNAME", person.LastName);
            command.Parameters.AddWithValue("@ADDRESS", person.Address);
            command.Parameters.AddWithValue("@EMAIL", person.Email);
            command.Parameters.AddWithValue("@BIRTHDATE", person.BirthDate);
            command.Parameters.AddWithValue("@PHONENUMBER", person.PhoneNumber);
            command.Parameters.AddWithValue("@FILENUMBER", person.FileNumber);
            command.Parameters.AddWithValue("@TYPEPERSON", (int)person.TypePerson);
            command.Parameters.AddWithValue("@PLANID", person.Planid ?? (object)DBNull.Value);
            ExecuteCommandNonQuery(command);
        }

        public Person GetByUser(User user) {
            string query = "SELECT * " + 
                            "FROM persons p " +
                            "inner join users us " +
                            "   on us.person=p.filename" +
                            "where us.id=@ID";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", user.Id);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Person> persons = Util.Util.DataReaderMapToList<Person>(results);
            if (persons.Count == 0) {
                throw new NotFound();
            }
            return persons.First();
        }

        public List<Person> GetAll(PersonTypes personType) {
            string query = "SELECT * FROM persons where typeperson=@PERSONTYPE";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@PERSONTYPE", (int)personType);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Person> persons = Util.Util.DataReaderMapToList<Person>(results);
            if (persons.Count == 0) {
                throw new NotFound();
            }
            return persons;
        }

        public Person GetByFileNumber(Person person) {
            string query = "SELECT * FROM persons where filenumber=@FILENUMBER";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@FILENUMBER", person.FileNumber);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Person> persons = Util.Util.DataReaderMapToList<Person>(results);
            if (persons.Count == 0) {
                throw new NotFound();
            }
            return persons.First();
        }

        public void Delete(Person person) {
            string query = "delete from persons where filenumber=@FILENUMBER;";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@FILENUMBER", person.FileNumber);
            ExecuteCommandNonQuery(command);
        }

        public List<Person> GetAll() {
            return GetAll<Person>("persons");
        }

        public void Create(Person person) {
            string query = "INSERT INTO persons (name, lastname, address, email, birthdate, phonenumber, filenumber, typeperson, planid)" +
                "values(@NAME, @LASTNAME, @ADDRESS, @EMAIL, @BIRTHDATE, @PHONENUMBER, @FILENUMBER, @TYPEPERSON, @PLANID); ";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@NAME", person.Name);
            command.Parameters.AddWithValue("@LASTNAME", person.LastName);
            command.Parameters.AddWithValue("@ADDRESS", person.Address);
            command.Parameters.AddWithValue("@EMAIL", person.Email);
            command.Parameters.AddWithValue("@BIRTHDATE", person.BirthDate);
            command.Parameters.AddWithValue("@PHONENUMBER", person.PhoneNumber);
            command.Parameters.AddWithValue("@FILENUMBER", person.FileNumber);
            command.Parameters.AddWithValue("@TYPEPERSON", (int)person.TypePerson);
            command.Parameters.AddWithValue("@PLANID", person.Planid ?? (object)DBNull.Value);
            ExecuteCommandNonQuery(command);
        }

        public Person GetByEmail(Person person) {
            string query = "SELECT * FROM persons where email = @EMAIL";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@EMAIL", person.Email);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Person> persons = Util.Util.DataReaderMapToList<Person>(results);
            if (persons.Count == 0) {
                throw new NotFound();
            }
            return persons.First();
        }

    }
}
