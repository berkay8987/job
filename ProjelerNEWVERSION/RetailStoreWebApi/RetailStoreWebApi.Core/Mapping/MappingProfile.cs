using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RetailStoreWebApi.Core.Entities.Models;
using RetailStoreWebApi.Core.Entities.ApiModels.GetModels;
using RetailStoreWebApi.Core.Entities.ApiModels.PostModels;

namespace RetailStoreWebApi.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerGetModel>();
            CreateMap<Order, OrderGetModel>();
            CreateMap<OrderDetail, OrderDetailGetModel>();
            CreateMap<Product, ProductGetModel>();
            CreateMap<CustomerPostModel, Customer>();
            CreateMap<Order, OrderGetModel>();
            CreateMap<OrderPostModel, Order>();
            CreateMap<OrderDetail, OrderDetailGetModel>();
            CreateMap<OrderDetailPostModel, OrderDetail>();
        }
    }
}