using RetailStoreWebApi.Core.Contexts.Data;
using RetailStoreWebApi.Core.Entities.Models;
using RetailStoreWebApi.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreWebApi.DataAccess.Concrete
{
    public class OrderDetailServiceDal : IOrderDetailServiceDal
    {
        ProjectDatabaseContext _context;

        public OrderDetailServiceDal(ProjectDatabaseContext context)
        {
            _context = context;
        }

        public List<OrderDetail>? GetAllOrderDetailsDal()
        {
            return _context.OrderDetails.Where(x => x.IsActive == 1 && x.IsDeleted == 0).ToList();
        }

        public OrderDetail? GetOrderDetailByIdDal(int orderDetaiId)
        {
            return _context.OrderDetails
                .Where(x => x.OrderDetailId == orderDetaiId && x.IsActive == 1 && x.IsDeleted == 0)
                .SingleOrDefault();
        }

        public OrderDetail? AddNewOrderDetailDal(OrderDetail orderDetail)
        {
            var productPrice = _context.Products.Where(x => x.ProductId ==
            _context.Orders.Where(x => x.OrderId == orderDetail.OrderId).SingleOrDefault().ProductId)
                .SingleOrDefault().PriceTry;

            orderDetail.Price = orderDetail.Quantity * productPrice;
            orderDetail.IsActive = 1;
            orderDetail.IsDeleted = 0;

            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
            return orderDetail;
        }

        public bool CheckOrderAndDetail(int orderId)
        {
            var order = _context.Orders
                .Where(x => x.OrderId == orderId && x.IsActive == 1 && x.IsDeleted == 0)
                .SingleOrDefault();
            if (order == null) 
                return false;

            var orderDetail = _context.OrderDetails
                .Where(x => x.OrderId == order.OrderId && x.IsActive == 1 && x.IsDeleted == 0)
                .SingleOrDefault();
            if (orderDetail != null) 
                return false;

            return true;
        }

        public void DeactivateOrderDetailDal(OrderDetail orderDetail)
        {
            orderDetail.IsActive = 0;
            orderDetail.IsDeleted = 1;
            _context.SaveChanges();
        }
    }
}
