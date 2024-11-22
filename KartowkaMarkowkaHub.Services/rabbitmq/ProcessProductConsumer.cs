using MassTransit;

namespace KartowkaMarkowkaHub.Services.rabbitmq
{
    public class ProcessProductConsumer: IConsumer<ProcessProduct>
    {
        public async Task Consume(ConsumeContext<ProcessProduct> context)
        {
            Guid id = context.Message.ProductId;
            Console.WriteLine($"Product id: {id}");
        }
    }
}
