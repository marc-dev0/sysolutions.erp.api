using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Storages.Queries.GetStorageProductByStorageIdQuery
{
    public class GetStorageProductByStorageIdQuery : IRequest<Response<IEnumerable<GetStorageProductByStorageIdResponse>>>
    {
        public int StorageId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string Description { get; set; }
    }

    public class GetStoragePRoductByStorageIdHandler : IRequestHandler<GetStorageProductByStorageIdQuery, Response<IEnumerable<GetStorageProductByStorageIdResponse>>>
    {
        private readonly IStorageRepository _storageRepository;
        private readonly IMapper _mapper;

        public GetStoragePRoductByStorageIdHandler(IStorageRepository storageRepository, IMapper mapper)
        {
            _storageRepository = storageRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetStorageProductByStorageIdResponse>>> Handle(GetStorageProductByStorageIdQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<GetStorageProductByStorageIdResponse>>();
            try
            {
                var response1 = await _storageRepository.GetStorageProductByStorageIdAsync(request.StorageId, request.CategoryId, request.SubCategoryId, request.Description);
                if (response1 is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<GetStorageProductByStorageIdResponse>>(response1);
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
