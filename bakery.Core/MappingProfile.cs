using AutoMapper;
using bakery.Core.DTOs;
using bakery.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakery.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        { 
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Orders, OrderDTO>().ReverseMap();
            CreateMap<Products, ProductDTO>().ReverseMap();
           
        }
    }
}
