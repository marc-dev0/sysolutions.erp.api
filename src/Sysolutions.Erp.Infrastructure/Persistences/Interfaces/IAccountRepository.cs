using Sysolutions.Erp.Domain.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Infrastructure.Persistences.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetAsync(string client);
        Task<Account> GetByIdAsync(int accountId);
        Task<IEnumerable<Account>> GetAllAsync(string client);
        Task<bool> InsertAsync(Account account);
        Task<bool> UpdateAsync(Account account);
        Task<bool> DeleteAsync(int accountId, int modifiedAccountId);
    }
}