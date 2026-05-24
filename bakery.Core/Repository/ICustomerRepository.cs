using bakery.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakery.Core.Repository
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<Customer>> GetAllAsync();
        public Task<Customer>GetByIdAsync(int id);
        public void Add(Customer customer);
        public Task UpdateAsync(int id, Customer customer);
        public Task DeleteAsync(int id);
        public  Task<Customer> GetByNameAndEmailAsync(string name,string email);
        public Task<List<Orders>> GetOrdersForCustomerAsync(int id);

    }
}
