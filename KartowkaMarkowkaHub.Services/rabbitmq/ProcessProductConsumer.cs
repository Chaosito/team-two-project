using KartowkaMarkowkaHub.Data.Repositories;
using KartowkaMarkowkaHub.Services.Products;
using MassTransit;

namespace KartowkaMarkowkaHub.Services.rabbitmq
{
    public class ProcessProductConsumer: IConsumer<ProcessProduct>
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly IUnitOfWork _unitOfWork;

        public ProcessProductConsumer(ISendEndpointProvider sendEndpointProvider, IUnitOfWork unitOfWork)
        {
            _sendEndpointProvider = sendEndpointProvider;
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<ProcessProduct> context)
        {
            Guid id = context.Message.ProductId;
            Console.WriteLine($"Product id: {id}");

            var product = _unitOfWork.ProductRepository.Get(p => p.Id == id).FirstOrDefault();
            if(product != null)
            {
                var uri = new Uri("queue:product-queue-response");
                var endpoint = await _sendEndpointProvider.GetSendEndpoint(uri);
                await endpoint.Send(new GetProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                });
                Console.WriteLine($"Send product name: {product.Name}");
            }

        }
    }
}
