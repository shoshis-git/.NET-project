using bakery.Core.Entities;
using bakery.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakery.Data.Repositories
{
    public class CustomerRepository: Repository<Customer>, ICustomerRepository
    {
      
        public CustomerRepository(DataContext context):base(context)
        {
           
        }   

        public async Task<IEnumerable<Customer>> GetAllAsync() => await  _dbSet.Include(c=>c.Orders).ToListAsync();

        public async Task<Customer> GetByIdAsync(int id) =>
            await _dbSet.Include(c=>c.Orders).FirstOrDefaultAsync(c => c.Id == id);

        public void Add(Customer customer)
        {
           
            _dbSet.Add(customer);
        }

        public async Task UpdateAsync(int id, Customer customer)
        {
            var existing = await GetByIdAsync(id);
            if (existing == null) return;

            existing.Name = customer.Name;
            existing.Phone = customer.Phone;
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await GetByIdAsync(id);
            if (customer != null)
                _dbSet.Remove(customer);
        }
        public async Task<Customer> GetByNameAndEmailAsync(string name,string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u =>u.Name==name && u.Email == email);
        }
        public async Task<List<Orders>> GetOrdersForCustomerAsync(int id)
        {
            return await _context.Orders.Where(o => o.CustomerId == id).Include(o=>o.Customer).Include(o=>o.Product).ToListAsync();
        }
    }
}
