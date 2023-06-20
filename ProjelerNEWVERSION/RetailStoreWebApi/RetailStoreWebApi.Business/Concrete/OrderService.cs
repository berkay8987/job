using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RetailStoreWebApi.Business.Abstract;
using RetailStoreWebApi.Core.Entities.ApiModels.GetModels;
using RetailStoreWebApi.Core.Entities.ApiModels.PostModels;
using RetailStoreWebApi.Core.Entities.Models;
using RetailStoreWebApi.DataAccess.Abstract;

namespace RetailStoreWebApi.Business.Concrete
{
    public class OrderService : IOrderService
    {
        IOrderServiceDal _orderServiceDal;
        IMapper _mapper;

        public OrderService(IOrderServiceDal orderServiceDal,
            IMapper mapper)
        {
            _orderServiceDal = orderServiceDal;
            _mapper = mapper;
        }

        public List<OrderGetModel>? GetAllOrders()
        {
            var orders = _orderServiceDal.GetAllOrdersDal();
            var ordersGetModel = _mapper.Map<List<Order>, List<OrderGetModel>>(orders);
            return ordersGetModel ?? null;
        }

        public OrderGetModel? GetOrderById(int orderId)
        {
            var order = _orderServiceDal.GetOrderByIdDal(orderId);
            var orderGetModel = _mapper.Map<OrderGetModel>(order);
            return orderGetModel ?? null;
        }

        public OrderGetModel? AddNewOrder(OrderPostModel orderPostModel)
        {
            var orderToAdd = _mapper.Map<Order>(orderPostModel);
            var newOrder = _orderServiceDal.AddNewOrderDal(orderToAdd);
            var orderGetModel = _mapper.Map<OrderGetModel>(newOrder);
            return orderGetModel;
        }

        public OrderGetModel? DeactivateOrder(int orderId)
        {
            var order = _orderServiceDal.GetOrderByIdDal(orderId);
            if (order == null) return null;
            _orderServiceDal.DeactivateOrder(order);
            var orderGetModel = _mapper.Map<OrderGetModel>(order);
            return orderGetModel;
        }
    }
}
