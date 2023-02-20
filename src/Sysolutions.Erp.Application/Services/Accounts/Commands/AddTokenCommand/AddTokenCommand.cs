using Sysolutions.Erp.Application.Commons;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Sysolutions.Erp.Application.Services.Accounts.Commands.AddTokenCommand
{
    public class AddTokenCommand : IRequest<Response<AddTokenResponse>>
    {
        [Required]
        public string Client { get; set; }

        [Required]
        public string Secret { get; set; }
    }
}
