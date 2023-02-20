using System;

namespace Sysolutions.Erp.Application.Services.Brands.Queries.GetBrandByAllQuery
{
    public class GetBrandByAllResponse
    {
        public int BrandId { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int RegistrationAccountId { get; set; }

        public string StateDescription { get; set; }
    }
}
