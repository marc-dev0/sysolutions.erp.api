using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Services.Measures.Queries.GetMeasureByAll;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Sysolutions.Erp.Application.Services.SubCategories.Queries.GetSubCategoryByAllQuery
{
    public class GetSubCategoryByAllQuery : IRequest<Response<IEnumerable<GetSubCategoryByAllResponse>>>
    {
        
    }

    public class GetSubCategoryByAllQueryHandler : IRequestHandler<GetSubCategoryByAllQuery, Response<IEnumerable<GetSubCategoryByAllResponse>>>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;

        public GetSubCategoryByAllQueryHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetSubCategoryByAllResponse>>> Handle(GetSubCategoryByAllQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<GetSubCategoryByAllResponse>>();
            try
            {
                var response1 = await _subCategoryRepository.GetAllAsync();
                if (response1 is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<GetSubCategoryByAllResponse>>(response1);
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
