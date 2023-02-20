using System;

namespace Sysolutions.Erp.Application.Services.Categories.Queries.GetCategoryByAll
{
    public class GetCategoryByAllResponse
    {
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int RegistrationAccountId { get; set; }

        public string StateDescription { get; set; }
    }
}
