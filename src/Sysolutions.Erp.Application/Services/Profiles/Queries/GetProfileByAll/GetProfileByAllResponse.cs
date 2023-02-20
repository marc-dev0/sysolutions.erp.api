using System;

namespace Sysolutions.Erp.Application.Services.Profiles.Queries.GetProfileByAll
{
    public class GetProfileByAllResponse
    {
        public int ProfileId { get; set; }
        public string Description { get; set; }
        public string StateDescription { get; set; }
        public string State { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
