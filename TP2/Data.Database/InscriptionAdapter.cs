using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.Entities;
using Util;

namespace Data.Database {
    public class InscriptionAdapter : Adapter{

        public void Delete(Inscription inscription) {
            string query = "delete from inscriptions where id=@ID;";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", inscription.Id);
            ExecuteCommandNonQuery(command);
        }

        public List<Inscription> GetAll() {
            return GetAll<Inscription>("inscriptions");
        }

        public void Create(Inscription inscription) {
            string query = "INSERT INTO inscriptions (student, course) values(@STUDENT, @COURSE); ";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@STUDENT", inscription.Student);
            command.Parameters.AddWithValue("@COURSE", inscription.Course);
            ExecuteCommandNonQuery(command);
        }

        public List<Inscription> GetAll(Person person) {
            string query = "SELECT * FROM inscriptions where student = @ID";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", person.FileNumber);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Inscription> inscriptions = Util.Util.DataReaderMapToList<Inscription>(results);
            if (inscriptions.Count == 0) {
                throw new NotFound();
            }
            return inscriptions;
        }

        public Inscription GetById(Inscription inscription) {
            string query = "SELECT * FROM inscriptions where id = @ID";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", inscription.Id);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Inscription> inscriptions = Util.Util.DataReaderMapToList<Inscription>(results);
            if (inscriptions.Count == 0) {
                throw new NotFound();
            }
            return inscriptions.First();
        }

        public void UpdateQualification(Inscription inscription) {
            string query = "update inscriptions set qualification=@QUALIFICATION, condition=@CONDITION where student=@STUDENT and course=@COURSE;";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@STUDENT", inscription.Student);
            command.Parameters.AddWithValue("@QUALIFICATION", inscription.Qualification);
            command.Parameters.AddWithValue("@CONDITION", inscription.Condition);
            command.Parameters.AddWithValue("@COURSE", inscription.Course);
            ExecuteCommandNonQuery(command);
        }

        public List<Inscription> GetAllByCourse(Course course)
        {
            string query = "SELECT * FROM inscriptions where course = @ID";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", course.Id);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Inscription> inscriptions = Util.Util.DataReaderMapToList<Inscription>(results);
            if (inscriptions.Count == 0) {
                throw new NotFound();
            }
            return inscriptions;
        }
    }
}
