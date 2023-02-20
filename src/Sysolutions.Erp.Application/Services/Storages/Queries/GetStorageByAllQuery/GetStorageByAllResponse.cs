using System;

namespace Sysolutions.Erp.Application.Services.Storages.Queries.GetStorageByAllQuery
{
    public class GetStorageByAllResponse
    {
        public int StorageId { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int RegistrationAccountId { get; set; }

        public string StateDescription { get; set; }
    }
}
