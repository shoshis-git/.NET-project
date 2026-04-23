using bakery.Services;
using bakery.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using bakery.Core.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bakery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;


        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_customerService.GetAll());
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var customer = _customerService.GetById(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public ActionResult Post([FromBody] Customer c)
        {
           
            _customerService.Add(c);
            return Ok();
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Customer c)
        {
           _customerService.Update(id, c);
            return Ok("The update is success");
        }
   

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var customer = _customerService.GetById;
            if (customer == null) return NotFound();
            _customerService.Delete(id);
            return Ok("The deleted is succeed");
        }
        [HttpGet("{id}/orders")]
        public ActionResult GetOrdersForCustomer(int id)
        {
          

            return Ok(_customerService.GetOrdersForCustomer(id));
        }
    }
}