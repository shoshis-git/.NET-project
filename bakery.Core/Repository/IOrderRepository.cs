using bakery.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakery.Core.Repository
{
    public interface IOrderRepository
    {
        public Task< IEnumerable<Orders>> GetAllAsync();
        public Task<Orders> GetByIdAsync(int id);
        public void Add(Orders order);
        public Task UpdateAsync(int id, Orders order);
        public Task DeleteAsync(int id);
        public Task UpdateStatusAsync(int id, EnumStatuses status);
        public Task<IEnumerable<Orders>> GetByCustomerAsync(int customerId);
    }
}
