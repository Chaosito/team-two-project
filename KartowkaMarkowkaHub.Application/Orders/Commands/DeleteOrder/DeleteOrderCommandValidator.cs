using FluentValidation;

namespace KartowkaMarkowkaHub.Application.Orders.Commands.RemoveOrder
{
    internal class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
