using MusteriSiparisUygulamasi.Data;
using MusteriSiparisUygulamasi.Models;

namespace MusteriSiparisUygulamasi.Scripts
{
    public class CreateItemToDb
    {
        public void CreateCustomer(Customer customer)
        {
            using ApplicationContext context = new ApplicationContext();
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void CreateProduct(Product product)
        {
            using ApplicationContext context = new ApplicationContext();
            context.Products.Add(product);
            context.SaveChanges();
        }
    }
}
