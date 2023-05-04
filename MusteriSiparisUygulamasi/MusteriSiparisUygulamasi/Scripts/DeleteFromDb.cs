using MusteriSiparisUygulamasi.Data;
using MusteriSiparisUygulamasi.Models;

namespace MusteriSiparisUygulamasi.Scripts
{
    public class DeleteFromDb
    {
        public void DeleteCustomerFromDatabaseWithId(int id)
        {
            using ApplicationContext context = new ApplicationContext();
            try
            {
                var customer = context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
                context.Customers.Remove(customer);
                context.SaveChanges();
            }
            catch
            {
                Console.WriteLine($"That Id>{id} does not exist in the database!");
            }
        }

        public void DeleteCustomerFromDatabaseWithName(string name)
        {
            using ApplicationContext context = new ApplicationContext();
            try
            {
                var customer = context.Customers.Where(x => x.Name == name).FirstOrDefault();
                context.Remove(customer);
                context.SaveChanges();
            }
            catch
            {
                Console.WriteLine($"That name>{name} does not exist in the database!");
            }
        }

        public void DeleteProductFromDatabaseWithId(int id)
        {
            using ApplicationContext context = new ApplicationContext();
            try
            {
                var product = context.Products.Where(x => x.Id == id).FirstOrDefault();
                context.Products.Remove(product);
                context.SaveChanges();
            }
            catch
            {
                Console.WriteLine($"That Id>{id} does not exist in the database!");
            }
        }

        public void DeleteProductFromDatabaseWithPrice(int price)
        {
            using ApplicationContext context = new ApplicationContext();
            try
            {
                var product = context.Products.Where(x => x.Price == price).FirstOrDefault();
                context.Products.Remove(product);
                context.SaveChanges();
            }
            catch
            {
                Console.WriteLine($"That price>{price} does not exist in the database!");
            }
        }

        public void DeleteOrderFromDatabaseWithId(int id)
        {
            using ApplicationContext context = new ApplicationContext();
            try
            {
                var order = context.Orders.Where(x => x.Id == id).FirstOrDefault();
                context.Orders.Remove(order);
                context.SaveChanges();
            }
            catch
            {
                Console.WriteLine($"That Id>{id} does not exist in the database!");
            }
        }
    }
}
