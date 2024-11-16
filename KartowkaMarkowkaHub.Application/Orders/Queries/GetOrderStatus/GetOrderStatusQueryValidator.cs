using FluentValidation;

namespace KartowkaMarkowkaHub.Application.Orders.Queries.GetOrderStatus
{
    internal class GetOrderStatusQueryValidator : AbstractValidator<GetOrderStatusQuery>
    {
        public GetOrderStatusQueryValidator()
        {
            RuleFor(x => x.OrderId)
                .NotEqual(Guid.Empty);
        }
    }
}
