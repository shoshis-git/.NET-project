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

        public async Task<IEnumerable<Products>> GetAllAsync() => await _repoManager.Products.GetAllAsync();

        public async Task<Products> GetByIdAsync(int id) =>
            await _repoManager.Products.GetByIdAsync(id);

        public async Task AddAsync(Products product)
        {
            _repoManager.Products.Add(product);
            await _repoManager.SaveAsync();
        }

        public async Task UpdateAsync(int id, Products product)
        {
           await _repoManager.Products.UpdateAsync(id, product);
            await _repoManager.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _repoManager.Products.DeleteAsync(id);
                await _repoManager.SaveAsync();
        }

       
    }
}

