using Sysolutions.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Infrastructure.Persistences.Interfaces
{
    public interface IProfileRepository
    {
        Task<IEnumerable<Profiles>> GetAllAsync();
    }
}
