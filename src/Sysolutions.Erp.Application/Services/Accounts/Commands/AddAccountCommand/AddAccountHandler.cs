using AutoMapper;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Domain.Entities;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace Sysolutions.Erp.Application.Services.Accounts.Commands.AddAccountCommand
{
    public class AddAccountHandler : IRequestHandler<AddAccountCommand, Response<bool>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AddAccountHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;            
        }

        public async Task<Response<bool>> Handle(AddAccountCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            try
            {
                var account = _mapper.Map<Account>(request);
                account.Secret = BC.HashPassword(request.Secret.ToLower());
                
                response.Data = await _accountRepository.InsertAsync(account);

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
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
