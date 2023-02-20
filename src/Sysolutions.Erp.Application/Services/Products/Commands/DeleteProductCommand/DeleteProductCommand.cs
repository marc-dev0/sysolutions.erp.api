using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Domain.Entities;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Products.Commands.DeleteProductCommand
{
    public class DeleteProductCommand : IRequest<Response<bool>>
    {
        public int ProductId { get; set; }
        public int ModifiedAccountId { get; set; }
    }

    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Response<bool>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public async Task<Response<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            try
            {
                var product = _mapper.Map<Product>(request);

                response.Data = await _productRepository.DeleteAsync(request.ProductId, request.ModifiedAccountId);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso.";
                }
                else
                {
                    response.Message = "Registro Fallido.";
                }
            }
            catch (Exception)
            {
                throw;
            }

            return response;
        }
    }
}
