using FluentValidation;

namespace KartowkaMarkowkaHub.Services.Orders
{
    internal class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
    {
        public CreateOrderDtoValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEqual(Guid.Empty);
        }
    }
}
