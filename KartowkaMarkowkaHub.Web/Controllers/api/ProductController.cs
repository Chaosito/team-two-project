using KartowkaMarkowkaHub.Services.Products;
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

        public ProductController(IProductService productService) 
        {
            _productService = productService;
        }

        /// <summary>
        /// Получает товары фермера
        /// </summary>
        /// <param name="userId">id фермера</param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public IActionResult Get(Guid userId)
        {
            var products = _productService.Get(userId);
            return Ok(products);
        }

        /// <summary>
        /// Получает все товары
        /// </summary>
        /// <returns></returns> 
        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.Get();
            return Ok(products);
        }

        /// <summary>
        /// Создаёт товар
        /// </summary>
        /// <param name="productDto">модель товара</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(ProductDto productDto)
        {
            var claimUserId = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(claimUserId.Value);            
            _productService.Create(productDto, userId);
            return Created();
        }

        /// <summary>
        /// Обновляет товар
        /// </summary>
        /// <param name="productId">id товара</param>
        /// <param name="productDto">модель товара</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(Guid productId, ProductDto productDto)
        {
            _productService.Update(productId, productDto);
            return Ok();
        }

        /// <summary>
        /// Удаляет товар
        /// </summary>
        /// <param name="productId">id товара</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Remove(Guid productId)
        {
            _productService.Remove(productId);
            return Ok();
        }
    }
}