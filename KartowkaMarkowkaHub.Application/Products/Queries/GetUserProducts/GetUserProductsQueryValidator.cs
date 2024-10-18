using FluentValidation;

namespace KartowkaMarkowkaHub.Application.Products.Queries.GetUserProducts
{
    internal class GetUserProductsQueryValidator : AbstractValidator<GetUserProductsQuery>
    {
        public GetUserProductsQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty);
        }
    }
}
