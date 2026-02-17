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
        public List<Products> GetAll();
        public Products GetById(int id);
        public void Add(Products product);
        public void Update(int id, Products product);
        public void Delete(int id);
        public List<Products> GetByCategory(string category);
    }
}
