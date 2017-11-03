using Bussiness.Entities;
using Data.Database;
using System.Collections.Generic;

namespace Bussiness.Logic {
    public class CommissionLogic : BusinessLogic {

        private readonly CommissionAdapter _commissionData = new CommissionAdapter();

        private readonly PlanAdapter _planData = new PlanAdapter();

        public Commission Read(Commission commission) {
            return _commissionData.GetById(commission);
        }

        private Commission CheckCommission(Commission commission) {
            return Read(commission);
        }

        public void Modify(Commission commission) {
            CheckCommission(commission);
            _commissionData.Update(commission);
        }

        public void Delete(Commission commission) {
            Commission dbCommission = CheckCommission(commission);
            _commissionData.Delete(dbCommission);
        }

        public List<Commission> GetAll() {
            return _commissionData.GetAll();
        }

        public void Create(Commission commission) {
            _commissionData.Create(commission);
        }

        public Plan GetPlan(Commission commission) {
            return _planData.GetById(new Plan { Id = commission.Planid });
        }

        public List<Commission> GetAllBySubject(Subject subject) {
            return _commissionData.GetAllBySubject(subject);
        }

        public IEnumerable<Commission> GetAllByPlan(Plan plan)
        {
            return _commissionData.GetAllByPlan(plan);
        }
    }
}
