using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Domain.Entities;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Sales.Queries.GetSalesOrderByAllQuery
{
    public class GetSalesOrderByAllHandler : IRequestHandler<GetSalesOrderByAllQuery, Response<GetBaseSalesOrderByAllResponse>>
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;

        public GetSalesOrderByAllHandler(ISalesRepository salesRepository, IMapper mapper)
        {
            _salesRepository = salesRepository;
            _mapper = mapper;
        }

        public async Task<Response<GetBaseSalesOrderByAllResponse>> Handle(GetSalesOrderByAllQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<GetBaseSalesOrderByAllResponse>();
            try
            {
                var sales = _mapper.Map<SalesOrder>(request);
                var list = await _salesRepository.GetAllAsync(sales);
                if (list is not null)
                {
                    response.Data = _mapper.Map<GetBaseSalesOrderByAllResponse>(list);
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
