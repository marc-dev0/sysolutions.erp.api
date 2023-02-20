using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Domain.Entities;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Categories.Commands
{
    public class AddCategoryCommand : IRequest<Response<bool>>
    {
        public string Description { get; set; }
        public string State { get; set; }
        public int RegistrationAccountId { get; set; }
    }

    public class AddCategoryHandler : IRequestHandler<AddCategoryCommand, Response<bool>>
    {
        private readonly iCategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public AddCategoryHandler(iCategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            try
            {
                var requestMap = _mapper.Map<Category>(request);

                response.Data = await _categoryRepository.InsertAsync(requestMap);

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
