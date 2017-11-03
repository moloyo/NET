using Bussiness.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Util;

namespace Data.Database {
    public class PlanAdapter : Adapter {

        public void Update(Plan plan) {
            string query = "update plans set description=@DESCRIPTION, specialty=@SPECIALTYID where id=@ID;";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@DESCRIPTION", plan.Description);
            command.Parameters.AddWithValue("@SPECIALTYID", plan.Specialty);
            command.Parameters.AddWithValue("@ID", plan.Id);
            ExecuteCommandNonQuery(command);
        }

        public void Delete(Plan plan) {
            string query = "delete from plans where id=@ID;";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", plan.Id);
            ExecuteCommandNonQuery(command);
        }

        public List<Plan> GetAll() {
            return GetAll<Plan>("plans");
        }

        public Plan GetById(Plan plan) {
            string query = "SELECT * FROM plans where id = @ID";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", plan.Id);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Plan> plans = Util.Util.DataReaderMapToList<Plan>(results);
            if (plans.Count == 0) {
                throw new NotFound();
            }
            return plans.First();
        }

        public void Create(Plan plan) {
            string query = "INSERT INTO plans (description, specialty) values(@DESCRIPTION, @SPECIALTYID);";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@DESCRIPTION", plan.Description);
            command.Parameters.AddWithValue("@SPECIALTYID", plan.Specialty);
            ExecuteCommandNonQuery(command);
        }

        public List<Plan> GetAllBySubject(Specialty specialty) {
            string query = "SELECT * FROM plans where specialty = @IDSPECIALTY";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@IDSPECIALTY", specialty.Id);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Plan> plans = Util.Util.DataReaderMapToList<Plan>(results);
            if (plans.Count == 0) {
                throw new NotFound();
            }
            return plans;
        }
        public List<Plan> GetAllBySpecialtyAndTeacher(Person teacher, Specialty specialty) {
            string query = @"SELECT distinct p.id, p.description 
                            FROM plans p
                            inner join subjects su
                                on su.planid = p.id
                            inner join courses cs
                                on cs.subject = su.id
                            inner join teachercourses tcs
	                            on tcs.course = cs.id
                            where tcs.teacher = @TEACHER
	                            and p.specialty=@IDSPECIALTY;";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@TEACHER", teacher.FileNumber);
            command.Parameters.AddWithValue("@IDSPECIALTY", specialty.Id);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Plan> plans = Util.Util.DataReaderMapToList<Plan>(results);
            if (plans.Count == 0) {
                throw new NotFound();
            }
            return plans;
        }
    }
}
