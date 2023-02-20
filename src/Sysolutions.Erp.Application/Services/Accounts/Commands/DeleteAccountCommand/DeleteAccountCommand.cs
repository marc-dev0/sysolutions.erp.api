using MediatR;
using Sysolutions.Erp.Application.Commons;

namespace Sysolutions.Erp.Application.Services.Accounts.Commands.DeleteAccountCommand
{
    public class DeleteAccountCommand : IRequest<Response<bool>>
    {
        public int AccountId { get; set; }
        public int ModifiedAccountId { get; set; }

        public DeleteAccountCommand(int accountId, int modifiedAccountId)
        {
            AccountId = accountId;
            ModifiedAccountId = modifiedAccountId;
        }
    }
}
