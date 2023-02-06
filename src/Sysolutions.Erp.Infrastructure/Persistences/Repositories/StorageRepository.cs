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
    public class StorageRepository : IStorageRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public StorageRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Storage>> GetAllAsync()
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "dbo.StorageGetAll";
                    var parameters = new DynamicParameters();

                    var response = await connection.QueryAsync<Storage>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> InsertAsync(Storage request)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "dbo.StorageInsert";
                    var parameters = new DynamicParameters();
                    parameters.Add("Description", request.Description);
                    parameters.Add("Location", request.Location);
                    parameters.Add("State", request.State);
                    parameters.Add("RegistrationAccountId", request.RegistrationAccountId);

                    var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<StorageProduct>> GetStorageProductByStorageIdAsync(int storageId, int categoryId, int subCategoryId, string description)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "dbo.StorageProductGetByStorageId";
                    var parameters = new DynamicParameters();
                    parameters.Add("StorageId", storageId);
                    parameters.Add("CategoryId", categoryId);
                    parameters.Add("SubCategoryId", subCategoryId);
                    parameters.Add("Description", description);

                    var response = await connection.QueryAsync<StorageProduct>(query, param: parameters, commandType: CommandType.StoredProcedure);
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
