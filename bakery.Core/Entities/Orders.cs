using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakery.Core.Entities
{
    public class Orders
    {
      
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public  EnumStatuses Status{ get; set; }
        
        public Customer Customer { get; set; }
       
        public Products Product { get; set; }
    }
}
