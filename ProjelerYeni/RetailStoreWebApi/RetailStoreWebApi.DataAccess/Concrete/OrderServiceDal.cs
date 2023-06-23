using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailStoreWebApi.Core.Contexts.Data;
using RetailStoreWebApi.Core.Entities.Models;
using RetailStoreWebApi.DataAccess.Abstract;

namespace RetailStoreWebApi.DataAccess.Concrete
{
    public class OrderServiceDal : IOrderServiceDal
    {
        ProjectDatabaseContext _context;

        public OrderServiceDal(ProjectDatabaseContext context)
        {
            _context = context;
        }

        public List<Order>? GetAllOrdersDal()
        {
            return _context.Orders.Where(x => x.IsActive == 1 && x.IsDeleted == 0).ToList();
        }

        public Order? GetOrderByIdDal(int orderId)
        {
            return _context.Orders
                .Where(x => x.OrderId == orderId && x.IsActive == 1 && x.IsDeleted == 0)
                .SingleOrDefault();
        }

        public Order? AddNewOrderDal(Order order)
        {
            order.OrderDate = DateTime.Now;
            order.IsDeleted = 0;
            order.IsActive = 1;
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public void DeactivateOrder(Order order)
        {
            order.IsActive = 0;
            order.IsDeleted = 1;
            _context.SaveChanges();
        }
    }
}
