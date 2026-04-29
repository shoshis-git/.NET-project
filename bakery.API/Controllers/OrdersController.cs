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
        public ActionResult Get()
        {
            var list = _service.GetAll();
            var listDTO = _mapper.Map<List<OrderDTO>>(list);
            return Ok(listDTO);
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var order = _service.GetById(id);
            if (order == null) return NotFound();
            var orderDTO = _mapper.Map<OrderDTO>(order);
            return Ok(orderDTO);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public ActionResult Post([FromBody] OrdersPostModel o)
        {
            var order = new Orders
            {
                ProductId = o.ProductId,
                CustomerId = o.CustomerId,
                Status=EnumStatuses.Invating
            };
            _service.Add(order);
            return Ok();
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] OrdersPutModel o)
        {
            var order = new Orders
            {
                ProductId = o.ProductId,
                CustomerId = o.CustomerId,
                Status = o.Status
            };
            _service.Update(id, order);
            return Ok("The updated succefull");
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var customer= _service.GetById(id);
            if(customer == null) return NotFound();
           _service.Delete(id);
            return Ok("The deleted success");
        }
        [HttpPut("{id}/status")]
        public ActionResult UpdateStatus(int id, [FromBody] EnumStatuses status)
        {
           _service.UpdateStatus(id, status);
            return Ok("The status updated");
        }
    }

   
}
