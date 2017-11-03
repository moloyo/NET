using Bussiness.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Util;

namespace Data.Database {

    public class SpecialtyAdapter : Adapter {

        public void Update(Specialty specialty) {
            string query = "update specialties set description=@DESCRIPTION where id=@ID;";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@DESCRIPTION", specialty.Description);
            command.Parameters.AddWithValue("@ID", specialty.Id);
            ExecuteCommandNonQuery(command);
        }

        public void Delete(Specialty specialty) {
            string query = "delete from specialties where id=@ID;";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", specialty.Id);
            ExecuteCommandNonQuery(command);
        }

        public List<Specialty> GetAll() {
            return GetAll<Specialty>("specialties");
        }

        public Specialty GetById(Specialty specialty) {
            string query = "SELECT * FROM specialties where id = @ID";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", specialty.Id);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Specialty> specialtys = Util.Util.DataReaderMapToList<Specialty>(results);
            if (specialtys.Count == 0) {
                throw new NotFound();
            }
            return specialtys.First();
        }

        public void Create(Specialty specialty) {
            string query = "INSERT INTO specialties (description) values(@DESCRIPTION);";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@DESCRIPTION", specialty.Description);
            ExecuteCommandNonQuery(command);
        }

        public Specialty GetByPlan(Plan plan)
        {
            string query = "SELECT * FROM specialties where id = @ID";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", plan.Specialty);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Specialty> specialtys = Util.Util.DataReaderMapToList<Specialty>(results);
            if (specialtys.Count == 0) {
                throw new NotFound();
            }
            return specialtys.First();
        }

        public List<Specialty> GetByTeacher(Person teacher) {
            string query = @"SELECT distinct s.id, s.description 
                            FROM specialties s
                            inner join plans p
                                on s.id=p.specialty
                            inner join subjects su
                                on su.planid = p.id
                            inner join courses cs
                                on cs.subject = su.id
                            inner join teachercourses tcs
	                            on tcs.course = cs.id
                            where tcs.teacher = @ID;";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", teacher.FileNumber);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Specialty> specialtys = Util.Util.DataReaderMapToList<Specialty>(results);
            if (specialtys.Count == 0) {
                throw new NotFound();
            }
            return specialtys;
        }
    }
}
