using Bussiness.Entities;
using Data.Database;
using System.Collections.Generic;
using Util;

namespace Bussiness.Logic {

    public class PersonLogic : BusinessLogic {
        private readonly PersonAdapter _personData = new PersonAdapter();

        private readonly PlanAdapter _planData = new PlanAdapter();

        public Person Read(Person person) {
            return _personData.GetByFileNumber(person);
        }

        public Person CheckEmail(Person person) {
            return _personData.GetByEmail(person);
        }

        public void Modify(Person person) {
            CheckEmail(person);
            _personData.Update(person);
        }

        public Person GetByUser(User user) {
            return _personData.GetByFileNumber(new Person{ FileNumber = user.Person});
        }

        public void Delete(Person person) {
            CheckFileNumber(person);
            _personData.Delete(person);
        }

        public List<Person> GetAll(PersonTypes personType) {
            return _personData.GetAll(personType);
        }

        public List<Person> GetAll() {
            return _personData.GetAll();
        }

        public void Create(Person person) {
            try {
                Person dbPerson = CheckEmail(person);
            } catch (NotFound) {
                _personData.Create(person);
            }
        }

        public void CheckFileNumber(Person person) {
            Read(person);
        }

        public Plan GetPlan(Person person) {
            return _planData.GetById(new Plan { Id = (int)person.Planid });
        }
    }
}
