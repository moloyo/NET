using Bussiness.Entities;
using Data.Database;
using System.Collections.Generic;

namespace Bussiness.Logic {
    public class SpecialtyLogic : BusinessLogic
    {

        private readonly SpecialtyAdapter _specialtyData = new SpecialtyAdapter();

        public Specialty Read(Specialty specialty)
        {
            return _specialtyData.GetById(specialty);
        }

        private Specialty CheckSpecialtyname(Specialty specialty)
        {
            return Read(specialty);
        }

        public void Modify(Specialty specialty)
        {
            CheckSpecialtyname(specialty);
            _specialtyData.Update(specialty);
        }

        public void Delete(Specialty specialty)
        {
            Specialty dbSpecialty = CheckSpecialtyname(specialty);
            _specialtyData.Delete(dbSpecialty);
        }

        public List<Specialty> GetAll()
        {
            return _specialtyData.GetAll();
        }

        public void Create(Specialty specialty)
        {
            _specialtyData.Create(specialty);
        }

        public Specialty GetByPlan(Plan plan)
        {
            return _specialtyData.GetByPlan(plan);
        }

        public List<Specialty> GetByTeacher(Person teacher)
        {
            return _specialtyData.GetByTeacher(teacher);
        }
    }
}
