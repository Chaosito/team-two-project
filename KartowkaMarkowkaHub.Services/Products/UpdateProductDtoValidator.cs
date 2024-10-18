using FluentValidation;

namespace KartowkaMarkowkaHub.Services.Products
{
    internal class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0);
        }
    }
}