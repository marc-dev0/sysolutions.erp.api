using System.Collections.Generic;

namespace Sysolutions.Erp.Domain.Entities
{
    public class BaseSalesOrder
    {
        public IEnumerable<SalesOrder> SalesOrder { get; set; }
    }
}
