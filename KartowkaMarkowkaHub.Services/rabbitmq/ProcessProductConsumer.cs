using KartowkaMarkowkaHub.Data.Repositories;
using KartowkaMarkowkaHub.Services.Products;
using MassTransit;

namespace KartowkaMarkowkaHub.Services.rabbitmq
{
    public class ProcessProductConsumer: IConsumer<ProductsRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProcessProductConsumer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<ProductsRequest> context)
        {
            var listId = context.Message.ProductIdList;
            var products = _unitOfWork.ProductRepository.Get(p => listId.Contains(p.Id));
            if (products != null && products.Count() > 0)
            {
                var productsDto = products.Select(p => new GetProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                });

                var response = new ProductsResponse { Products = productsDto };
                await context.RespondAsync(response);
            }
        }
    }
}
