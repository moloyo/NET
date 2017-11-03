using Bussiness.Entities;
using Data.Database;
using System.Collections.Generic;

namespace Bussiness.Logic {
    public class SubjectLogic : BusinessLogic
    {
        private readonly SubjectAdapter _subjectData = new SubjectAdapter();

        private readonly PlanAdapter _planData = new PlanAdapter();

        public Subject Read(Subject subject)
        {
            return _subjectData.GetById(subject);
        }

        private Subject CheckSubject(Subject subject)
        {
            return Read(subject);
        }

        public void Modify(Subject subject)
        {
            CheckSubject(subject);
            _subjectData.Update(subject);
        }

        public void Delete(Subject subject)
        {
            Subject dbSubject = CheckSubject(subject);
            _subjectData.Delete(dbSubject);
        }

        public List<Subject> GetAll()
        {
            return _subjectData.GetAll();
        }

        public List<Subject> GetAllByStudent(Person person)
        {
            return _subjectData.GetAllByStudent(person);
        }

        public void Create(Subject subject)
        {
            _subjectData.Create(subject);
        }

        public Plan GetPlan(Subject subject)
        {
            return _planData.GetById(new Plan {Id = subject.Planid});
        }

        public List<Subject> GetAllByPlan(Plan plan)
        {
            return _subjectData.GetAllByPlan(plan);
        }

        public List<Subject> GetAllByTeacher(Person person)
        {
            return _subjectData.GetAllByTeacher(person);
        }

        public List<Subject> GetAllByTeacherAndPlan(Person teacher, Plan plan)
        {
            return _subjectData.GetAllByTeacherAndPlan(teacher, plan);
        }
    }
}
