using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Util;

namespace Data.Database {
    public class Adapter {

        private SqlConnection _conn = null;

        public SqlConnection Coon {
            get {
                if (_conn == null || _conn.State == ConnectionState.Closed) {
                    _conn = new SqlConnection {ConnectionString = ProjectConfiguration.GetConnectionString()};
                }
                return _conn;
            }
        }

        protected DataTable ExecuteCommand(SqlCommand command) {
            command.Connection = Coon;
            DataTable dataResults = new DataTable();

            command.Connection.Open();

            try {
                dataResults.Load(command.ExecuteReader());
            } finally {
                command.Connection.Dispose();
            }

            return dataResults;
        }

        protected void ExecuteCommandNonQuery(SqlCommand command) {
            command.Connection = Coon;

            command.Connection.Open();
            command.Transaction = command.Connection.BeginTransaction();

            try {
                var a = command.ExecuteNonQuery();
                command.Transaction.Commit();
            } catch (Exception e) {
                command.Transaction.Rollback();
                throw e;
            } finally {
                command.Connection.Dispose();
            }
        }

        public int ExecuteCommandScalar(SqlCommand command) {
            command.Connection = Coon;

            command.Connection.Open();
            command.Transaction = command.Connection.BeginTransaction();

            int result;

            try {
                result = int.Parse(command.ExecuteScalar().ToString());
                command.Transaction.Commit();
            } catch (Exception e) {
                command.Transaction.Rollback();
                throw e;
            } finally {
                command.Connection.Dispose();
            }
            return result;

        }

        protected List<T> GetAll<T>(String table) {
            SqlCommand command = new SqlCommand("SELECT * FROM " + table);
            List<T> li = Util.Util.DataReaderMapToList<T>(ExecuteCommand(command).CreateDataReader());
            if (li.Count == 0) {
                throw new NotFound();
            }
            return li;
        }
    }
}
