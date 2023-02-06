namespace Sysolutions.Erp.Application.Services.Storages.Queries.GetStorageProductByStorageIdQuery
{
    public class GetStorageProductByStorageIdResponse
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public string ProductDescription { get; set; }
        public int MeasureFromId { get; set; }
        public string EquivalentFrom { get; set; }
        public string CategoryBelongs { get; set; }
        public string InventoryStatus { get; set; }
    }
}
