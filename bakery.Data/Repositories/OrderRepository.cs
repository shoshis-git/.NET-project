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

        public List<Orders> GetList() => _dbSet.Include(o=>o.Product).Include(o=>o.Customer).ToList();

        public Orders GetById(int id) =>
            _dbSet
            .Include(o=>o.Customer)
            .Include(o=>o.Product)
            .FirstOrDefault(o => o.Id == id);

        public void Add(Orders order)
        {
            _dbSet.Add(order);
        }

        public void Update(int id, Orders order)
        {
            var existing = GetById(id);
            if (existing == null) return;

            existing.ProductId = order.ProductId;
            existing.CustomerId = order.CustomerId;
            existing.Status = order.Status;
        }

        public void Delete(int id)
        {
            var order = GetById(id);
            if (order != null)
                _dbSet.Remove(order);
        }

        public void UpdateStatus(int id, EnumStatuses status)
        {
            var order = GetById(id);
            if (order != null)
                order.Status = status;
        }

        public List<Orders> GetByCustomer(int customerId) =>
            _context.Orders.Where(o => o.CustomerId == customerId).Include(o=>o.Customer).Include(o=>o.Product).ToList();
    }
}
