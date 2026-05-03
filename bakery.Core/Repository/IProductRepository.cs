using bakery.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakery.Core.Repository
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Products>> GetAllAsync();
        public Task<Products> GetByIdAsync(int id);
        public void Add(Products product);
        public Task UpdateAsync(int id, Products product);
        public Task DeleteAsync(int id);
      
    }
}
