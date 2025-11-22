using Microsoft.AspNetCore.Mvc;
using UnitOfWorkAndxUnit.Domain.Entities;
using UnitOfWorkAndxUnit.Application.Interfaces;

namespace UnitOfWorkAndxUnit.Api.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Product product)
        {
            await _productService.AddProductAsync(product);
            return Ok(product);
        }

        [HttpGet("expensive/{minPrice}")]
        public async Task<IActionResult> GetExpensive(decimal minPrice)
        {
            var products = await _productService.GetExpensiveProductsAsync(minPrice);
            return Ok(products);
        }
    }
}
