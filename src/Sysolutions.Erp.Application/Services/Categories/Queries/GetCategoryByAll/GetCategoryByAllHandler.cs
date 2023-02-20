using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Services.Masters.Queries.GetMasterByAll;
using Sysolutions.Erp.Application.Services.Products.Queries.GetProductByAll;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Categories.Queries.GetCategoryByAll
{
    public class GetCategoryByAllHandler : IRequestHandler<GetCategoryByAllQuery, Response<IEnumerable<GetCategoryByAllResponse>>>
    {
        private readonly iCategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryByAllHandler(iCategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetCategoryByAllResponse>>> Handle(GetCategoryByAllQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<GetCategoryByAllResponse>>();
            try
            {
                var response1 = await _categoryRepository.GetAllAsync();
                if (response1 is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<GetCategoryByAllResponse>>(response1);
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
