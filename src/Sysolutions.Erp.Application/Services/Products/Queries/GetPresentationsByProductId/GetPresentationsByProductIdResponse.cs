namespace Sysolutions.Erp.Application.Services.Products.Queries.GetPresentationsByProductId
{
    public class GetPresentationsByProductIdResponse
    {
        public string EquivalentFrom { get; set; }
        public decimal Price { get; set; }
        public int Hierarchy { get; set; }
        public int MeasureFromId { get; set; }
    }
}
