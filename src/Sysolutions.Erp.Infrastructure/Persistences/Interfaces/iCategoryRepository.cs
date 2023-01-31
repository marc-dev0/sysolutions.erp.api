using Sysolutions.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Infrastructure.Persistences.Interfaces
{
    public interface iCategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<bool> InsertAsync(Category request);
    }
}
