namespace Sysolutions.Erp.Application.Services.Products.Queries.GetPresentationsByProductId
{
    public class GetPresentationsByProductIdResponse
    {
        public int ProductPresentationId { get; set; }
        public string EquivalentFrom { get; set; }
        public decimal Price { get; set; }
        public int Hierarchy { get; set; }
        public int EquivalentQuantity { get; set; }
        public int Quantity { get; set; }
        public int QuantityMax { get; set; }
        public int MeasureFromId { get; set; }
    }
}
