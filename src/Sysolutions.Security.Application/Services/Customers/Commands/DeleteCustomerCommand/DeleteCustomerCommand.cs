using Sysolutions.Security.Application.Commons;
using MediatR;

namespace Sysolutions.Security.Application.Services.Customers.Commands.DeleteCustomerCommand
{
    public class DeleteCustomerCommand : IRequest<Response<bool>>
    {
        public string CustomerId { get; set; }
    }
}
