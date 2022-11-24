using System;

namespace Sysolutions.Erp.Application.Services.Accounts.Queries.GetAccountByAll
{
    public class GetAccountByAllResponse
    {
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Client { get; set; }
        public string StateDescription { get; set; }
        public string State { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string ProfileDescription { get; set; }
    }
}
