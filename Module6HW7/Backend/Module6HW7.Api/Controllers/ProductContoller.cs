using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module6HW7.Core.Interfaces;
using Module6HW7.Core.Entity;
namespace Module6HW7.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAllAsync().Result;
            return Json(products);
        }


        [HttpDelete("DeletePage/{id}")]
        public IActionResult DeletePage([FromRoute] int id)
        {
            _productService.ProductDeleteAsync(id).Wait();
            return Json(id);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _productService.ProductAddAsync(product).Wait();
            return Json(product);
        }


        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            _productService.ProductUpdateAsync(product).Wait();
            return Json(product);
        }
    }
}