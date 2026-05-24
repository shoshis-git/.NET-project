using AutoMapper;
using bakery.API.Models;
using bakery.Core.DTOs;
using bakery.Core.Entities;
using bakery.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bakery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        public async Task<ActionResult> Get()
        {
            var list= await _productService.GetAllAsync();
            var listDTO = _mapper.Map<List<ProductDTO>>(list);
            return Ok(listDTO);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null) return NotFound();
            var productDTO = _mapper.Map<ProductDTO>(product);
            return Ok(productDTO);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductsPostModel p)
        {
            var product = new Products
            {
                Name = p.Name,
                Price = p.Price
            };
            await _productService.AddAsync(product);
            return Ok();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductsPostModel p)
        {
            var product =new Products
            {
                Name = p.Name,
                Price = p.Price
            };
           await _productService.UpdateAsync(id, product);
            return Ok("The updated is succesfully");
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null) return NotFound();

            await _productService.DeleteAsync(id);
            return Ok("The deleted succeed");
        }
       
   

    }
}
