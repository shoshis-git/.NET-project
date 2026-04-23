using bakery.Core.Entities;
using bakery.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakery.Data.Repositories
{
    public class ProductRepository: Repository<Products>, IProductRepository
    {
       

        public ProductRepository(DataContext context):base(context)
        {
            
        }

        public List<Products> GetAll() => _dbSet.ToList();

        public Products GetById(int id) =>
            _dbSet.FirstOrDefault(p => p.Id == id);

        public void Add(Products product)
        {

            _dbSet.Add(product);
        }

        public void Update(int id, Products product)
        {
            var existing = GetById(id);
            if (existing == null) return;

            existing.Name = product.Name;
            existing.Category = product.Category;
            existing.Price = product.Price;
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
                _dbSet.Remove(product);
        }

        public List<Products> GetByCategory(string category) =>
            _context.Products
                .Where(p => p.Category == category)
                .ToList();
    }
}

