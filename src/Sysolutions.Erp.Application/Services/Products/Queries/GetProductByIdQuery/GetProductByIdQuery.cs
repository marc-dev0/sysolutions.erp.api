using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Services.Products.Queries.GetPresentationsByProductId;
using Sysolutions.Erp.Application.Services.Products.Queries.GetProductByAll;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Products.Queries.GetProductByIdQuery
{
    public class GetProductByIdQuery : IRequest<Response<GetProductByIdResponse>>
    {
        public int ProductId { get; set; }
    }

    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Response<GetProductByIdResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Response<GetProductByIdResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<GetProductByIdResponse>();
            try
            {
                var product = await _productRepository.GetByIdAsync(request.ProductId);
                if (product is not null)
                {
                    response.Data = _mapper.Map<GetProductByIdResponse>(product);
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
