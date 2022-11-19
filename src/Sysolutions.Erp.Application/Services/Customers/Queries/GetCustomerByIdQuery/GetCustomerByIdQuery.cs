using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Dtos;
using MediatR;

namespace Sysolutions.Erp.Application.Services.Customers.Queries.GetCustomerByIdQuery
{
    public class GetCustomerByIdQuery : IRequest<Response<CustomerDto>>
    {
        public string CustomerId { get; set; }
    }
}
