using FluentValidation;

namespace KartowkaMarkowkaHub.Application.Orders.Commands.CreateOrder
{
    internal class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty);

            RuleFor(x => x.ProductId)
                .NotEqual(Guid.Empty);
        }
    }
}
