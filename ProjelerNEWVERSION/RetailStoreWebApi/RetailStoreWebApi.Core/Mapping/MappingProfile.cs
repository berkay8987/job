using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RetailStoreWebApi.Core.Entities.Models;
using RetailStoreWebApi.Core.Entities.ApiModels;

namespace RetailStoreWebApi.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerGetModel>();
            CreateMap<Order, OrderGetModel>();
        }
    }
}
