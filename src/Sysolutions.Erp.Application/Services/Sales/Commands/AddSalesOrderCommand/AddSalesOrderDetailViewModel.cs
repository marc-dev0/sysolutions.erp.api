
namespace Sysolutions.Erp.Application.Services.Sales.Commands.AddSalesOrderCommand
{
    public class AddSalesOrderDetailViewModel
    {
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public string MeasureDescription { get; set; }
        public int ProductId { get; set; }
        public int SalesOrderId { get; set; }
        public int ProductPresentationId { get; set; }
    }
}
