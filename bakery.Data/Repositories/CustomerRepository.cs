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

        public List<Customer> GetAll() => _dbSet.Include(c=>c.Orders).ToList();

        public Customer GetById(int id) =>
            _dbSet.Include(c=>c.Orders).FirstOrDefault(c => c.Id == id);

        public void Add(Customer customer)
        {
           
            _dbSet.Add(customer);
        }

        public void Update(int id, Customer customer)
        {
            var existing = GetById(id);
            if (existing == null) return;

            existing.Name = customer.Name;
            existing.Phone = customer.Phone;
        }

        public void Delete(int id)
        {
            var customer = GetById(id);
            if (customer != null)
                _dbSet.Remove(customer);
        }
        public List<Orders> GetOrdersForCustomer(int id)
        {
            return _context.Orders.Where(o => o.CustomerId == id).Include(o=>o.Customer).Include(o=>o.Product).ToList();
        }
    }
}
