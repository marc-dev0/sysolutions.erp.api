using Sysolutions.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Infrastructure.Persistences.Interfaces
{
    public interface IStorageRepository
    {
        Task<IEnumerable<Storage>> GetAllAsync();
        Task<bool> InsertAsync(Storage request);

        Task<IEnumerable<StorageProduct>> GetStorageProductByStorageIdAsync(int storageId, int categoryId, int subCategoryId, string description);
    }
}
