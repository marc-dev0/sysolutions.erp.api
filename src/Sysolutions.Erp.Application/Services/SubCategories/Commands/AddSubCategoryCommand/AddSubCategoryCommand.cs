using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Domain.Entities;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.SubCategories.Commands.AddSubCategoryCommand
{
    public class AddSubCategoryCommand : IRequest<Response<bool>>
    {
        public string Description { get; set; }
        public string State { get; set; }
        public int CategoryId { get; set; }
        public int RegistrationAccountId { get; set; }
    }

    public class AddSubCategoryHandler : IRequestHandler<AddSubCategoryCommand, Response<bool>>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;

        public AddSubCategoryHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(AddSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            try
            {
                var product = _mapper.Map<SubCategory>(request);

                response.Data = await _subCategoryRepository.InsertAsync(product);

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
