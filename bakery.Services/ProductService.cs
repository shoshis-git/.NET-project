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
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Products> GetAll() => _productRepository.GetAll();

        public Products GetById(int id) =>
            _productRepository.GetById(id);

        public void Add(Products product)
        {
            _productRepository.Add(product);
        }

        public void Update(int id, Products product)
        {
           _productRepository.Update(id, product);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public List<Products> GetByCategory(string category) =>
            _productRepository.GetByCategory(category);
    }
}

