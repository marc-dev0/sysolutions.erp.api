using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Services.Measures.Queries.GetMeasureByAll;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Brands.Queries.GetBrandByAllQuery
{
    public class GetBrandByAllQuery : IRequest<Response<IEnumerable<GetBrandByAllResponse>>>
    {
    }

    public class GetBrandByAllHandler : IRequestHandler<GetBrandByAllQuery, Response<IEnumerable<GetBrandByAllResponse>>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetBrandByAllHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetBrandByAllResponse>>> Handle(GetBrandByAllQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<GetBrandByAllResponse>>();
            try
            {
                var response1 = await _brandRepository.GetAllAsync();
                if (response1 is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<GetBrandByAllResponse>>(response1);
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
