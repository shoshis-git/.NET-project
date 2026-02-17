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
        public List<Customer> GetAll();
        public Customer GetById(int id);
        public void Add(Customer customer);
        public void Update(int id, Customer customer);
        public void Delete(int id);
        public List<Orders> GetOrdersForCustomer(int id);

    }
}
