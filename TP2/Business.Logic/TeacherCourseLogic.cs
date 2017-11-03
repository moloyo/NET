using Bussiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Util;

namespace Bussiness.Logic {
    public class TeacherCourseLogic {
        private readonly TeacherCourseAdapter _teacherCourseData = new TeacherCourseAdapter();

        public TeacherCourse Read(TeacherCourse teacherCourse) {
            return _teacherCourseData.GetById(teacherCourse);
        }

        public void Delete(TeacherCourse teacherCourse) {
            TeacherCourse dbTeacherCourse = Read(teacherCourse);
            _teacherCourseData.Delete(dbTeacherCourse);
        }

        public List<TeacherCourse> GetAll() {
            return _teacherCourseData.GetAll();
        }

        public void Create(TeacherCourse teacherCourse) {
            try {
                TeacherCourse dbTeacherCourse = Read(teacherCourse);
            } catch (NotFound) {
                _teacherCourseData.Create(teacherCourse);
            }
        }

        public List<TeacherCourse> GetAll(Person person) {
            return _teacherCourseData.GetAll(person);
        }
    }
}
