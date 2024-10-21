using FluentValidation;

namespace KartowkaMarkowkaHub.Application.Orders.Queries.GetUserOrders
{
    internal class GetUserOrdersQueryValidator : AbstractValidator<GetUserOrdersQuery>
    {
        public GetUserOrdersQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty);
        }
    }
}
