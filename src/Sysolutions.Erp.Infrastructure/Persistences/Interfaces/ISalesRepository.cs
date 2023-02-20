using Sysolutions.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Infrastructure.Persistences.Interfaces
{
    public interface ISalesRepository
    {
        Task<BaseSalesOrder> GetAllAsync(SalesOrder request);
        Task<bool> InsertAsync(SalesOrder salesOrder);
    }
}
