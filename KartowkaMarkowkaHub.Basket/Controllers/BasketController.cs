﻿using KartowkaMarkowkaHub.Basket.Services;
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
        public IActionResult Get()
        {
            return Ok(_basketService.Get(_userId));
        }

        /// <summary>
        /// Добавляет продукт в корзину
        /// </summary>
        /// <param name="productId">id продукта</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Guid productId)
        {
            _basketService.Create(productId, _userId);
            return Created();
        }

        /// <summary>
        /// Удаляет продукт из корзины
        /// </summary>
        /// <param name="productId">id продукта</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid productId)
        {
            _basketService.Remove(productId);
            return Ok();
        }
    }
}