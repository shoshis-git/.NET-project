using bakery.Core.Entities;
using bakery.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakery.Data.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public List<Customer> GetAll() => _context.Customers.ToList();

        public Customer GetById(int id) =>
            _context.Customers.FirstOrDefault(c => c.Id == id);

        public void Add(Customer customer)
        {
            customer.Id = _context.Customers.ToList().Count == 0
                ? 1
                : _context.Customers.Max(c => c.Id) + 1;

            _context.Customers.Add(customer);
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
                _context.Customers.Remove(customer);
        }
        public List<Orders> GetOrdersForCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);

            var ordersForCustomer = _context.Orders
                .Where(o => o.CustomerId == id)
                .ToList();
            return ordersForCustomer;
        }
    }
}
