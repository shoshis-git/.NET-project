
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
        private readonly IOrderRepository _ordersRepository;

        public OrderService(IOrderRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        public List<Orders> GetAll() => _ordersRepository.GetList();

        public Orders GetById(int id) =>_ordersRepository.GetById(id);
        public void Add(Orders order)=>_ordersRepository.Add(order);
        public void Update(int id, Orders order)=>_ordersRepository.Update(id,order);

        public void Delete(int id)=>_ordersRepository.Delete(id);
        public void UpdateStatus(int id, string status)=>_ordersRepository.UpdateStatus(id,status);
        public List<Orders> GetByCustomer(int customerId) =>_ordersRepository.GetByCustomer(customerId);

    }
}
    

