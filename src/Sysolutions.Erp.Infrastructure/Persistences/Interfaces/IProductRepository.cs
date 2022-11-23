using Sysolutions.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Infrastructure.Persistences.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int productId);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<bool> InsertAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int productId, int modifiedAccountId);
    }
}
