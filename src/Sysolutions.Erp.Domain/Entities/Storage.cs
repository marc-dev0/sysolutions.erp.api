using System;

namespace Sysolutions.Erp.Domain.Entities
{
    public class Storage
    {
        public int StorageId { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public string StateDescription { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int RegistrationAccountId { get; set; }
    }
}
