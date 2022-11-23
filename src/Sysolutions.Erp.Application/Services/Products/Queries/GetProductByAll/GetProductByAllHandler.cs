using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Services.Accounts.Queries.GetAccountByAll;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Products.Queries.GetProductByAll
{
    public class GetProductByAllHandler : IRequestHandler<GetProductByAllQuery, Response<IEnumerable<GetProductByAllResponse>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByAllHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetProductByAllResponse>>> Handle(GetProductByAllQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<GetProductByAllResponse>>();
            try
            {
                var account = await _productRepository.GetAllAsync();
                if (account is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<GetProductByAllResponse>>(account);
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