using System;

namespace Sysolutions.Erp.Domain.Entities
{
    public class SubCategory
    {
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public string StateDescription { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int RegistrationAccountId { get; set; }
    }
}
