using bakery.Core.Entities;
using bakery.Core.Repository;
using bakery.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakery.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> GetAll() => _customerRepository.GetAll();

        public Customer GetById(int id) =>
           _customerRepository.GetById(id);

        public void Add(Customer customer)
        {
           _customerRepository.Add(customer);
        }

        public void Update(int id, Customer customer)
        {
           _customerRepository.Update(id, customer);
        }

        public void Delete(int id)
        {
           _customerRepository.Delete(id);
        }
        public List<Orders> GetOrdersForCustomer(int id)=>_customerRepository.GetOrdersForCustomer(id);
        
            
        
    }
}
