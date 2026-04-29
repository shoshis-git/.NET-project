using AutoMapper;
using bakery.API.Models;
using bakery.Core.DTOs;
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
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult Get()
        {
            var list= _productService.GetAll();
            var listDTO = _mapper.Map<List<ProductDTO>>(list);
            return Ok(listDTO);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var product = _productService.GetById(id);
            if (product == null) return NotFound();
            var productDTO = _mapper.Map<ProductDTO>(product);
            return Ok(productDTO);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public ActionResult Post([FromBody] ProductsPostModel p)
        {
            var product = new Products
            {
                Name = p.Name,
                Price = p.Price
            };
            _productService.Add(product);
            return Ok();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ProductsPostModel p)
        {
            var product =new Products
            {
                Name = p.Name,
                Price = p.Price
            };
            _productService.Update(id, product);
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
       
   

    }
}
