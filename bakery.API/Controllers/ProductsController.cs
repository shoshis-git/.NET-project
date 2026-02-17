using bakery.Core.Entities;
using bakery.Core.Service;
using bakery.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bakery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;


        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_productService.GetAll());
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var product = _productService.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public ActionResult Post([FromBody] Products p)
        {
           _productService.Add(p);
            return Ok();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Products p)
        {
           _productService.Update(id, p);
            return Ok("The updated is succesfully");
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = _productService.GetById(id);
            if (product == null) return NotFound();

            _productService.Delete(id);
            return Ok("The deleted succeed");
        }
        [HttpGet("category/{category}")]
        public ActionResult GetByCategory(string category)
        {
           
            return Ok(_productService.GetByCategory(category));
        }

    }
}
