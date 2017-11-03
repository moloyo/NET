using Bussiness.Entities;
using Data.Database;
using System.Collections.Generic;
using System;

namespace Bussiness.Logic {
    public class CourseLogic : BusinessLogic
    {
        private readonly CourseAdapter _courseData = new CourseAdapter();

        private readonly CommissionAdapter _commissionData = new CommissionAdapter();
        private readonly SubjectAdapter _subjectData = new SubjectAdapter();

        public Course Read(Course course)
        {
            return _courseData.GetById(course);
        }

        private Course CheckCourse(Course course)
        {
            return Read(course);
        }

        public void Modify(Course course)
        {
            CheckCourse(course);
            _courseData.Update(course);
        }

        public void Delete(Course course)
        {
            Course dbCourse = CheckCourse(course);
            _courseData.Delete(dbCourse);
        }

        public List<Course> GetAll()
        {
            return _courseData.GetAll();
        }

        public void Create(Course course)
        {
            _courseData.Create(course);
        }

        public Commission GetCommission(Course course)
        {
            return _commissionData.GetById(new Commission {Id = course.Commission});
        }

        public Subject GetSubject(Course course)
        {
            return _subjectData.GetById(new Subject {Id = course.Subject});
        }

        public List<Course> GetAllFreeBySubject(Subject subject)
        {
            return _courseData.GetAllFreeBySubject(subject);
        }

        public List<Course> GetAllBySubjectByTeacher(Subject subject, Person teacher)
        {
            return _courseData.GetAllBySubjectByTeacher(subject, teacher);
        }

        public List<Course> GetActualBySubjectByTeacher(Subject subject, Person teacher)
        {
            return _courseData.GetActualBySubjectByTeacher(subject, teacher);
        }
    }
}
