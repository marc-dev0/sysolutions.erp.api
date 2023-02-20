using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Accounts.Commands.AddTokenCommand
{
    public class AddTokenResponse
    {
        public string Token { get; set; }
        public int AccountId { get; set; }
        public string Names { get; set; }
    }
}
