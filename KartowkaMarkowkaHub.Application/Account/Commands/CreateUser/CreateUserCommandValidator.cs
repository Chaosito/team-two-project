using FluentValidation;

namespace KartowkaMarkowkaHub.Application.Account.Commands.CreateUser
{
    internal class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Login)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Email)
               .NotNull()
               .NotEmpty();

            RuleFor(x => x.Password)
               .NotNull()
               .NotEmpty();
        }
    }
}
