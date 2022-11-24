using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Services.Products.Queries.GetProductByAll;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Profiles.Queries.GetProfileByAll
{
    public class GetProfileByAllHandler : IRequestHandler<GetProfileByAllQuery, Response<IEnumerable<GetProfileByAllResponse>>>
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;

        public GetProfileByAllHandler(IProfileRepository profileRepository, IMapper mapper)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetProfileByAllResponse>>> Handle(GetProfileByAllQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<GetProfileByAllResponse>>();
            try
            {
                var account = await _profileRepository.GetAllAsync();
                if (account is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<GetProfileByAllResponse>>(account);
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
