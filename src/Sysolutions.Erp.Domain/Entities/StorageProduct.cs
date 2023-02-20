using System;

namespace Sysolutions.Erp.Domain.Entities
{
    public class StorageProduct
    {
        public int Quantity { get; set; }
        public int StorageId { get; set; }
        public int ProductId { get; set; }
        public int ProductPresentationId { get; set; }
        public int RegistrationAccountId { get; set; }
        public DateTime RegistrationDate { get; set; }

        public string ProductDescription { get; set; }
        public string EquivalentFrom { get; set; }
        public string CategoryBelongs { get; set; }
        public string InventoryStatus { get; set; }
    }
}
