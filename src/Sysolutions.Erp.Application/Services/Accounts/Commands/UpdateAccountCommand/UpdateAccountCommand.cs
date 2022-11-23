using MediatR;
using Sysolutions.Erp.Application.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Accounts.Commands.UpdateAccountCommand
{
    public class UpdateAccountCommand : IRequest<Response<bool>>
    {
        public int AccountId { get; set; }
        public int ModifiedAccountId { get; set; }
        public string Client { get; set; }
        public string Secret { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StateCode { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string IdentificationDocument { get; set; }
    }
}
