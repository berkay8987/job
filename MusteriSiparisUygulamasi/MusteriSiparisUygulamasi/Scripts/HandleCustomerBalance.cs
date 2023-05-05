using MusteriSiparisUygulamasi.Data;
using MusteriSiparisUygulamasi.Models;

namespace MusteriSiparisUygulamasi.Scripts
{
    public class HandleCustomerBalance
    {
        public void AddBalanceToCustomer(int id, int balanceToAdd)
        {
            using ApplicationContext context = new ApplicationContext();
            Customer customer = context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
            customer.Balance += balanceToAdd;
            Console.WriteLine($"New balance for {customer.Name} is {customer.Balance}");
            context.SaveChanges();
        }

        public void RemoveBalanceFromCustomer(int id, int balanceToRemove)
        {
            using ApplicationContext context = new ApplicationContext();
            Customer customer = context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();

            int tempBalance = customer.Balance;
            tempBalance -= balanceToRemove;

            if (tempBalance < 0)
            {
                Console.WriteLine("Not enough money to remove!");
            }
            else 
            {
                customer.Balance = tempBalance;
                Console.WriteLine($"New balance for {customer.Name} is {customer.Balance}");
                context.SaveChanges();
            }
        }
    }
}
