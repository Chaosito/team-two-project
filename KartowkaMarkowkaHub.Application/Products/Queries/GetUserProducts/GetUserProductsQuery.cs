using KartowkaMarkowkaHub.Application.Products.Queries.GetAllProducts;
using MediatR;

namespace KartowkaMarkowkaHub.Application.Products.Queries.GetUserProducts
{
    public class GetUserProductsQuery : IRequest<ProductsViewModel>
    {
        public Guid UserId { get; set; }
    }
}
