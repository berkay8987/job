using MusteriSiparisUygulamasi.Data;
using MusteriSiparisUygulamasi.Models;

namespace MusteriSiparisUygulamasi.Scripts
{
    public class ReadFromDb
    {
        public void ReadFromDatabase()
        {
            using ApplicationContext context = new ApplicationContext();

            var customers = context.Customers;

            Console.WriteLine();

            Console.WriteLine("\t///// CUSTOMERS /////");
            Console.WriteLine("CustomerId,Name,Phone,Balance");
            foreach ( var customer in customers ) 
            {
                Console.WriteLine($"{customer.CustomerId},{customer.Name},{customer.Phone},{customer.Balance}");
            }

            Console.WriteLine();

            var products = context.Products;

            Console.WriteLine("\t///// PRODUCTS /////");
            Console.WriteLine("Id,Name,Price");
            foreach ( var product in products ) 
            {
                Console.WriteLine($"{product.Id},{product.Name},{product.Price}");
            }

            Console.WriteLine();

            var orders = context.Orders;

            Console.WriteLine("\t///// ORDERS /////");
            Console.WriteLine("Id,CustomerId,ProductId");
            foreach(Order ord in orders)
            {
                Console.WriteLine($"{ord.Id},{ord.CustomerId},{ord.ProductId}");
            }
        }
    }
}
