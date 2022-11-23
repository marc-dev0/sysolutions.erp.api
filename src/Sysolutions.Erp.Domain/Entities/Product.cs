using System;

namespace Sysolutions.Erp.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string BarCode { get; set; }
        public decimal Price { get; set; }
        public decimal AverageCost { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategory { get; set; }
        public int BrandId { get; set; }
        public string Brand { get; set; }
        public int MeasureId { get; set; }
        public string Measure { get; set; }
        public string State { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int RegistrationAccountId { get; set; }
        public int ModifiedAccountId { get; set; }
        public string StateDescription { get; set; }
    }
}
