using KartowkaMarkowkaHub.Services.Products;
using KartowkaMarkowkaHub.Services.rabbitmq;
using MassTransit;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace KartowkaMarkowkaHub.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly IDistributedCache _cache;
        private readonly IRequestClient<ProcessProduct> _requestClient;

        public BasketService(IDistributedCache cache, IRequestClient<ProcessProduct> requestClient)
        {
            _cache = cache;
            _requestClient = requestClient;
        }

        public async Task<BasketViewModel> Get(Guid userId)
        {
            string? basketText = await _cache.GetStringAsync(userId.ToString()) ?? "";

            if (string.IsNullOrWhiteSpace(basketText))
                return new BasketViewModel();

            BasketDto? savedProduct = JsonSerializer.Deserialize<BasketDto>(basketText);

            if (savedProduct is null)
                return new BasketViewModel();

            Guid productId = savedProduct.ProductIdList.FirstOrDefault();

            var productData = await _requestClient.GetResponse<GetProductDto>(new ProcessProduct { ProductId = productId });
            if (productData is null)
                return new BasketViewModel();

            return new BasketViewModel { Id = Guid.NewGuid(), ProductId = productId, ProductName = productData.Message.Name };
        }

        public async Task Create(Guid productId, Guid userId)
        {
            string? basketText = await _cache.GetStringAsync(userId.ToString()) ?? "";
            BasketDto? savedProduct = null;

            if (string.IsNullOrEmpty(basketText))
            {
                BasketDto savedProducts = new()
                {
                    UserId = userId,
                    ProductIdList = [productId],
                };
                basketText = JsonSerializer.Serialize(savedProducts);               
            }
            else
            {
                savedProduct = JsonSerializer.Deserialize<BasketDto>(basketText);

                if (savedProduct is not null)
                {
                    if (!savedProduct.ProductIdList.Contains(productId))
                    {
                        savedProduct.ProductIdList.ToList().Add(productId);
                        basketText = JsonSerializer.Serialize(savedProduct);
                    }
                }
            }

            await _cache.SetStringAsync(userId.ToString(), basketText);
        }  

        public void Remove(Guid productId)
        {
            throw new NotImplementedException();
        }
    }
}