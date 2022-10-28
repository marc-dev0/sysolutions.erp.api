using System.Data;

namespace Sysolutions.Security.Infrastructure.Persistences.Contexts
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
