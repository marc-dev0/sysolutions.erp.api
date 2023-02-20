using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Services.Products.Queries.GetProductByAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Masters.Queries.GetMasterByAll
{
    public class GetMasterByAllQuery : IRequest<Response<IEnumerable<GetMasterByAllResponse>>>
    {
    }
}
