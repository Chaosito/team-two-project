using KartowkaMarkowkaHub.Services.Products;
using MediatR;

namespace KartowkaMarkowkaHub.Application.Products.Commands.DeleteProduct
{
    internal class DeleteProductCommandHandler
        : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductService _productService;

        public DeleteProductCommandHandler(IProductService roleService)
        {
            _productService = roleService;
        }

        public Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            _productService.Remove(request.Id);

            return Task.FromResult(true);
        }
    }
}
