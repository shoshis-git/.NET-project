using bakery.Core.Entities;
using bakery.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakery.Data.Repositories
{
    public class OrdersRepository:IOrderRepository
    {
        private readonly DataContext _context;

        public OrdersRepository(DataContext context)
        {
            _context = context;
        }

        public List<Orders> GetList() => _context.Orders.ToList();

        public Orders GetById(int id) =>
            _context.Orders.FirstOrDefault(o => o.Id == id);

        public void Add(Orders order)
        {
            order.Id = _context.Orders.ToList().Count == 0 ? 1 : _context.Orders.Max(o => o.Id) + 1;
            _context.Orders.Add(order);
        }

        public void Update(int id, Orders order)
        {
            var existing = GetById(id);
            if (existing == null) return;

            existing.ProductId = order.ProductId;
            existing.CustomerId = order.CustomerId;
            existing.ProductName = order.ProductName;
            existing.Status = order.Status;
        }

        public void Delete(int id)
        {
            var order = GetById(id);
            if (order != null)
                _context.Orders.Remove(order);
        }

        public void UpdateStatus(int id, string status)
        {
            var order = GetById(id);
            if (order != null)
                order.Status = status;
        }

        public List<Orders> GetByCustomer(int customerId) =>
            _context.Orders.Where(o => o.CustomerId == customerId).ToList();
    }
}
