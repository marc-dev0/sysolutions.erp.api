using AutoMapper;
using MediatR;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Application.Services.Customers.Commands.DeleteCustomerCommand;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using Sysolutions.Erp.Infrastructure.Persistences.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Accounts.Commands.DeleteAccountCommand
{
    public class DeleteAccountHandler : IRequestHandler<DeleteAccountCommand, Response<bool>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public DeleteAccountHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            try
            {

                response.Data = await _accountRepository.DeleteAsync(request.AccountId, request.ModifiedAccountId);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación exitosa";
                }
                else
                {
                    response.Message = "Eliminación fallida";
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
