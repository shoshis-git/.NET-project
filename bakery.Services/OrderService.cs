
using bakery.Core.Entities;
using bakery.Core.Repository;
using bakery.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakery.Services
{
    public class OrderService:IOrdersService
    {
        private readonly IRepositoryManager _repoManager;

        public OrderService(IRepositoryManager repoManager)
        {
            _repoManager = repoManager;
        }
        public List<Orders> GetAll() => _repoManager.Orders.GetList();

        public Orders GetById(int id) =>_repoManager.Orders.GetById(id);
        public void Add(Orders order)
        {
            _repoManager.Orders.Add(order);
            _repoManager.Save();
        }
        public void Update(int id, Orders order) 
        { 
            _repoManager.Orders.Update(id, order);
            _repoManager.Save();
        }

        public void Delete(int id) 
        { 
            _repoManager.Orders.Delete(id); 
            _repoManager.Save();
        }
        public void UpdateStatus(int id, EnumStatuses status) 
        {
            _repoManager.Orders.UpdateStatus(id, status);
             _repoManager.Save();
        }
        public List<Orders> GetByCustomer(int customerId) =>_repoManager.Orders.GetByCustomer(customerId);

    }
}
    

