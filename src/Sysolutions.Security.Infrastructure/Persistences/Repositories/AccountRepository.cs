using Sysolutions.Security.Domain.Entities;
using Sysolutions.Security.Infrastructure.Persistences.Contexts;
using Sysolutions.Security.Infrastructure.Persistences.Interfaces;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Sysolutions.Security.Infrastructure.Persistences.Repositories
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
                var query = "AccountsGetByClient";
                var parameters = new DynamicParameters();
                parameters.Add("Client", client);

                var account = await connection.QuerySingleOrDefaultAsync<Account>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return account;
            }
        }

        public async Task<bool> InsertAsync(Account account)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "AccountsInsert";
                var parameters = new DynamicParameters();
                parameters.Add("AccountId", account.AccountId);
                parameters.Add("Company", account.Company);
                parameters.Add("Abbreviation", account.Abbreviation);
                parameters.Add("Client", account.Client);
                parameters.Add("Secret", account.Secret);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
    }
}
