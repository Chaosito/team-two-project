using KartowkaMarkowkaHub.Services.Products;
using MediatR;

namespace KartowkaMarkowkaHub.Application.Products.Commands.CreateProduct
{
    internal class CreateProductCommandHandler
        : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IProductService roleService)
        {
            _productService = roleService;
        }

        public Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _productService.Create(
                new CreateProductDto
                {
                    Name = request.Name,
                    Price = request.Price,
                },
                request.UserId);

            return Task.FromResult(Guid.Empty);
        }
    }
}
