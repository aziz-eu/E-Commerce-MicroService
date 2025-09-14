using eCommerce.ProductMicroService.API.Entities;
using eCommerce.ProductMicroService.API.Services;
using eCommerce.ProductMicroService.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.ProductMicroService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productsServices;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, IProductService productsServices)
        {
            _logger = logger;
            _productsServices = productsServices;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productsServices.GetAllProductsAsync();
            return Ok(products);
        }


        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var products = await _productsServices.GetProductByIdAsync(id);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> SaveProducts(Product product)
        {
            if (product == null)
            {
                return BadRequest("Invalid Input");
            }
            await _productsServices.CreateProductAsync(product);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(Product product, int id)
        {
            if(product.Id != id || product == null)
            {
                return BadRequest("Invalid Input");
            }
            await _productsServices.UpdateProductAsync(product);
            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productsServices.DeleteProductAsync(id);
            return NoContent();
        }

    }

}
