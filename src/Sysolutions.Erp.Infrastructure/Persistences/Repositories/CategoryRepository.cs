using Dapper;
using Sysolutions.Erp.Domain.Entities;
using Sysolutions.Erp.Infrastructure.Persistences.Contexts;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Infrastructure.Persistences.Repositories
{
    public class CategoryRepository : iCategoryRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public CategoryRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "CategoryGetAll";
                    var parameters = new DynamicParameters();

                    var response = await connection.QueryAsync<Category>(query, param: parameters, commandType: CommandType.StoredProcedure);
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
