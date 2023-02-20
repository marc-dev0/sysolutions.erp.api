using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Services.SubCategories.Commands.AddSubCategoryCommand;
using Sysolutions.Erp.Domain.Entities;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Brands.Commands
{
    public class AddBrandCommand : IRequest<Response<bool>>
    {
        public string Description { get; set; }
        public string State { get; set; }
        public int RegistrationAccountId { get; set; }
    }

    public class AddBrandHandler : IRequestHandler<AddBrandCommand, Response<bool>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public AddBrandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(AddBrandCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            try
            {
                var product = _mapper.Map<Brand>(request);

                response.Data = await _brandRepository.InsertAsync(product);

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
