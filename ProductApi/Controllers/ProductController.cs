using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using System.Reflection.Metadata.Ecma335;


namespace ProductApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {

            var products = new List<Product>()
            {
            new Product(){Id=1,Name="Bilgisayar"},
            new Product(){Id=2,Name="Telefon"},
            new Product(){Id=3,Name="Mouse"}

             };
            _logger.LogInformation("GetAllProducts action has been called");
            return Ok(products);

        }
        [HttpPost]
        public IActionResult GetAllProducts([FromBody] Product product)
        {

            _logger.LogWarning("Product has been created");
            return Ok(product);

        }
    }
}