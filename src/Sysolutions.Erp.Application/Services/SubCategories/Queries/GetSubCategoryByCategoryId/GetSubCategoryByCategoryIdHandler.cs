using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Services.Categories.Queries.GetCategoryByAll;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using Sysolutions.Erp.Infrastructure.Persistences.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.SubCategories.Queries.GetSubCategoryByCategoryId
{
    public class GetSubCategoryByCategoryIdHandler : IRequestHandler<GetSubCategoryByCategoryIdQuery, Response<IEnumerable<GetSubCategoryByCategoryIdResponse>>>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;

        public GetSubCategoryByCategoryIdHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetSubCategoryByCategoryIdResponse>>> Handle(GetSubCategoryByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<GetSubCategoryByCategoryIdResponse>>();
            try
            {
                var response1 = await _subCategoryRepository.GetByCategoryIdAsync(request.CategoryId);
                if (response1 is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<GetSubCategoryByCategoryIdResponse>>(response1);
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
