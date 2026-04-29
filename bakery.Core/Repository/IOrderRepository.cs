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
        public List<Orders> GetList();
        public Orders GetById(int id);
        public void Add(Orders order);
        public void Update(int id, Orders order);
        public void Delete(int id);
        public void UpdateStatus(int id, EnumStatuses status);
        public List<Orders> GetByCustomer(int customerId);
    }
}
