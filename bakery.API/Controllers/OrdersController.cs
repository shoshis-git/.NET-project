using AutoMapper;
using bakery.API.Models;
using bakery.Core.DTOs;
using bakery.Core.Entities;
using bakery.Core.Service;
using bakery.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bakery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _service;
        private readonly IMapper _mapper;

        public OrdersController(IOrdersService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list = await _service.GetAllAsync();
            var listDTO = _mapper.Map<List<OrderDTO>>(list);
            return Ok(listDTO);
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var order =await _service.GetByIdAsync(id);
            if (order == null) return NotFound();
            var orderDTO = _mapper.Map<OrderDTO>(order);
            return Ok(orderDTO);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OrdersPostModel o)
        {
            var order = new Orders
            {
                ProductId = o.ProductId,
                CustomerId = o.CustomerId,
                Status=EnumStatuses.Invating
            };
            await _service.AddAsync(order);
            return Ok();
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] OrdersPutModel o)
        {
            var order = new Orders
            {
                ProductId = o.ProductId,
                CustomerId = o.CustomerId,
                Status = o.Status
            };
            await _service.UpdateAsync(id, order);
            return Ok("The updated succefull");
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var customer= await _service.GetByIdAsync(id);
            if(customer == null) return NotFound();
           await _service.DeleteAsync(id);
            return Ok("The deleted success");
        }
        [HttpPut("{id}/status")]
        public async Task<ActionResult> UpdateStatus(int id, [FromBody] EnumStatuses status)
        {
          await _service.UpdateStatusAsync(id, status);
            return Ok("The status updated");
        }
    }

   
}
