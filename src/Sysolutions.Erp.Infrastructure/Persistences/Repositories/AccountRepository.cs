using Sysolutions.Erp.Domain.Entities;
using Sysolutions.Erp.Infrastructure.Persistences.Contexts;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Collections.Generic;

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
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "AccountInsert";
                var parameters = new DynamicParameters();
                parameters.Add("RegistrationAccountId", account.RegistrationAccountId);
                parameters.Add("Client", account.Client);
                parameters.Add("Secret", account.Secret);
                parameters.Add("FirstName", account.FirstName);
                parameters.Add("FirstName1", account.FirstName1);
                parameters.Add("LastName", account.LastName);
                parameters.Add("LastName1", account.LastName1);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
    }
}
