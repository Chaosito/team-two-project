using FluentValidation;
using KartowkaMarkowkaHub.Services.Orders;

namespace KartowkaMarkowkaHub.Web.Validators
{
    public class OrderCreateRequestValidator : AbstractValidator<OrderCreateRequest>
    {
        public OrderCreateRequestValidator() 
        {
            RuleFor(o => o.Number).NotEmpty().WithMessage("Order number is empty");
            RuleFor(o => o.OrderStatusId).NotEmpty().WithMessage("Order status id is empty");
            RuleFor(o => o.ProductId).NotEmpty().WithMessage("Order product id is empty");
        }
    }
}