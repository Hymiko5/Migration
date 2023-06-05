using Microsoft.Data.SqlClient;
using System.Data;

namespace Migration.Context
{
    public class UserManagementContext
    {
        private readonly string _connectionString;
        private readonly string _masterConnectionString;
        public UserManagementContext()
        {
            _connectionString = "Data Source=DESKTOP-2HDJBB3;Initial Catalog=UserManagement;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
            _masterConnectionString = "Data Source=DESKTOP-2HDJBB3;Initial Catalog=master;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
        public IDbConnection CreateMasterConnection()
        => new SqlConnection(_masterConnectionString);
    }
}
