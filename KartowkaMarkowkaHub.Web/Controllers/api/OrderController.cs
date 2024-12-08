using KartowkaMarkowkaHub.Application.Orders.Commands.CreateOrder;
using KartowkaMarkowkaHub.Application.Orders.Commands.RemoveOrder;
using KartowkaMarkowkaHub.Application.Orders.Commands.UpdateOrder;
using KartowkaMarkowkaHub.Application.Orders.Commands.UpdateOrderStatus;
using KartowkaMarkowkaHub.Application.Orders.Queries.GetAllOrders;
using KartowkaMarkowkaHub.Application.Orders.Queries.GetOrderStatus;
using KartowkaMarkowkaHub.Application.Orders.Queries.GetUserOrders;
using KartowkaMarkowkaHub.Services.Orders;
using KartowkaMarkowkaHub.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KartowkaMarkowkaHub.Web.Controllers.api
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService, IMediator mediator) : ControllerBase
    {
        private readonly IOrderService _orderService = orderService;
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Получает заказы клиента
        /// </summary>
        /// <param name="userId">id клиента</param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(Guid userId, CancellationToken cancellationToken)
        {
            var orders = await _mediator.Send(new GetUserOrdersQuery { UserId = userId }, cancellationToken);
            return Ok(orders);
        }

        /// <summary>
        /// Получает все заказы
        /// </summary>
        /// <returns></returns> 
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery(), cancellationToken);
            return Ok(orders);
        }

        /// <summary>
        /// Создаёт заказ
        /// </summary>
        /// <param name="createOrderRequest">модель заказа</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderRequest createOrderRequest, CancellationToken cancellationToken)
        {
            var claimUserId = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(claimUserId.Value);

            Guid productId = await _mediator.Send(new CreateOrderCommand
            {
                Number = createOrderRequest.Number,
                ProductId = createOrderRequest.ProductId,
                UserId = userId,
            }, cancellationToken);

            return Created();
        }

        /// <summary>
        /// Обновляет заказ
        /// </summary>
        /// <param name="updateOrderRequest">модель заказа</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderRequest updateOrderRequest, CancellationToken cancellationToken)
        {
            bool result = await _mediator.Send(new UpdateOrderCommand
            {
                Id = updateOrderRequest.Id,
                OrderStatusId = updateOrderRequest.OrderStatusId,
                ProductId= updateOrderRequest.ProductId,
            }, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Удаляет заказ
        /// </summary>
        /// <param name="orderId">id заказа</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Remove(Guid orderId, CancellationToken cancellationToken)
        {
            bool result = await _mediator.Send(new DeleteOrderCommand { Id = orderId }, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Название текущего статуса заказа
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpGet("GetStatus/{orderId}")]
        public async Task<IActionResult> GetStatus(Guid orderId, CancellationToken cancellationToken) 
        {
            string name = await _mediator.Send(new GetOrderStatusQuery { OrderId = orderId }, cancellationToken);

            return Ok(name);
        }

        /// <summary>
        /// Переключить статус заказа
        /// </summary>
        /// <param name="orderStatusRequest">id заказа</param>
        /// <returns></returns>
        [HttpPut, Route("UpdateStatus")]
        public async Task<IActionResult> UpdateStatus([FromBody] OrderStatusRequest orderStatusRequest, CancellationToken cancellationToken)
        {
            bool result = await _mediator.Send(new UpdateOrderStatusCommand { OrderId = orderStatusRequest.OrderId }, cancellationToken);

            return Ok(result);
        }
    }
}
