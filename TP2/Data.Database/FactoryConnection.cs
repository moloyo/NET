using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    class FactoryConnection
    {
        private static FactoryConnection instance = null;
        private FactoryConnection(){}

        public static FactoryConnection getInstance(){
            if (FactoryConnection.instance == null){
                FactoryConnection.instance = new FactoryConnection();
            }
            return FactoryConnection.instance;
        }

        private SqlConnection conn = null;
        public SqlConnection getConn(){
            if (conn == null || conn.State == ConnectionState.Closed){
                conn = new SqlConnection();
                conn.ConnectionString = ProjectConfiguration.getConnectionString();
            }
            return conn;
        }
    }
}
