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
        Task<IEnumerable<Orders>> GetAllAsync();
        Task<Orders> GetByIdAsync(int id);
        Task AddAsync(Orders order);
        Task UpdateAsync(int id, Orders order);
        Task DeleteAsync(int id);
        Task UpdateStatusAsync(int id, EnumStatuses status);
        Task<IEnumerable<Orders>> GetByCustomerAsync(int customerId);
    }
}
