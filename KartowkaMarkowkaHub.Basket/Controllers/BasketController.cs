using KartowkaMarkowkaHub.Basket.Services;
using Microsoft.AspNetCore.Mvc;

namespace KartowkaMarkowkaHub.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly Guid _userId = Guid.Parse("6ebc929b-3785-49d9-9d46-b3b9f70b0bb5");//извлекать из токена аутентификации

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        /// <summary>
        /// Получает все продукты из корзины для клиента
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _basketService.Get(_userId);
            return Ok(result);
        }

        /// <summary>
        /// Добавляет продукт в корзину
        /// </summary>
        /// <param name="productId">id продукта</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Guid productId)
        {
            await _basketService.Create(productId, _userId);
            return Created();
        }

        /// <summary>
        /// Удаляет продукт из корзины
        /// </summary>
        /// <param name="productId">id продукта</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid productId)
        {
            await _basketService.Remove(productId, _userId);
            return Ok();
        }
    }
}