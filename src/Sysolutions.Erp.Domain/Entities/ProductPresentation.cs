namespace Sysolutions.Erp.Domain.Entities
{
    public class ProductPresentation
    {
        public int ProductPresentationId { get; set; }
        public int EquivalentQuantity { get; set; }
        public decimal Price { get; set; }
        public string BarCode { get; set; }
        public int MeasureFromId { get; set; }
        public int MeasureToId { get; set; }
        public int ProductId { get; set; } 
    }
}
