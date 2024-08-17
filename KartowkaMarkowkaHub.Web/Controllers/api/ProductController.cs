using KartowkaMarkowkaHub.Services.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KartowkaMarkowkaHub.Web.Controllers.api
{
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
        /// <param name="farmerId">id фермера</param>
        /// <returns></returns>
        [HttpGet("{farmerId}")]
        public IActionResult GetAsync(Guid farmerId)
        {
            var products = _productService.GetAsync(farmerId);
            return Ok(products);
        }

        /// <summary>
        /// Получает все товары
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAsync()
        {
            var products = _productService.GetAsync();
            return Ok(products);
        }

        /// <summary>
        /// Создаёт товар
        /// </summary>
        /// <param name="productDto">модель товара</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAsync(ProductDto productDto)
        {
            var claim = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
            var id = claim.Value;
            Guid guid = Guid.Parse(id);
            await _productService.CreateAsync(productDto);
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
