using Sysolutions.Erp.Application.Commons;
using MediatR;

namespace Sysolutions.Erp.Application.Services.Accounts.Commands.AddAccountCommand
{
    public class AddAccountCommand : IRequest<Response<bool>>
    {
        public int RegistrationAccountId { get; set; }
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
