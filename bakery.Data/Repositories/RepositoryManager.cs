using bakery.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakery.Data.Repositories
{
    public class RepositoryManager: IRepositoryManager
    {
        private readonly DataContext _context;
        public ICustomerRepository Customers { get; }
        public IOrderRepository Orders { get; }
        public IProductRepository Products {get; }
        public RepositoryManager(DataContext context,ICustomerRepository customerRepository,IProductRepository productRepository,IOrderRepository orderRepository)
        {
            _context = context;
            Customers = customerRepository;
            Orders = orderRepository;
            Products = productRepository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
