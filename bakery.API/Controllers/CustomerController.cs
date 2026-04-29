using bakery.Services;
using bakery.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using bakery.Core.Service;
using bakery.API.Models;
using bakery.Core.DTOs;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bakery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public ActionResult Get()
        {
            var list = _customerService.GetAll();
            var listDTO = _mapper.Map<List<CustomerDto>>(list);
            return Ok(listDTO);
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            var customer = _customerService.GetById(id);
            if (customer == null) return NotFound();
            var customerDTO = _mapper.Map<CustomerDto>(customer);
            return Ok(customerDTO);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public ActionResult Post([FromBody] CustomerPostModel c)
        {
           var customer = new Customer
            {
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone
            };
            _customerService.Add(customer);
            return Ok();
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CustomerPostModel c)
        {
            var customer=new Customer
            {
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone
            };
            _customerService.Update(id, customer);
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
            var orders = _customerService.GetOrdersForCustomer(id);
            var orderDTO = _mapper.Map<List<OrderDTO>>(orders);
            return Ok(orderDTO);
        }
    }
}