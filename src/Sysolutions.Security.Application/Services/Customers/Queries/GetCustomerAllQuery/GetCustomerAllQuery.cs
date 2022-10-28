using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sysolutions.Security.Application.Commons;
using Sysolutions.Security.Application.Dtos;
using MediatR;

namespace Sysolutions.Security.Application.Services.Customers.Queries.GetCustomerAllQuery
{
    public class GetCustomerAllQuery : IRequest<Response<IEnumerable<CustomerDto>>>
    {
    }
}
