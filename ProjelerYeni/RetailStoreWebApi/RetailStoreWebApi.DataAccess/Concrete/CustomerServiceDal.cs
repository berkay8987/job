using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using RetailStoreWebApi.Core.Contexts.Data;
using RetailStoreWebApi.Core.Entities.Models;
using RetailStoreWebApi.DataAccess.Abstract;

namespace RetailStoreWebApi.DataAccess.Concrete
{
    public class CustomerServiceDal : ICustomerServiceDal
    {
        private readonly ProjectDatabaseContext _context;

        public CustomerServiceDal(ProjectDatabaseContext context)
        {
            _context = context;
        }

        public List<Customer>? GetAllCustomersDal()
        {
            return _context.Customers.Where(x => x.IsActive == 1 && x.IsDeleted == 0).ToList();
        }

        public Customer? GetCustomerByIdDal(int customerId)
        {
            return _context.Customers
                .Where(x => x.CustomerId == customerId && x.IsActive == 1 && x.IsDeleted == 0)
                .SingleOrDefault();
        }

        public Customer? GetInactiveCustomerByEmailDal(string email)
        {
            return _context.Customers
                .Where(x => x.Email == email && x.IsActive == 0 && x.IsDeleted == 1)
                .SingleOrDefault();
        }

        public Customer? GetCustomerByEmailDal(string email)
        {
            return _context.Customers
                .Where(x => x.Email == email && x.IsActive == 1 && x.IsDeleted == 0)
                .SingleOrDefault();
        }

        public Customer? UpdateCustomerDal(string email, Customer customer)
        {
            customer.Email = email;
            _context.SaveChanges();
            return customer;
        }

        public Customer? AddNewCustomerDal(Customer customer)
        {
            customer.IsActive = 1;
            customer.IsDeleted = 0;
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public void ReactivateCustomerDal(Customer customer)
        {
            customer.IsActive = 1;
            customer.IsDeleted = 0;
            _context.SaveChanges();
        }

        public void DeactivateCustomerDal(Customer customer)
        {
            customer.IsActive = 0;
            customer.IsDeleted = 1;
            _context.SaveChanges();
        }
    }
}
