using Sysolutions.Security.Application.Commons;
using Sysolutions.Security.Application.Dtos;
using MediatR;

namespace Sysolutions.Security.Application.Services.Customers.Queries.GetCustomerByIdQuery
{
    public class GetCustomerByIdQuery : IRequest<Response<CustomerDto>>
    {
        public string CustomerId { get; set; }
    }
}
