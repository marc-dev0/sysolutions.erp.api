using Sysolutions.Security.Application.Commons;
using MediatR;

namespace Sysolutions.Security.Application.Services.Accounts.Commands.AddAccountCommand
{
    public class AddAccountCommand : IRequest<Response<bool>>
    {
        public string AccountId { get; set; }

        public string Company { get; set; }

        public string Abbreviation { get; set; }

        public string Client { get; set; }

        public string Secret { get; set; }
    }
}
