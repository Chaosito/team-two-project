using FluentValidation;

namespace KartowkaMarkowkaHub.Application.Products.Commands.DeleteProduct
{
    internal class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
