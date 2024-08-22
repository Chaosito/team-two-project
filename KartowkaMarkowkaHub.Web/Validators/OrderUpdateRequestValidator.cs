using FluentValidation;
using KartowkaMarkowkaHub.Services.Orders;

namespace KartowkaMarkowkaHub.Web.Validators
{
    public class OrderUpdateRequestValidator : AbstractValidator<OrderUpdateRequest>
    {
        public OrderUpdateRequestValidator()
        {
            RuleFor(o => o.OrderStatusId).NotEmpty().WithMessage("Order status id is empty");
            RuleFor(o => o.ProductId).NotEmpty().WithMessage("Order product id is empty");
        }
    }
}
