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

namespace Sysolutions.Erp.Application.Services.Products.Commands.UpdateProductCommand
{
    public class UpdateProductCommand : IRequest<Response<bool>>
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int BrandId { get; set; }
        public string State { get; set; }
        public int ModifiedAccountId { get; set; }
        public IEnumerable<ProductPresentation> ProductPresentations { get; set; }
    }

    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Response<bool>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            try
            {
                var product = _mapper.Map<Product>(request);

                response.Data = await _productRepository.UpdateAsync(product);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitoso.";
                }
                else
                {
                    response.Message = "Actualización Fallida.";
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
