using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Measures.Queries.GetMeasureByAll
{
    public class GetMeasureByAllQuery : IRequest<Response<IEnumerable<GetMeasureByAllResponse>>>
    {
    }

    public class GetMeasureByAllHandler : IRequestHandler<GetMeasureByAllQuery, Response<IEnumerable<GetMeasureByAllResponse>>>
    {
        private readonly IMeasureRepository _measureRepository;
        private readonly IMapper _mapper;

        public GetMeasureByAllHandler(IMeasureRepository measureRepository, IMapper mapper)
        {
            _measureRepository = measureRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetMeasureByAllResponse>>> Handle(GetMeasureByAllQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<GetMeasureByAllResponse>>();
            try
            {
                var response1 = await _measureRepository.GetAllAsync();
                if (response1 is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<GetMeasureByAllResponse>>(response1);
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
