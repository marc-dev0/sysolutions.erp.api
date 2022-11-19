using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Accounts.Queries.GetAccountByAll
{
    public class GetAccountByAllResponse
    {
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Client { get; set; }
        public string StateDescription { get; set; }
    }
}
