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
        public static int nextId = 1;

        public OrdersController(IOrdersService service)
        {
            _service = service;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var order = _service.GetById(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public ActionResult Post([FromBody] Orders o)
        {
           _service.Add(o);
            return Ok(o);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Orders o)
        {
           _service.Update(id, o);
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
        public ActionResult UpdateStatus(int id, [FromBody] string status)
        {
           _service.UpdateStatus(id, status);
            return Ok("The status updated");
        }
    }

   
}
