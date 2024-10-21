using FluentValidation;

namespace KartowkaMarkowkaHub.Application.Products.Commands.CreateProduct
{
    internal class CreateProductCommandValidator : AbstractValidator< CreateProductCommand>
    {
        public  CreateProductCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty);

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0);
        }
    }
}
