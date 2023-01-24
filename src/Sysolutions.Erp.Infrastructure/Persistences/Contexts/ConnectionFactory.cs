using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Sysolutions.Erp.Infrastructure.Persistences.Contexts
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection();
                if (sqlConnection == null) return null;

                try
                {
                    sqlConnection.ConnectionString = _configuration.GetConnectionString("CRMConnection");
                    if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                    return sqlConnection;
                }
                catch (System.Exception)
                {
                    if (sqlConnection != null) sqlConnection.Dispose();
                    throw;
                } 
                
            }
        }
    }
}
