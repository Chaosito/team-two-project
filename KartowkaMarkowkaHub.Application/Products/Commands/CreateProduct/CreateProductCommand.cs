using MediatR;

namespace KartowkaMarkowkaHub.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
