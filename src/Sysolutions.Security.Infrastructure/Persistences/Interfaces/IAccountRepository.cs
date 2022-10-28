using Sysolutions.Security.Domain.Entities;
using System.Threading.Tasks;

namespace Sysolutions.Security.Infrastructure.Persistences.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetAsync(string client);
        Task<bool> InsertAsync(Account account);
    }
}