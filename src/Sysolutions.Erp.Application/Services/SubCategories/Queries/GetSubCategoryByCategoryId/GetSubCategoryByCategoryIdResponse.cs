using System;

namespace Sysolutions.Erp.Application.Services.SubCategories.Queries.GetSubCategoryByCategoryId
{
    public class GetSubCategoryByCategoryIdResponse
    {
        public int SubCategoryId { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int RegistrationAccountId { get; set; }

        public string StateDescription { get; set; }
        public string CategoryDescription { get; set; }
    }
}
