using System.Data;

namespace Sysolutions.Erp.Infrastructure.Persistences.Contexts
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
