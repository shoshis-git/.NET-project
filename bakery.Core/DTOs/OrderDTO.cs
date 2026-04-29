
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakery.Core.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string ProductName { get; set; }
        public EnumStatuses Status { get; set; }
        public CustomerDto Customer { get; set; }
        public ProductDTO Product { get; set; }
    }
}
