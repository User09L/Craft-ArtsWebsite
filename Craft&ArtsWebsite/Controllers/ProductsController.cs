using Craft_ArtsWebsite.Model;
using Craft_ArtsWebsite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Craft_ArtsWebsite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }
        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get() => ProductService.GetProducts();

        //[HttpPatch] "[FromBody]'
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get([FromQuery]string ProductID,[FromQuery] int rating)
        {
            ProductService.AddRating(ProductID, rating);
            return Ok();
        }

    }
}
