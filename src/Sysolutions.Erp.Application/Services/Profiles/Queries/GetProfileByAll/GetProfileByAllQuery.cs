using MediatR;
using Sysolutions.Erp.Application.Commons;
using System.Collections.Generic;

namespace Sysolutions.Erp.Application.Services.Profiles.Queries.GetProfileByAll
{
    public class GetProfileByAllQuery : IRequest<Response<IEnumerable<GetProfileByAllResponse>>>
    {
    }
}
