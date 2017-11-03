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
    public class TeacherCourseAdapter : Adapter {
        public void Delete(TeacherCourse teacherCourse) {
            string query = "delete from teacherCourses where id=@ID;";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", teacherCourse.Id);
            ExecuteCommandNonQuery(command);
        }

        public List<TeacherCourse> GetAll() {
            return GetAll<TeacherCourse>("teacherCourses");
        }

        public void Create(TeacherCourse teacherCourse) {
            string query = @"insert into teachercourses (teacher, course, position)
                                values(@TEACHER, @COURSE, @POSITION);";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@TEACHER", teacherCourse.Teacher);
            command.Parameters.AddWithValue("@COURSE", teacherCourse.Course);
            command.Parameters.AddWithValue("@POSITION", (int)teacherCourse.Position);
            ExecuteCommandNonQuery(command);
        }

        public List<TeacherCourse> GetAll(Person person) {
            string query = "SELECT * FROM teacherCourses where student = @ID";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", person.FileNumber);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<TeacherCourse> teacherCourses = Util.Util.DataReaderMapToList<TeacherCourse>(results);
            if (teacherCourses.Count == 0) {
                throw new NotFound();
            }
            return teacherCourses;
        }

        public TeacherCourse GetById(TeacherCourse teacherCourse) {
            string query = "SELECT * FROM teacherCourses where id = @ID";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", teacherCourse.Id);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<TeacherCourse> teacherCourses = Util.Util.DataReaderMapToList<TeacherCourse>(results);
            if (teacherCourses.Count == 0) {
                throw new NotFound();
            }
            return teacherCourses.First();
        }
    }
}
