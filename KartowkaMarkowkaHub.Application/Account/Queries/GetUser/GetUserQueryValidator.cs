using FluentValidation;

namespace KartowkaMarkowkaHub.Application.Account.Queries.GetUser
{
    internal class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
