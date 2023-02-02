using System.Collections.Generic;

namespace Sysolutions.Erp.Application.Services.Products.Queries.GetProductByIdQuery
{
    public class GetProductByIdResponse
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategory { get; set; }
        public int BrandId { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public List<GetProdutPresentationByIdResponse> ProductPresentations { get; set; }
    }

    public class GetProdutPresentationByIdResponse
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string BarCode { get; set; }
        public int EquivalentQuantity { get; set; }
        public string EquivalentFrom { get; set; }
        public string EquivalentTo { get; set; }

    }
}
