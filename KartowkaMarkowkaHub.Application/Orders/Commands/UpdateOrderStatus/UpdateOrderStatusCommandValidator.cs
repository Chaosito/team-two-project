using FluentValidation;

namespace KartowkaMarkowkaHub.Application.Orders.Commands.UpdateOrderStatus
{
    public partial class UpdateOrderStatusCommand
    {
        internal class UpdateOrderStatusCommandValidator : AbstractValidator<UpdateOrderStatusCommand>
        {
            public UpdateOrderStatusCommandValidator()
            {
                RuleFor(x => x.OrderId)
                    .NotEqual(Guid.Empty);
            }
        }
    }
}
