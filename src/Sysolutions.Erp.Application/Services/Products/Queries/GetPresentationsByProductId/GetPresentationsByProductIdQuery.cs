using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Services.Products.Queries.GetProductByAll;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Sysolutions.Erp.Application.Services.Products.Queries.GetPresentationsByProductId
{
    public class GetPresentationsByProductIdQuery : IRequest<Response<IEnumerable<GetPresentationsByProductIdResponse>>>
    {
        public int ProductId { get; set; }
        public GetPresentationsByProductIdQuery (int productId)
        {
            this.ProductId = productId;
        }
    }

    public class GetPresentationsByProductIdHandler : IRequestHandler<GetPresentationsByProductIdQuery, Response<IEnumerable<GetPresentationsByProductIdResponse>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetPresentationsByProductIdHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetPresentationsByProductIdResponse>>> Handle(GetPresentationsByProductIdQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<GetPresentationsByProductIdResponse>>();
            try
            {
                var account = await _productRepository.GetPresentationsByProductId(request.ProductId);
                if (account is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<GetPresentationsByProductIdResponse>>(account);
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
