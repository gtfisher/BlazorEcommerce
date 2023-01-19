using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService  productService)
        {

            _productService = productService;

        }
        

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            var result = await _productService.GetProductsAsync();
            return Ok(result);
        }

        [HttpGet("{prodcutId}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int prodcutId)
        {
            var result = await _productService.GetProductAsync(prodcutId);
            return Ok(result);
        }
    }
}
