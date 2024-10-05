using FluentValidation;
using KartowkaMarkowkaHub.Web.Models;

namespace KartowkaMarkowkaHub.Web.Validators
{
    public class OrderUpdateRequestValidator : AbstractValidator<UpdateOrderRequest>
    {
        public OrderUpdateRequestValidator()
        {
            RuleFor(o => o.OrderStatusId).NotEmpty().WithMessage("Order status id is empty");
            RuleFor(o => o.ProductId).NotEmpty().WithMessage("Order product id is empty");
        }
    }
}
