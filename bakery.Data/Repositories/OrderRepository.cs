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
    public class OrdersRepository:Repository<Orders>,IOrderRepository
    {
        

        public OrdersRepository(DataContext context):base(context)
        {
           
        }

        public async Task<IEnumerable<Orders>> GetAllAsync() => await _dbSet.Include(o=>o.Product).Include(o=>o.Customer).ToListAsync();

        public async Task<Orders> GetByIdAsync(int id) =>
            await _dbSet
            .Include(o=>o.Customer)
            .Include(o=>o.Product)
            .FirstOrDefaultAsync(o => o.Id == id);

        public void Add(Orders order)
        {
            _dbSet.Add(order);
        }

        public async Task UpdateAsync(int id, Orders order)
        {
            var existing = await GetByIdAsync(id);
            if (existing == null) return;

            existing.ProductId = order.ProductId;
            existing.CustomerId = order.CustomerId;
            existing.Status = order.Status;
        }

        public async Task DeleteAsync(int id)
        {
            var order = await GetByIdAsync(id);
            if (order != null)
                _dbSet.Remove(order);
        }

        public async Task UpdateStatusAsync(int id, EnumStatuses status)
        {
            var order =await GetByIdAsync(id);
            if (order != null)
                 order.Status = status;
        }

        public async Task<IEnumerable<Orders>> GetByCustomerAsync(int customerId) =>
            await _context.Orders.Where(o => o.CustomerId == customerId).Include(o=>o.Customer).Include(o=>o.Product).ToListAsync();
    }
}
