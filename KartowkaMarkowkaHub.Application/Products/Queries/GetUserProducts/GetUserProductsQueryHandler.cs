using KartowkaMarkowkaHub.Application.Products.Queries.GetAllProducts;
using KartowkaMarkowkaHub.Services.Products;
using MediatR;

namespace KartowkaMarkowkaHub.Application.Products.Queries.GetUserProducts
{
    internal class GetUserProductsQueryHandler : IRequestHandler<GetUserProductsQuery, ProductsViewModel>
    {
        private readonly IProductService _productService;

        public GetUserProductsQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductsViewModel> Handle(GetUserProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.Get(request.UserId);
            var productViewModels = products
                .Select(x => new GetAllProducts.ProductViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price
                }).ToList();

            return new ProductsViewModel { Products = productViewModels };
        }
    }
}
