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
        private readonly IRepositoryManager _repoManager;

        public CustomerService(IRepositoryManager repoManager)
        {
            _repoManager = repoManager;
        }

        public List<Customer> GetAll() => _repoManager.Customers.GetAll();

        public Customer GetById(int id) =>
           _repoManager.Customers.GetById(id);

        public void Add(Customer customer)
        {
           _repoManager.Customers.Add(customer);
            _repoManager.Save();
        }

        public void Update(int id, Customer customer)
        {
           _repoManager.Customers.Update(id, customer);
           _repoManager.Save();
        }

        public void Delete(int id)
        {
           _repoManager.Customers.Delete(id);
            _repoManager.Save();
        }
        public List<Orders> GetOrdersForCustomer(int id)=>_repoManager.Customers.GetOrdersForCustomer(id);
        
            
        
    }
}
