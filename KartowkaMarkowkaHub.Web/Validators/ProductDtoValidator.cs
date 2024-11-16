using FluentValidation;
using KartowkaMarkowkaHub.Services.Products;

namespace KartowkaMarkowkaHub.Web.Validators
{
    public class ProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Product name is empty");
            RuleFor(p => p.Price).NotEmpty().WithMessage("Product name is empty")
                .GreaterThan(0).WithMessage("Product price less than 0");
        }
    }
}