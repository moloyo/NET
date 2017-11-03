using System.Configuration;

namespace Data.Database {
    class ProjectConfiguration {

        public static string GetConnectionString() {
            return ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }
    }
}
