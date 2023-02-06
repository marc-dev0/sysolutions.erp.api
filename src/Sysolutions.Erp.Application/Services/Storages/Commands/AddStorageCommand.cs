using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Domain.Entities;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Storages.Commands
{
    public class AddStorageCommand : IRequest<Response<bool>>
    {
        public string Description { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public int RegistrationAccountId { get; set; }
    }

    public class AddStorageHandler : IRequestHandler<AddStorageCommand, Response<bool>>
    {
        private readonly IStorageRepository _storageRepository;
        private readonly IMapper _mapper;

        public AddStorageHandler(IStorageRepository storageRepository, IMapper mapper)
        {
            _storageRepository = storageRepository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(AddStorageCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            try
            {
                var requestMap = _mapper.Map<Storage>(request);

                response.Data = await _storageRepository.InsertAsync(requestMap);

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
