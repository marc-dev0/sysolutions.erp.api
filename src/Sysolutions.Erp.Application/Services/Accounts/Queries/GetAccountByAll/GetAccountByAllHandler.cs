using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Dtos;
using Sysolutions.Erp.Application.Services.Customers.Queries.GetCustomerByIdQuery;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using Sysolutions.Erp.Infrastructure.Persistences.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Accounts.Queries.GetAccountByAll
{
    public class GetAccountByAllHandler : IRequestHandler<GetAccountByAllQuery, Response<IEnumerable<GetAccountByAllResponse>>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public GetAccountByAllHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetAccountByAllResponse>>> Handle(GetAccountByAllQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<GetAccountByAllResponse>>();
            try
            {
                var account = await _accountRepository.GetAllAsync(request.Client);
                if (account is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<GetAccountByAllResponse>>(account);
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
