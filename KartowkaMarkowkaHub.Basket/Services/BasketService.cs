using KartowkaMarkowkaHub.Basket.ViewModels;
using KartowkaMarkowkaHub.Services.rabbitmq;
using MassTransit;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace KartowkaMarkowkaHub.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly IDistributedCache _cache;
        private readonly IRequestClient<ProductsRequest> _requestClient;

        public BasketService(IDistributedCache cache, IRequestClient<ProductsRequest> requestClient)
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

            ProductsRequest processProduct = new ProductsRequest { ProductIdList = savedProduct.ProductIdList };
            var response = await _requestClient.GetResponse<ProductsResponse>(processProduct);
            if (response is null)
                return new BasketViewModel();

            var products = response.Message.Products
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                });

            return new BasketViewModel { Products = products };
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
                        savedProduct.ProductIdList.Add(productId);
                        basketText = JsonSerializer.Serialize(savedProduct);
                    }
                }
            }

            await _cache.SetStringAsync(userId.ToString(), basketText);
        }  

        public async Task Remove(Guid productId, Guid userId)
        {
            string? basketText = await _cache.GetStringAsync(userId.ToString()) ?? "";

            if(basketText != null)
            {
                BasketDto? savedProduct = JsonSerializer.Deserialize<BasketDto>(basketText);

                if (savedProduct is not null)
                {
                    if (savedProduct.ProductIdList.Contains(productId))
                    {
                        savedProduct.ProductIdList.Remove(productId);
                        basketText = JsonSerializer.Serialize(savedProduct);
                        await _cache.SetStringAsync(userId.ToString(), basketText);
                    }
                }
            }
        }
    }
}