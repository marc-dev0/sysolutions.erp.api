using Sysolutions.Security.Application.Commons;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Sysolutions.Security.Application.Services.Accounts.Commands.AddTokenCommand
{
    public class AddTokenCommand : IRequest<Response<string>>
    {
        [Required]
        public string Client { get; set; }

        [Required]
        public string Secret { get; set; }
    }
}
