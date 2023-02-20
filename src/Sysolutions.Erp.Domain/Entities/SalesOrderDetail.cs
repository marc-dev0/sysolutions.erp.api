
namespace Sysolutions.Erp.Domain.Entities
{
    public class SalesOrderDetail
    {
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public string MeasureDescription { get; set; }
        public int ProductId { get; set; }
        public int SalesOrderId { get; set; }
        public int ProductPresentationId { get; set; }
        public string Product { get; set; }
    }
}
