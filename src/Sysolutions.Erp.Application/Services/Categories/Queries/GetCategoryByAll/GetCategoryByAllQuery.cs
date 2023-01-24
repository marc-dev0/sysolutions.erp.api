using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Services.Masters.Queries.GetMasterByAll;
using System.Collections.Generic;

namespace Sysolutions.Erp.Application.Services.Categories.Queries.GetCategoryByAll
{
    public class GetCategoryByAllQuery : IRequest<Response<IEnumerable<GetCategoryByAllResponse>>>
    {
    }
}
