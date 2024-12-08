using KartowkaMarkowkaHub.Basket.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KartowkaMarkowkaHub.Basket.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

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
            string userIdText = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            Guid userId = Guid.Parse(userIdText);
            var result = await _basketService.Get(userId);
            return Ok(result);
        }

        /// <summary>
        /// Добавляет продукт в корзину
        /// </summary>
        /// <param name="productId">id продукта</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BasketRequest basketRequest)
        {
            string userIdText = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;

            if (userIdText == string.Empty)
                return BadRequest();

            Guid userId = Guid.Parse(userIdText);
            await _basketService.Create(basketRequest.ProductId, userId);
            return Created();
        }

        /// <summary>
        /// Удаляет продукт из корзины
        /// </summary>
        /// <param name="productId">id продукта</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] BasketRequest basketRequest)
        {
            string userIdText = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;

            if (userIdText == string.Empty)
                return BadRequest();

            Guid userId = Guid.Parse(userIdText);
            await _basketService.Remove(basketRequest.ProductId, userId);
            return Ok();
        }
    }
}