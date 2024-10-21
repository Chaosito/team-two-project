using KartowkaMarkowkaHub.Application.Products.Commands.CreateProduct;
using KartowkaMarkowkaHub.Application.Products.Commands.DeleteProduct;
using KartowkaMarkowkaHub.Application.Products.Commands.UpdateProduct;
using KartowkaMarkowkaHub.Application.Products.Queries.GetAllProducts;
using KartowkaMarkowkaHub.Application.Products.Queries.GetUserProducts;
using KartowkaMarkowkaHub.Services.Products;
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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMediator _mediator;

        public ProductController(IProductService productService, IMediator mediator) 
        {
            _productService = productService;
            _mediator = mediator;
        }

        /// <summary>
        /// Получает товары фермера
        /// </summary>
        /// <param name="userId">id фермера</param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(Guid userId, CancellationToken cancellationToken)
        {
            var products = await _mediator.Send(new GetUserProductsQuery { UserId = userId }, cancellationToken);
            return Ok(products);
        }

        /// <summary>
        /// Получает все товары
        /// </summary>
        /// <returns></returns> 
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var products = await _mediator.Send(new GetAllProductsQuery(), cancellationToken);
            return Ok(products);
        }

        /// <summary>
        /// Создаёт товар
        /// </summary>
        /// <param name="createProductRequest">модель товара</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest createProductRequest, CancellationToken cancellationToken)
        {
            var claimUserId = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(claimUserId.Value);

            Guid productId = await _mediator.Send(new CreateProductCommand
            {
                Name = createProductRequest.Name,
                Price = createProductRequest.Price,
                UserId = userId,
            }, cancellationToken);
            return Created();
        }

        /// <summary>
        /// Обновляет товар
        /// </summary>
        /// <param name="updateProductRequest">модель товара</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductRequest updateProductRequest, CancellationToken cancellationToken)
        {
            bool result = await _mediator.Send(new UpdateProductCommand
            {
                Id = updateProductRequest.Id,
                Name = updateProductRequest.Name,
                Price = updateProductRequest.Price,
            }, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Удаляет товар
        /// </summary>
        /// <param name="productId">id товара</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Remove(Guid productId, CancellationToken cancellationToken)
        {
            bool result = await _mediator.Send(new DeleteProductCommand { Id = productId }, cancellationToken);

            return Ok(result);
        }
    }
}