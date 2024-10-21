using FluentValidation;

namespace KartowkaMarkowkaHub.Services.Products
{
    internal class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0);
        }
    }
}