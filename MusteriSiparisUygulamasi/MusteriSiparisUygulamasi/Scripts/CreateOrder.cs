using MusteriSiparisUygulamasi.Data;
using MusteriSiparisUygulamasi.Models;

namespace MusteriSiparisUygulamasi.Scripts
{
    public class CreateOrder
    {
        public void CreateOrderToDb(int custId, int prodId)
        {
            using ApplicationContext context = new ApplicationContext();

            Customer customer = context.Customers.Where(x => x.CustomerId == custId).FirstOrDefault();
            Product product = context.Products.Where(x => x.Id == prodId).FirstOrDefault();

            if (product.Price > customer.Balance)
            {
                Console.WriteLine("Not enough money!");
            }
            else 
            {
                Order ord = new Order()
                {
                    CustomerId = custId,
                    ProductId = prodId
                };

                customer.Balance -= product.Price;

                Console.WriteLine($"Bought {product.Name} for {product.Price}, remaining balance is {customer.Balance} for {customer.Name}.");

                context.Orders.Add(ord);
                context.SaveChanges();
            } 
        }
    }
}
