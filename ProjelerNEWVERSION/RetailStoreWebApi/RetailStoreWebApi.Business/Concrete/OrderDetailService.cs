using AutoMapper;
using RetailStoreWebApi.Business.Abstract;
using RetailStoreWebApi.Core.Entities.ApiModels.GetModels;
using RetailStoreWebApi.Core.Entities.ApiModels.PostModels;
using RetailStoreWebApi.Core.Entities.Models;
using RetailStoreWebApi.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreWebApi.Business.Concrete
{
    public class OrderDetailService : IOrderDetailService
    {
        IOrderDetailServiceDal _orderDetailServiceDal;
        IMapper _mapper;

        public OrderDetailService(IOrderDetailServiceDal orderDetailServiceDal,
            IMapper mapper)
        {
            _orderDetailServiceDal = orderDetailServiceDal;
            _mapper = mapper;
        }

        public List<OrderDetailGetModel>? GetAllOrderDetails()
        {
            var orderDetails = _orderDetailServiceDal.GetAllOrderDetailsDal();
            if (orderDetails == null) return null;
            var orderDetailsGetModel = _mapper.Map<List<OrderDetail>, List<OrderDetailGetModel>>(orderDetails);
            return orderDetailsGetModel;
        }

        public OrderDetailGetModel? GetOrderDetailById(int orderDetailId)
        {
            var orderDetail = _orderDetailServiceDal.GetOrderDetailByIdDal(orderDetailId);
            if (orderDetail == null) return null;
            var orderDetailGetModel = _mapper.Map<OrderDetailGetModel>(orderDetail);
            return orderDetailGetModel;
        }

        public OrderDetailGetModel? AddNewOrderDetail(OrderDetailPostModel orderDetailPostModel)
        {
            if (!_orderDetailServiceDal.CheckOrderAndDetail(orderDetailPostModel.OrderId))
            {
                return null;
            }
            var orderDetailToAdd = _mapper.Map<OrderDetail>(orderDetailPostModel);
            var newOrderDetail = _orderDetailServiceDal.AddNewOrderDetailDal(orderDetailToAdd);
            var orderDetailGetModel = _mapper.Map<OrderDetailGetModel>(newOrderDetail);
            return orderDetailGetModel;
        }

        public OrderDetailGetModel? DeactivateOrderDetail(int orderDetailId)
        {
            var orderDetail = _orderDetailServiceDal.GetOrderDetailByIdDal(orderDetailId);
            if (orderDetail == null) return null;
            _orderDetailServiceDal.DeactivateOrderDetailDal(orderDetail);
            var orderDetailGetModel = _mapper.Map<OrderDetailGetModel>(orderDetail);
            return orderDetailGetModel;
        }
    }
}
