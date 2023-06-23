using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RetailStoreWebApp.Core.Entities.Models;
using RetailStoreWebApp.Core.Entities.ViewModels;

namespace RetailStoreWebApp.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerGetModel>();
            CreateMap<CustomerPutModel, Customer>();
            CreateMap<Product, ProductGetModel>();
            CreateMap<ProductPutModel, Product>();
            CreateMap<ProductPostModel, Product>();
        }
    }
}
