using System;

namespace Sysolutions.Erp.Domain.Entities
{
    public class Account
    {
        public int AccountId { get; set; }
        public int RegistrationAccountId { get; set; }
        public string Client { get; set; }
        public string Secret { get; set; }
        public string FirstName { get; set; }
        public string FirstName1 { get; set; }
        public string LastName { get; set; }
        public string LastName1 { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Names { get; set; }
        public string StateDescription { get; set; }
    }
}
