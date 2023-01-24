using Sysolutions.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Infrastructure.Persistences.Interfaces
{
    public interface IMasterRepository
    {
        Task<IEnumerable<Master>> GetAllAsync();
    }
}
