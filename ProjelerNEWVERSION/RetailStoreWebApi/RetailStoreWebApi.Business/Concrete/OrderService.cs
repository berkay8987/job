using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RetailStoreWebApi.Business.Abstract;
using RetailStoreWebApi.Core.Entities.ApiModels;
using RetailStoreWebApi.Core.Entities.Models;
using RetailStoreWebApi.DataAccess.Abstract;

namespace RetailStoreWebApi.Business.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IOrderServiceDal _orderServiceDal;
        private readonly IMapper _mapper;

        public OrderService(IOrderServiceDal orderServiceDal, IMapper mapper)
        {
            _orderServiceDal = orderServiceDal;
            _mapper = mapper;
        }

        public List<OrderGetModel>? GetAllOrders()
        {
            var orders = _orderServiceDal.GetAllOrders();
            var ordersGetModel = _mapper.Map<List<Order>, List<OrderGetModel>>(orders);
            return ordersGetModel.Count == 0 ? null : ordersGetModel;
        }

        public OrderGetModel? GetOrderById(int id)
        {
            var order = _orderServiceDal.GetOrderById(id);
            var orderGetModel = _mapper.Map<OrderGetModel>(order);
            return orderGetModel ?? null;
        }
    }
}
