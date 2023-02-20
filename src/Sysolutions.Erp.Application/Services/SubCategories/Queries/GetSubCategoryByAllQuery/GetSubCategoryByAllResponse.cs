using System;
namespace Sysolutions.Erp.Application.Services.SubCategories.Queries.GetSubCategoryByAllQuery
{
    public class GetSubCategoryByAllResponse
    {
        public int SubCategoryId { get; set; }
        public string Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string State { get; set; }

        public string StateDescription { get; set; }
        public string CategoryDescription { get; set; }
    }
}
