
using KartowkaMarkowkaHub.Basket.rabbitmq;
using KartowkaMarkowkaHub.Basket.ViewModels;
using MassTransit;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace KartowkaMarkowkaHub.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly IDistributedCache _cache;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ServiceProduct _serviceProduct;

        public BasketService(IDistributedCache cache, IHttpClientFactory httpClientFactory, ISendEndpointProvider sendEndpointProvider)
        {
            _cache = cache;
            _httpClientFactory = httpClientFactory;
            _serviceProduct = new ServiceProduct(sendEndpointProvider);
        }

        public async Task<BasketViewModel> Get(Guid userId)
        {
            string? basketText = await _cache.GetStringAsync(userId.ToString()) ?? "";

            if (string.IsNullOrWhiteSpace(basketText))
                return new BasketViewModel();

            BasketDto? savedProduct = JsonSerializer.Deserialize<BasketDto>(basketText);

            if (savedProduct is null)
                return new BasketViewModel();

            using var client = _httpClientFactory.CreateClient();
            var result = await client.GetFromJsonAsync<IEnumerable<ProductViewModel>>("https://localhost:8088/api/Product", new JsonSerializerOptions(JsonSerializerDefaults.Web));
            var product = result?.FirstOrDefault(x => savedProduct.ProductIdList.Contains(x.Id));
            if (product is null)
                return new BasketViewModel();
            return new BasketViewModel { Id = Guid.NewGuid(), ProductId = product.Id, ProductName = product.Name };
        }

        public async Task Create(Guid productId, Guid userId)
        {
            await _serviceProduct.ProcessProduct(productId);
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