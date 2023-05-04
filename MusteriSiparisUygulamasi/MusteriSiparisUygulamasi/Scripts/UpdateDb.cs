using MusteriSiparisUygulamasi.Data;
using MusteriSiparisUygulamasi.Models;

namespace MusteriSiparisUygulamasi.Scripts
{
    public class UpdateDb
    {
        public void UpdateCustomer(int id, string newName, string newPhone)
        {
            using ApplicationContext context = new ApplicationContext();
            try
            {
                var customer = context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
                customer.Name = newName;
                customer.Phone = newPhone;

                context.SaveChanges();
            }
            catch
            {
                Console.WriteLine($"The id>{id} does not exist in the database");
            }
        }

        public void UpdateProduct(int id, string newName, int newPrice)
        {
            using ApplicationContext context = new ApplicationContext();
            try
            {
                var product = context.Products.Where(x => x.Id == id).FirstOrDefault();
                product.Name = newName;
                product.Price = newPrice;

                context.SaveChanges();
            }
            catch
            {
                Console.WriteLine($"The id>{id} does not exist in the database");
            }
        }

        public void UpdateOrder(int id, int prodId)
        {
            using ApplicationContext context = new ApplicationContext();
            try
            {
                var order = context.Orders.Where(x => x.Id == id).FirstOrDefault();
                order.ProductId = prodId;
                context.SaveChanges();
            }
            catch
            {
                Console.WriteLine($"The id>{id} does not exist in the database");
            }
        }
    }
}
