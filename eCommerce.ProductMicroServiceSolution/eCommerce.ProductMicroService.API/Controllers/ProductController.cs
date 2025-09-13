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
    }

}
