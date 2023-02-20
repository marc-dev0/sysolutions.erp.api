using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Domain.Entities;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace Sysolutions.Erp.Application.Services.Accounts.Commands.UpdateAccountCommand
{
    public class UpdateAccountHandler : IRequestHandler<UpdateAccountCommand, Response<bool>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public UpdateAccountHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }
        public async Task<Response<bool>> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            try
            {
                var account = _mapper.Map<Account>(request);
                if (!string.IsNullOrEmpty(account.Secret))
                    account.Secret = BC.HashPassword(request.Secret.ToLower());

                response.Data = await _accountRepository.UpdateAsync(account);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitoso.";
                }
                else
                {
                    response.Message = "Actualización Fallida.";
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
