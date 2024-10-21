using FluentValidation;

namespace KartowkaMarkowkaHub.Application.Orders.Commands.UpdateOrder
{
    internal class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty); 

            RuleFor(x => x.OrderStatusId)
                .NotEqual(Guid.Empty);
            
            RuleFor(x => x.ProductId)
                .NotEqual(Guid.Empty);
        }
    }
}
