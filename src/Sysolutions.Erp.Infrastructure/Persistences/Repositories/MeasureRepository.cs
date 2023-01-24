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
    public class MeasureRepository : IMeasureRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public MeasureRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Measure>> GetAllAsync()
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "MeasureGetAll";
                    var parameters = new DynamicParameters();

                    var response = await connection.QueryAsync<Measure>(query, param: parameters, commandType: CommandType.StoredProcedure);
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
