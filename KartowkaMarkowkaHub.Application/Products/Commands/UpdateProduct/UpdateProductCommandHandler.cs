using KartowkaMarkowkaHub.Services.Products;
using MediatR;

namespace KartowkaMarkowkaHub.Application.Products.Commands.UpdateProduct
{
    internal class UpdateProductCommandHandler
        : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductService _productService;

        public UpdateProductCommandHandler(IProductService roleService)
        {
            _productService = roleService;
        }

        public Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            _productService.Update(
                request.Id,
                new UpdateProductDto
                {
                    Name = request.Name,
                    Price = request.Price,
                });

            return Task.FromResult(true);
        }
    }
}
