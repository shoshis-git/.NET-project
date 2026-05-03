using bakery.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakery.Core.Service
{
    public interface IProductService
    {
        Task<IEnumerable<Products>> GetAllAsync();
        Task<Products> GetByIdAsync(int id);
        Task AddAsync(Products product);
        Task UpdateAsync(int id, Products product);
        Task DeleteAsync(int id);
      
    }
}
