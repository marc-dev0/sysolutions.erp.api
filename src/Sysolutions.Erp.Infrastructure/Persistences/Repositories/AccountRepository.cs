using Sysolutions.Erp.Domain.Entities;
using Sysolutions.Erp.Infrastructure.Persistences.Contexts;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Collections.Generic;
using System;

namespace Sysolutions.Erp.Infrastructure.Persistences.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public AccountRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Account> GetAsync(string client)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "AccountGetByClient";
                var parameters = new DynamicParameters();
                parameters.Add("Client", client);

                var account = await connection.QuerySingleOrDefaultAsync<Account>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return account;
            }
        }

        public async Task<Account> GetByIdAsync(int accountId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "AccountGetById";
                var parameters = new DynamicParameters();
                parameters.Add("AccountId", accountId);

                var account = await connection.QuerySingleOrDefaultAsync<Account>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return account;
            }
        }
        public async Task<IEnumerable<Account>> GetAllAsync(string client)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "AccountGetAll";
                var parameters = new DynamicParameters();
                parameters.Add("Client", client);

                var account = await connection.QueryAsync<Account>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return account;
            }
        }

        public async Task<bool> InsertAsync(Account account)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "AccountInsert";
                    var parameters = new DynamicParameters();
                    parameters.Add("RegistrationAccountId", account.RegistrationAccountId);
                    parameters.Add("Client", account.Client);
                    parameters.Add("Secret", account.Secret);
                    parameters.Add("FirstName", account.FirstName);
                    parameters.Add("LastName", account.LastName);
                    parameters.Add("Phone", account.Phone);
                    parameters.Add("Mail", account.Mail);
                    parameters.Add("IdentificationDocument", account.IdentificationDocument);
                    parameters.Add("State", account.State);
                    parameters.Add("ProfileId", account.ProfileId);

                    var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateAsync(Account account)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "AccountUpdate";
                    var parameters = new DynamicParameters();
                    parameters.Add("AccountId", account.AccountId);
                    parameters.Add("ModifiedAccountId", account.ModifiedAccountId);
                    parameters.Add("Client", account.Client);
                    parameters.Add("Secret", account.Secret);
                    parameters.Add("FirstName", account.FirstName);
                    parameters.Add("LastName", account.LastName);
                    parameters.Add("Phone", account.Phone);
                    parameters.Add("Mail", account.Mail);
                    parameters.Add("IdentificationDocument", account.IdentificationDocument);
                    parameters.Add("State", account.State);
                    parameters.Add("ProfileId", account.ProfileId);

                    var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(int accountId, int modifiedAccountId)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "AccountDelete";
                    var parameters = new DynamicParameters();
                    parameters.Add("AccountId", accountId);
                    parameters.Add("ModifiedAccountId", modifiedAccountId);
                    var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
