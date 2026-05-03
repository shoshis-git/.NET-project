
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
        public async Task<IEnumerable<Orders>> GetAllAsync() => await _repoManager.Orders.GetAllAsync();

        public async Task<Orders> GetByIdAsync(int id) => await _repoManager.Orders.GetByIdAsync(id);
        public async Task AddAsync(Orders order)
        {
            _repoManager.Orders.Add(order);
            await _repoManager.SaveAsync();
        }
        public async Task UpdateAsync(int id, Orders order) 
        { 
            await _repoManager.Orders.UpdateAsync(id, order);
            await _repoManager.SaveAsync();
        }

        public async Task DeleteAsync(int id) 
        { 
            await _repoManager.Orders.DeleteAsync(id); 
            await _repoManager.SaveAsync();
        }
        public async Task UpdateStatusAsync(int id, EnumStatuses status) 
        {
            await _repoManager.Orders.UpdateStatusAsync(id, status);
             await _repoManager.SaveAsync();
        }
        public async Task<IEnumerable<Orders>> GetByCustomerAsync(int customerId) => await _repoManager.Orders.GetByCustomerAsync(customerId);

    }
}
    

