using MusteriSiparisUygulamasi.Data;
using MusteriSiparisUygulamasi.Models;

namespace MusteriSiparisUygulamasi.Scripts
{
    public class CreateOrder
    {
        public void CreateOrderToDb(int custId, int prodId)
        {
            using ApplicationContext context = new ApplicationContext();

            Order ord = new Order()
            {
                CustomerId = custId,
                ProductId = prodId
            };

            context.Orders.Add(ord);
            context.SaveChanges();
        }
    }
}
