using bakery.Core.Entities;
using bakery.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakery.Data.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public List<Products> GetAll() => _context.Products.ToList();

        public Products GetById(int id) =>
            _context.Products.FirstOrDefault(p => p.Id == id);

        public void Add(Products product)
        {
            product.Id = _context.Products.ToList().Count == 0
                ? 1
                : _context.Products.Max(p => p.Id) + 1;

            _context.Products.Add(product);
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
                _context.Products.Remove(product);
        }

        public List<Products> GetByCategory(string category) =>
            _context.Products
                .Where(p => p.Category == category)
                .ToList();
    }
}

