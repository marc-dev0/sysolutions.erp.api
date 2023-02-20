using System;
using System.Collections.Generic;

namespace Sysolutions.Erp.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public decimal AverageCost { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int BrandId { get; set; }
        public string State { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int RegistrationAccountId { get; set; }
        public int ModifiedAccountId { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Brand { get; set; }
        public string StateDescription { get; set; }
        public List<ProductPresentation> productPresentations { get; set; }
    }
}
