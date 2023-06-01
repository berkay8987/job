using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1_HangfireProject.Core.Entities.Models;
using P1_HangfireProject.Core.Contexts.Data;
using P1_HangfireProject.DataAccess.Abstract;

namespace P1_HangfireProject.DataAccess.Concrete
{
    public class CustomerServiceDal : ICustomerServiceDal
    {
        ProjectDbContext _context;

        public CustomerServiceDal(ProjectDbContext context)
        {
            _context = context;
        }

        // Standard Balance -> 1000.00M
        public List<Customer> GetCustomersWithNonStandardBalanceDal()
        {
            return _context.Customers
                .Where(x => x.IsActive == 1 && x.IsDeleted == 0 && x.Balance != 1000.00M)
                .ToList();
        }

        public void UpdateCustomerBalance(List<Customer> customers)
        {
            foreach (var item in customers)
            {
                item.Balance = 1000.00M;
                Console.WriteLine($"Changed balance to 1000.00M for {item.CustomerId}:{item.FirstName} {item.LastName} ");
                _context.SaveChanges();
            }
        }
    }
}
