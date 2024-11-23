using KartowkaMarkowkaHub.Data.Repositories;
using KartowkaMarkowkaHub.Services.Products;
using MassTransit;

namespace KartowkaMarkowkaHub.Services.rabbitmq
{
    public class ProcessProductConsumer: IConsumer<ProcessProduct>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProcessProductConsumer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<ProcessProduct> context)
        {
            Guid id = context.Message.ProductId;
            var product = _unitOfWork.ProductRepository.Get(p => p.Id == id).FirstOrDefault();
            if (product != null)
            {
                var productDto = new GetProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                };
                await context.RespondAsync(productDto);
            }
        }
    }
}
