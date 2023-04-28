using EFCoreExample.Data;
using EFCoreExample.Models;

namespace EFCoreExample.Scripts
{
    public class UpdateDb
    {
        //////// UPDATE DATABASE ////////
        public void UpdateDatabase()
        {
            using ContosoPizzaContext context = new ContosoPizzaContext();
            var veggieSpecial = context.Products
                                       .Where(q => q.Name == "Veggie Special Pizza")
                                       .FirstOrDefault();

            if (veggieSpecial is Product)
            {
                veggieSpecial.Price = 10.99M;
            }

            context.SaveChanges();

            Console.WriteLine("Updated Database");

        }
    }
}
