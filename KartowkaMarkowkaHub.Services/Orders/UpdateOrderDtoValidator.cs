using FluentValidation;

namespace KartowkaMarkowkaHub.Services.Orders
{
    internal class UpdateOrderDtoValidator : AbstractValidator<UpdateOrderDto>
    {
        public UpdateOrderDtoValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEqual(Guid.Empty);

            RuleFor(x => x.OrderStatusId)
                .NotEqual(Guid.Empty);
        }
    }
}
