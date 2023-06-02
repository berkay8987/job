using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailStoreWebApi.Core.Entities.ApiModels;
using RetailStoreWebApi.DataAccess.Abstract;
using RetailStoreWebApi.Core.Contexts.Data;
using RetailStoreWebApi.Core.Entities.Models;

namespace RetailStoreWebApi.DataAccess.Concrete
{
    public class OrderServiceDal : IOrderServiceDal
    {
        private readonly ProjectDatabaseContext _context;

        public OrderServiceDal(ProjectDatabaseContext context)
        {
            _context = context;
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders.Where(x => x.IsActive == 1 && x.IsDeleted == 0).ToList();
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders
                .Where(x => x.OrderId == id && x.IsActive == 1 && x.IsDeleted == 0)
                .SingleOrDefault();
        }
    }
}
