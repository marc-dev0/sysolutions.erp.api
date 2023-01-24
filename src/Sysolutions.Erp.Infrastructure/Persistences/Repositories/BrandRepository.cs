using Dapper;
using Sysolutions.Erp.Domain.Entities;
using Sysolutions.Erp.Infrastructure.Persistences.Contexts;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Infrastructure.Persistences.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public BrandRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "BrandGetAll";
                    var parameters = new DynamicParameters();

                    var response = await connection.QueryAsync<Brand>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
