using FluentValidation;
using KartowkaMarkowkaHub.Web.Models;

namespace KartowkaMarkowkaHub.Web.Validators
{
    public class OrderCreateRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public OrderCreateRequestValidator() 
        {
            RuleFor(o => o.Number).NotEmpty().WithMessage("Order number is empty");
            RuleFor(o => o.ProductId).NotEmpty().WithMessage("Order product id is empty");
        }
    }
}