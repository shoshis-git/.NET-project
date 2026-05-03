using bakery.Core.Entities;
using bakery.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace bakery.Data.Repositories
{
    public class ProductsRepository: Repository<Products>, IProductRepository
    {
       

        public ProductsRepository(DataContext context):base(context)
        {
            
        }

        public async Task<IEnumerable<Products>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<Products> GetByIdAsync(int id) =>
            await _dbSet.FirstOrDefaultAsync(p => p.Id == id);

        public void Add(Products product)
        {

            _dbSet.Add(product);
        }

        public async Task UpdateAsync(int id, Products Product)
        {
            var existing = await GetByIdAsync(id);
            if (existing == null) return;

            existing.Name = Product.Name;
           
            existing.Price = Product.Price;
        }

        public async Task DeleteAsync(int id)
        {
            var product =  await GetByIdAsync(id);
            if (product != null)
                _dbSet.Remove(product);
        }

      
    }
}

