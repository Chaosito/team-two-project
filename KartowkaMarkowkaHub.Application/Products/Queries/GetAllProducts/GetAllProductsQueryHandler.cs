using KartowkaMarkowkaHub.Services.Products;
using MediatR;

namespace KartowkaMarkowkaHub.Application.Products.Queries.GetAllProducts
{
    internal class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ProductsViewModel>
    {
        private readonly IProductService _productService;

        public GetAllProductsQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductsViewModel> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var roles = await _productService.Get();
            var productViewModels = roles
                .Select(x => new ProductViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                }).ToList();

            return new ProductsViewModel { Products = productViewModels };
        }
    }
}
