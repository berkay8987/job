using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1_HangfireProject.Business;
using P1_HangfireProject.Business.Abstract;
using P1_HangfireProject.Core.Contexts.Data;

namespace P1_HangfireProject.Hangfires
{
    public class HandleHangfire
    {
        ICustomerService _customerService;
        ProjectDbContext _context;

        public HandleHangfire(ICustomerService customerService, ProjectDbContext context)
        {
            _customerService = customerService;
            _context = context; 
        }

        public void MyHangfireFunction()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("Hangfire Started");
            Console.WriteLine("********************************");

            var data = _customerService.GetCustomersWithNonStandardBalance();

            if (data == null) 
            {
                Console.WriteLine("********************************");
                Console.WriteLine("\nNo member(s) were effected.\n");
                Console.WriteLine("********************************");
                Console.WriteLine("Hangfire Ended");
                Console.WriteLine("********************************");
                return;
            }

            foreach (var item in data)
            {
                item.Balance = 1000.00M;
                Console.WriteLine($"Changed balance to 1000.00M for {item.CustomerId}:{item.FirstName} {item.LastName} ");
                _context.SaveChanges();
            }

            Console.WriteLine("********************************");
            Console.WriteLine("Hangfire Ended");
            Console.WriteLine("********************************");
            return;
        }
    }
}
