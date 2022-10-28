using FluentValidation;

namespace Sysolutions.Security.Application.Services.Accounts.Commands.AddTokenCommand
{
    public class AddTokenValidator : AbstractValidator<AddTokenCommand>
    {
        public AddTokenValidator()
        {
            RuleFor(x => x.Client).NotNull().NotEmpty().MinimumLength(5);
            RuleFor(x => x.Secret).NotNull().NotEmpty().MinimumLength(5);
        }
    }
}
