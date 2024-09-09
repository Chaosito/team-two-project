using KartowkaMarkowkaHub.Services.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KartowkaMarkowkaHub.Web.Controllers.api
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        private readonly IOrderService _orderService = orderService;

        /// <summary>
        /// Получает заказы клиента
        /// </summary>
        /// <param name="userId">id клиента</param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public IActionResult Get(Guid userId)
        {
            var orders = _orderService.Get(userId);
            return Ok(orders);
        }

        /// <summary>
        /// Получает все заказы
        /// </summary>
        /// <returns></returns> 
        [HttpGet]
        public IActionResult Get()
        {
            var orders = _orderService.Get();
            return Ok(orders);
        }

        /// <summary>
        /// Создаёт заказ
        /// </summary>
        /// <param name="orderCreateRequest">модель заказа</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(OrderCreateRequest orderCreateRequest)
        {
            var claimUserId = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(claimUserId.Value);
            _orderService.Create(orderCreateRequest, userId);
            return Created();
        }

        /// <summary>
        /// Обновляет заказ
        /// </summary>
        /// <param name="orderId">id заказа</param>
        /// <param name="orderUpdateRequest">модель заказа</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(Guid orderId, OrderUpdateRequest orderUpdateRequest)
        {
            _orderService.Update(orderId, orderUpdateRequest);
            return Ok();
        }

        /// <summary>
        /// Удаляет заказ
        /// </summary>
        /// <param name="orderId">id заказа</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Remove(Guid orderId)
        {
            _orderService.Remove(orderId);
            return Ok();
        }

        /// <summary>
        /// Название текущего статуса заказа
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpGet("{orderId}")]
        public ActionResult GetStatus(Guid orderId) 
        {            
            return Ok(_orderService.GetStatusName(orderId));
        }

        /// <summary>
        /// Переключить статус заказа
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpPut, Route("UpdateStatus")]
        public IActionResult UpdateStatus([FromBody] Guid orderId)
        {
            _orderService.SetNextStatus(orderId);
            return Ok();
        }
    }
}
