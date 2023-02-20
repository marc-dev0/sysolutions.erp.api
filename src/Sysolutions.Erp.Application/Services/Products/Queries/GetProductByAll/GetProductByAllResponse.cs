using System;
using System.Collections;
using System.Collections.Generic;

namespace Sysolutions.Erp.Application.Services.Products.Queries.GetProductByAll
{
    public class GetProductByAllResponse
    {
        public int ProductId { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string BarCode { get; set; }
        public decimal Price { get; set; }
        public string StateDescription { get; set; }
        public string State { get; set; }
        public DateTime RegistrationDate { get; set; }
        public List<GetProductPresentationByAllResponse> ProductPresentations { get; set; }
    }

    public class GetProductPresentationByAllResponse
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string BarCode { get; set; }
        public string EquivalentFrom { get; set; }
        public string EquivalentTo { get; set; }
    }
}
