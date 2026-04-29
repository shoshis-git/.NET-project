using bakery.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakery.Core.Service
{
    public interface IOrdersService
    {
        List<Orders> GetAll();
        Orders GetById(int id);
        void Add(Orders order);
        void Update(int id, Orders order);
        void Delete(int id);
        void UpdateStatus(int id, EnumStatuses status);
        List<Orders> GetByCustomer(int customerId);
    }
}
