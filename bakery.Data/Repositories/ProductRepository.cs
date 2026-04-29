using bakery.Core.Entities;
using bakery.Core.Repository;
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

        public List<Products> GetAll() => _dbSet.ToList();

        public Products GetById(int id) =>
            _dbSet.FirstOrDefault(p => p.Id == id);

        public void Add(Products product)
        {

            _dbSet.Add(product);
        }

        public void Update(int id, Products Product)
        {
            var existing = GetById(id);
            if (existing == null) return;

            existing.Name = Product.Name;
           
            existing.Price = Product.Price;
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
                _dbSet.Remove(product);
        }

      
    }
}

