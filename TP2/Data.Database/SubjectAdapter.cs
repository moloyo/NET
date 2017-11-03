using Bussiness.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Util;

namespace Data.Database {

    public class SubjectAdapter : Adapter {

        public void Update(Subject subject) {
            string query = "update subjects set description=@DESCRIPTION,  weeklyhs=@WHS, totalhs=@THS, planid=@PLANID where id=@ID;";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@DESCRIPTION", subject.Description);
            command.Parameters.AddWithValue("@WHS", subject.WeeklyHs);
            command.Parameters.AddWithValue("@THS", subject.TotalHs);
            command.Parameters.AddWithValue("@PLANID", subject.Planid);
            command.Parameters.AddWithValue("@ID", subject.Id);
            ExecuteCommandNonQuery(command);
        }

        public void Delete(Subject subject) {
            string query = "delete from subjects where id=@ID;";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", subject.Id);
            ExecuteCommandNonQuery(command);
        }

        public List<Subject> GetAllByStudent(Person person) {
            string query = "SubjectsList2";
            SqlCommand command = new SqlCommand(query);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@p1", person.FileNumber);
            command.Parameters.AddWithValue("@p2", person.Planid);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Subject> subjects = Util.Util.DataReaderMapToList<Subject>(results);
            if (subjects.Count == 0) {
                throw new NotFound();
            }
            return subjects;
        }

        public List<Subject> GetAll() {
            return GetAll<Subject>("subjects");
        }

        public Subject GetById(Subject subject) {
            string query = "SELECT * FROM subjects where id = @ID";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", subject.Id);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Subject> subjects = Util.Util.DataReaderMapToList<Subject>(results);
            if (subjects.Count == 0) {
                throw new NotFound();
            }
            return subjects.First();
        }

        public void Create(Subject subject) {
            string query = "INSERT INTO subjects (description, weeklyhs, totalhs, planid) values(@DESCRIPTION, @WHS, @THS, @PLANID);";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@DESCRIPTION", subject.Description);
            command.Parameters.AddWithValue("@WHS", subject.WeeklyHs);
            command.Parameters.AddWithValue("@THS", subject.TotalHs);
            command.Parameters.AddWithValue("@PLANID", subject.Planid);
            ExecuteCommandNonQuery(command);
        }

        public List<Subject> GetAllByPlan(Plan plan) {
            string query = "SELECT * FROM subjects where planid = @PLANID";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@PLANID", plan.Id);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Subject> subjects = Util.Util.DataReaderMapToList<Subject>(results);
            if (subjects.Count == 0) {
                throw new NotFound();
            }
            return subjects;
        }

        public List<Subject> GetAllByTeacher(Person person) {
            string query = "EXEC TeacherSubjectList @p1=@ID";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", person.FileNumber);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Subject> subjects = Util.Util.DataReaderMapToList<Subject>(results);
            if (subjects.Count == 0) {
                throw new NotFound();
            }
            return subjects;
        }

        public List<Subject> GetAllByTeacherAndPlan(Person teacher, Plan plan) {
            string query = @"SELECT distinct su.id, su.description 
                            FROM subjects su
                            inner join courses cs
                                on cs.subject = su.id
                            inner join teachercourses tcs
	                            on tcs.course = cs.id
                            where tcs.teacher = @ID
	                            and su.planid = @PLAN;";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", teacher.FileNumber);
            command.Parameters.AddWithValue("@PLAN", plan.Id);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Subject> subjects = Util.Util.DataReaderMapToList<Subject>(results);
            if (subjects.Count == 0) {
                throw new NotFound();
            }
            return subjects;
        }

    }
}
