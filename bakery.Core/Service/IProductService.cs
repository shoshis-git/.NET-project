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
        List<Products> GetAll();
        Products GetById(int id);
        void Add(   Products product);
        void Update(int id,Products product);
        void Delete(int id);
      
    }
}
