using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Sysolutions.Erp.Application.Services.Storages.Queries.GetStorageByAllQuery
{
    public class GetStorageByAllQuery : IRequest<Response<IEnumerable<GetStorageByAllResponse>>>
    {
    }

    public class GetStorageByAllHandler : IRequestHandler<GetStorageByAllQuery, Response<IEnumerable<GetStorageByAllResponse>>>
    {
        private readonly IStorageRepository _storageRepository;
        private readonly IMapper _mapper;

        public GetStorageByAllHandler(IStorageRepository storageRepository, IMapper mapper)
        {
            _storageRepository = storageRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetStorageByAllResponse>>> Handle(GetStorageByAllQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<GetStorageByAllResponse>>();
            try
            {
                var response1 = await _storageRepository.GetAllAsync();
                if (response1 is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<GetStorageByAllResponse>>(response1);
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
