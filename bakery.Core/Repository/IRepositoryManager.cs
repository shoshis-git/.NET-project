using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakery.Core.Repository
{
    public interface IRepositoryManager
    {
        ICustomerRepository Customers { get; }
            IOrderRepository Orders { get; }
            IProductRepository Products { get; }
            Task SaveAsync();
    }
}
