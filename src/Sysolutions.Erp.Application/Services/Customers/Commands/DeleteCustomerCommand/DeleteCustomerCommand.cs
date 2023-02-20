using Sysolutions.Erp.Application.Commons;
using MediatR;

namespace Sysolutions.Erp.Application.Services.Customers.Commands.DeleteCustomerCommand
{
    public class DeleteCustomerCommand : IRequest<Response<bool>>
    {
        public string CustomerId { get; set; }
    }
}
