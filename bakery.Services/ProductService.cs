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
    public class ProductService:IProductService
    {
        private readonly IRepositoryManager _repoManager;

        public ProductService(IRepositoryManager repoManager)
        {
            _repoManager = repoManager;
        }

        public List<Products> GetAll() => _repoManager.Products.GetAll();

        public Products GetById(int id) =>
            _repoManager.Products.GetById(id);

        public void Add(Products product)
        {
            _repoManager.Products.Add(product);
            _repoManager.Save();
        }

        public void Update(int id, Products product)
        {
           _repoManager.Products.Update(id, product);
            _repoManager.Save();
        }

        public void Delete(int id)
        {
            _repoManager.Products.Delete(id);
                _repoManager.Save();
        }

        public List<Products> GetByCategory(string category) =>
            _repoManager.Products.GetByCategory(category);
    }
}

