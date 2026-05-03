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

        public async Task<IEnumerable<Customer>> GetAllAsync() => await _repoManager.Customers.GetAllAsync();

        public async Task<Customer> GetByIdAsync(int id) =>
           await _repoManager.Customers.GetByIdAsync(id);

        public async Task AddAsync(Customer customer)
        {
           _repoManager.Customers.Add(customer);
            await _repoManager.SaveAsync();
        }

        public async Task UpdateAsync(int id, Customer customer)
        {
           await _repoManager.Customers.UpdateAsync(id, customer);
           await _repoManager.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
           await _repoManager.Customers.DeleteAsync(id);
            await _repoManager.SaveAsync();
        }
        public async Task<List<Orders>> GetOrdersForCustomerAsync(int id) => await _repoManager.Customers.GetOrdersForCustomerAsync(id);
        
            
        
    }
}
