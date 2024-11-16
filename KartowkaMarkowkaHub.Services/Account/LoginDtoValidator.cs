using FluentValidation;
using KartowkaMarkowkaHub.Services.Account;

namespace KartowkaMarkowkaHub.DTO.Account.Validators
{
    public class LoginDTOValidator: AbstractValidator<LoginDto>
    {
        public LoginDTOValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Login is required")
                .MaximumLength(50).WithMessage("Login length can't be more than 50.");
        }
    }
}
