using MediatR;
using Sysolutions.Erp.Application.Commons;
using System.Collections.Generic;

namespace Sysolutions.Erp.Application.Services.SubCategories.Queries.GetSubCategoryByCategoryId
{
    public class GetSubCategoryByCategoryIdQuery : IRequest<Response<IEnumerable<GetSubCategoryByCategoryIdResponse>>>
    {
        public int CategoryId { get; set; }
    }
}
