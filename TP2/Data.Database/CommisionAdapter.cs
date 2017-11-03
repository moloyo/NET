using Bussiness.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Util;

namespace Data.Database {

    public class CommissionAdapter : Adapter {

        public void Update(Commission commission) {
            string query = "update commissions set description=@DESCRIPTION,  yearspecialty=@YEAR, planid=@PLANID where id=@ID;";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@DESCRIPTION", commission.Description);
            command.Parameters.AddWithValue("@YEAR", commission.YearSpecialty);
            command.Parameters.AddWithValue("@PLANID", commission.Planid);
            command.Parameters.AddWithValue("@ID", commission.Id);
            ExecuteCommandNonQuery(command);
        }

        public void Delete(Commission commission) {
            string query = "delete from commissions where id=@ID;";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", commission.Id);
            ExecuteCommandNonQuery(command);
        }

        public List<Commission> GetAll() {
            return GetAll<Commission>("commissions");
        }

        public Commission GetById(Commission commission) {
            string query = "SELECT * FROM commissions where id = @ID";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", commission.Id);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Commission> commissions = Util.Util.DataReaderMapToList<Commission>(results);
            if (commissions.Count == 0) {
                throw new NotFound();
            }
            return commissions.First();
        }

        public void Create(Commission commission) {
            string query = "INSERT INTO commissions (description, yearspecialty, planid) values(@DESCRIPTION, @YEAR, @PLANID);";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@DESCRIPTION", commission.Description);
            command.Parameters.AddWithValue("@YEAR", commission.YearSpecialty);
            command.Parameters.AddWithValue("@PLANID", commission.Planid);
            ExecuteCommandNonQuery(command);
        }

        public List<Commission> GetAllBySubject(Subject subject) {
            string query = "SELECT * FROM commissions where planid = @ID";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", subject.Planid);
            IDataReader results = ExecuteCommand(command).CreateDataReader();
            List<Commission> commissions = Util.Util.DataReaderMapToList<Commission>(results);
            if (commissions.Count == 0) {
                throw new NotFound();
            }
            return commissions;
        }

        public IEnumerable<Commission> GetAllByPlan(Plan plan)
        {
            return GetAll().Where(c => c.Planid == plan.Id);
        }
    }
}
