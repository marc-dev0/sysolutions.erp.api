using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Domain.Entities;

namespace Sysolutions.Erp.Application.Services.Sales.Queries.GetSalesOrderByAllQuery
{
    public class GetSalesOrderByAllQuery : IRequest<Response<GetBaseSalesOrderByAllResponse>>
    {
        public int First { get; set; }
        public int Rows { get; set; }
    }
}
