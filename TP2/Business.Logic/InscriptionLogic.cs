using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.Entities;
using Data.Database;
using Util;

namespace Bussiness.Logic {
    public class InscriptionLogic
    {
        private readonly InscriptionAdapter _inscriptionData = new InscriptionAdapter();

        public Inscription Read(Inscription inscription)
        {
            return _inscriptionData.GetById(inscription);
        }

        public void Delete(Inscription inscription)
        {
            Inscription dbInscription = Read(inscription);
            _inscriptionData.Delete(dbInscription);
        }

        public List<Inscription> GetAll()
        {
            return _inscriptionData.GetAll();
        }

        public void Create(Inscription inscription)
        {
            try
            {
                Inscription dbInscription = Read(inscription);
            }
            catch (NotFound)
            {
                _inscriptionData.Create(inscription);
            }
        }

        public List<Inscription> GetAll(Person person)
        {
            return _inscriptionData.GetAll(person);
        }

        public void UpdateQualification(Inscription inscription)
        {
            _inscriptionData.UpdateQualification(inscription);
        }

        public List<Inscription> GetAllByCourse(Course course) {
            return _inscriptionData.GetAllByCourse(course);
        }
    }
}
