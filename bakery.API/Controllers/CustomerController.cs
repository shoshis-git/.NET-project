
using bakery.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using bakery.Core.Service;
using bakery.API.Models;
using bakery.Core.DTOs;
using AutoMapper;
using System.Threading.Tasks;

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
        public async Task<ActionResult> Get()
        {
            var list = await _customerService.GetAllAsync();
            var listDTO = _mapper.Map<IEnumerable<CustomerDto>>(list);
            return Ok(listDTO);
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {

            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null) return NotFound();
            var customerDTO = _mapper.Map<CustomerDto>(customer);
            return Ok(customerDTO);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CustomerPostModel c)
        {
           var customer = new Customer
            {
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone
            };
            await _customerService.AddAsync(customer);
            return Ok();
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CustomerPostModel c)
        {
            var customer=new Customer
            {
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone
            };
            await _customerService.UpdateAsync(id, customer);
            return Ok("The update is success");
        }
   

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null) return NotFound();
            await _customerService.DeleteAsync(id);
            return Ok("The deleted is succeed");
        }
        [HttpGet("{id}/orders")]
        public async Task<ActionResult> GetOrdersForCustomer(int id)
        {
            var orders =  await _customerService.GetOrdersForCustomerAsync(id);
            var orderDTO = _mapper.Map<List<OrderDTO>>(orders);
            return Ok(orderDTO);
        }
    }
}