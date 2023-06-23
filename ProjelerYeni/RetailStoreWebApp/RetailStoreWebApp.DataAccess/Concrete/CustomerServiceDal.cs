using RetailStoreWebApp.Core.Contexts.Data;
using RetailStoreWebApp.Core.Entities.Models;
using RetailStoreWebApp.Core.Entities.ViewModels;
using RetailStoreWebApp.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreWebApp.DataAccess.Concrete
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

        public Customer? GetCustomerByIdDal(int id)
        {
            return _context.Customers
                .Where(x => x.CustomerId == id && x.IsActive == 1 && x.IsDeleted == 0)
                .SingleOrDefault();
        }

        public Customer? GetCustomerByEmailDal(string email)
        {
            return _context.Customers
                .Where(x => x.Email == email && x.IsActive == 1 && x.IsDeleted == 0)
                .SingleOrDefault();
        }

        public void ChangeCustomerEmailDal(Customer customer, string email)
        {
            customer.Email = email;
            _context.SaveChanges();
        }

        public void DeactivateCustomerDal(Customer customer)
        {
            customer.IsDeleted = 1;
            customer.IsActive = 0;
            _context.SaveChanges();
        }

        public void ReactivateCustomerDal(Customer customer)
        {
            customer.IsDeleted = 0;
            customer.IsActive = 1;
            _context.SaveChanges();
        }

        public Customer? GetInactiveCustomerByEmailDal(string email)
        {
            return _context.Customers
                .Where(x => x.Email == email && x.IsActive == 0 && x.IsDeleted == 1)
                .SingleOrDefault();
        }

        public void AddNewCustomerDal(Customer customer)
        {
            customer.IsActive = 1;
            customer.IsDeleted = 0;
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
    }
}
