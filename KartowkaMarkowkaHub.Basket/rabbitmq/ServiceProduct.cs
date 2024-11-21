using MassTransit;

namespace KartowkaMarkowkaHub.Basket.rabbitmq
{
    public class ServiceProduct
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;
        public ServiceProduct(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task ProcessProduct(int productId)
        {
            var uri = new Uri("queue:product-queue");
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(uri);
            await endpoint.Send(new ProcessProduct
            {
                ProductId = productId,
            });
        }
    }
}
