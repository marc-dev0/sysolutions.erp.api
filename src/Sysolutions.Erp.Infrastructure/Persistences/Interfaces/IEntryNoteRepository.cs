using Sysolutions.Erp.Domain.Entities;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Infrastructure.Persistences.Interfaces
{
    public interface IEntryNoteRepository
    {
        Task<bool> InsertAsync(EntryNote request);
    }
}
