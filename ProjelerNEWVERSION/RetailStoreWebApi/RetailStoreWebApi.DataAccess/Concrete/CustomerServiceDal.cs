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
    public class CustomerServiceDal : ICustomerServiceDal
    {
        private readonly ProjectDatabaseContext _context;

        public CustomerServiceDal(ProjectDatabaseContext context)
        {
            _context = context;
        }

        public List<Customer> GetAllCustomersDal()
        {
            return _context.Customers
                .Where(x => x.IsActive == 1 && x.IsDeleted == 0)
                .ToList();
        }

        public Customer GetCustomerByIdDal(int id)
        {
            return _context.Customers
                .Where(x => x.IsActive == 1 && x.IsDeleted == 0 && x.CustomerId == id)
                .SingleOrDefault();
        }

        public List<Order> GetOrdersByCustomerIdDal(int id)
        {
            return _context.Orders
                .Where(x => x.CustomerId == id && x.IsActive == 1 && x.IsDeleted == 0)
                .ToList();
        }

    }
}
