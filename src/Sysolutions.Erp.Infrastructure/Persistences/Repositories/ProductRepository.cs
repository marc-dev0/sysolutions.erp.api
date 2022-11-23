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
    internal class ProductRepository : IProductRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public ProductRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Task<bool> DeleteAsync(int productId, int modifiedAccountId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "ProductGetAll";
                    var parameters = new DynamicParameters();

                    var response = await connection.QueryAsync<Product>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Product> GetByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
