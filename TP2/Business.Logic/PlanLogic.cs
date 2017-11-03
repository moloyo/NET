using System.Collections;
using Bussiness.Entities;
using Data.Database;
using System.Collections.Generic;

namespace Bussiness.Logic {
    public class PlanLogic : BusinessLogic
    {
        private readonly PlanAdapter _planData = new PlanAdapter();
        private readonly SpecialtyAdapter _specialtyData = new SpecialtyAdapter();

        public Plan Read(Plan plan)
        {
            return _planData.GetById(plan);
        }

        public Specialty GetSpecialty(Plan plan)
        {
            return _specialtyData.GetById(new Specialty {Id = plan.Specialty});
        }

        private Plan CheckPlan(Plan plan)
        {
            return Read(plan);
        }

        public void Modify(Plan plan)
        {
            CheckPlan(plan);
            _planData.Update(plan);
        }

        public void Delete(Plan plan)
        {
            Plan dbPlan = CheckPlan(plan);
            _planData.Delete(dbPlan);
        }

        public List<Plan> GetAll()
        {
            return _planData.GetAll();
        }

        public void Create(Plan plan)
        {
            _planData.Create(plan);
        }

        public List<Plan> GetAllBySpecialty(Specialty specialty)
        {
            return _planData.GetAllBySubject(specialty);
        }

        public List<Plan> GetAllBySpecialtyAndTeacher(Person teacher, Specialty specialty)
        {
            return _planData.GetAllBySpecialtyAndTeacher(teacher, specialty);
        }
    }
}
