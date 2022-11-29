
namespace Sysolutions.Erp.Domain.Entities
{
    public class SalesOrderDetail
    {
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int SalesOrderId { get; set; }
        public string Product { get; set; }
    }
}
