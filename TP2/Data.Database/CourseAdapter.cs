using Bussiness.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Util;

namespace Data.Database {
    public class CourseAdapter : Adapter {

        public void Update(Course course) {
            string query = "update courses set quota=@QUOTA, yearcourse=@YEAR, subject=@SUBJECT, commission=@COMMISSION where id=@ID;";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@QUOTA", course.Quota);
            command.Parameters.AddWithValue("@YEAR", course.YearCourse);
            command.Parameters.AddWithValue("@SUBJECT", course.Subject);
            command.Parameters.AddWithValue("@COMMISSION", course.Commission);
            command.Parameters.AddWithValue("@ID", course.Id);
            ExecuteCommandNonQuery(command);
        }

        public void Delete(Course course) {
            string query = "delete from courses where id=@ID;";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", course.Id);
            ExecuteCommandNonQuery(command);
        }

        public List<Course> GetAll() {
            return GetAll<Course>("courses");
        }

        public Course GetById(Course course) {
            string query = "SELECT * FROM courses where id = @ID";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", course.Id);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Course> courses = Util.Util.DataReaderMapToList<Course>(results);
            if (courses.Count == 0) {
                throw new NotFound();
            }
            return courses.First();
        }

        public List<Course> GetAllFreeBySubject(Subject subject) {
            string query = @"EXEC CoursesList @p1 = @ID;";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", subject.Id);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Course> courses = Util.Util.DataReaderMapToList<Course>(results);
            if (courses.Count == 0) {
                throw new NotFound();
            }
            return courses;
        }

        public void Create(Course course) {
            string query = "INSERT INTO courses (quota, yearcourse, subject, commission) values(@QUOTA, @YEAR, @SUBJECT, @COMMISSION);";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@QUOTA", course.Quota);
            command.Parameters.AddWithValue("@YEAR", course.YearCourse);
            command.Parameters.AddWithValue("@SUBJECT", course.Subject);
            command.Parameters.AddWithValue("@COMMISSION", course.Commission);
            ExecuteCommandNonQuery(command);
        }

        public List<Course> GetAllBySubjectByTeacher(Subject subject, Person teacher) {
            string query = @"EXEC TeacherCoursesList @p1 = @IDSUBJECT, @p2=@IDTEACHER;";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@IDSUBJECT", subject.Id);
            command.Parameters.AddWithValue("@IDTEACHER", teacher.FileNumber);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Course> courses = Util.Util.DataReaderMapToList<Course>(results);
            if (courses.Count == 0) {
                throw new NotFound();
            }
            return courses;
        }

        public List<Course> GetActualBySubjectByTeacher(Subject subject, Person teacher) {
            string query = @"SELECT cs.id, com.description, cs.commission
                            FROM courses cs
                            inner join commissions com
	                            on com.id = cs.commission
                            inner join teachercourses tcs
	                            on tcs.course = cs.id
                            where tcs.teacher = @IDTEACHER
	                            and cs.subject = @IDSUBJECT;";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@IDSUBJECT", subject.Id);
            command.Parameters.AddWithValue("@IDTEACHER", teacher.FileNumber);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Course> courses = Util.Util.DataReaderMapToList<Course>(results);
            if (courses.Count == 0) {
                throw new NotFound();
            }
            return courses;
        }
    }
}
