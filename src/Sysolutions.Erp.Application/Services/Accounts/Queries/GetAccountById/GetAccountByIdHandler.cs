using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Services.Accounts.Queries.GetAccountByAll;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Accounts.Queries.GetAccountById
{
    public class GetAccountByIdHandler : IRequestHandler<GetAccountByIdQuery, Response<GetAccountByIdResponse>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public GetAccountByIdHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<Response<GetAccountByIdResponse>> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<GetAccountByIdResponse>();
            try
            {
                var account = await _accountRepository.GetByIdAsync(request.AccountId);
                if (account is not null)
                {
                    response.Data = _mapper.Map<GetAccountByIdResponse>(account);
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
