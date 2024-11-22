using KartowkaMarkowkaHub.Services.Products;
using MassTransit;

namespace KartowkaMarkowkaHub.Basket.rabbitmq
{
    public class ConsumerByProduct: IConsumer<GetProductDto>
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public ConsumerByProduct(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task Consume(ConsumeContext<GetProductDto> context)
        {
            var product = context.Message;
            Console.WriteLine($"Consume product name: {product.Name}");
        }
    }
}
