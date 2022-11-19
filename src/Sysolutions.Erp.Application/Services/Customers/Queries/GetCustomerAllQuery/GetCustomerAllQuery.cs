using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Dtos;
using MediatR;

namespace Sysolutions.Erp.Application.Services.Customers.Queries.GetCustomerAllQuery
{
    public class GetCustomerAllQuery : IRequest<Response<IEnumerable<CustomerDto>>>
    {
    }
}
