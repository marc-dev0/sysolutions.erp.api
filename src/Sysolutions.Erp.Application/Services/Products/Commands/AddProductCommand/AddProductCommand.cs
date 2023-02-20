using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Domain.Entities;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;
namespace Sysolutions.Erp.Application.Services.Products.Commands.AddProductCommand
{
    public class AddProductCommand : IRequest<Response<bool>>
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int BrandId { get; set; }
        public string State { get; set; }
        public int RegistrationAccountId { get; set; }
        public IEnumerable<ProductPresentation> ProductPresentations { get; set; }
    }

    public class AddProductHandler : IRequestHandler<AddProductCommand, Response<bool>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public AddProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            try
            {
                var product = _mapper.Map<Product>(request);

                response.Data = await _productRepository.InsertAsync(product);

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
