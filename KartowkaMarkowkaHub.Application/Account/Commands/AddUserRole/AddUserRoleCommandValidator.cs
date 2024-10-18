using FluentValidation;

namespace KartowkaMarkowkaHub.Application.Account.Commands.AddUserRole
{
    internal class AddUserRoleCommandValidator : AbstractValidator<AddUserRoleCommand>
    {
        public AddUserRoleCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty);

            RuleFor(x => x.RoleId)
               .NotEqual(Guid.Empty);
        }
    }
}
