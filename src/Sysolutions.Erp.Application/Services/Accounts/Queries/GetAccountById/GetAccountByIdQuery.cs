using MediatR;
using Sysolutions.Erp.Application.Commons;

namespace Sysolutions.Erp.Application.Services.Accounts.Queries.GetAccountById
{
    public class GetAccountByIdQuery : IRequest<Response<GetAccountByIdResponse>>
    {
        public int AccountId { get; set; }
        public GetAccountByIdQuery (int accountId)
        {
            this.AccountId = accountId;   
        }
    }
}
