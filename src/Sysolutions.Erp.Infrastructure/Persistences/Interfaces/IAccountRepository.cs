using Sysolutions.Erp.Domain.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Infrastructure.Persistences.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetAsync(string client);
        Task<IEnumerable<Account>> GetAllAsync(string client);
        Task<bool> InsertAsync(Account account);
    }
}