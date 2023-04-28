using EFCoreExample.Data;
using EFCoreExample.Models;

namespace EFCoreExample.Scripts
{
    public class DeleteFromDb
    {
        public void DeleteFromDatabase()
        {
            //////// DELETE FROM DB ////////
            using ContosoPizzaContext context = new ContosoPizzaContext();

            var veggie2 = context.Products
                                 .Where(p => p.Id == 3)
                                 .FirstOrDefault();

            var deluxe2 = context.Products
                                 .Where(p => p.Id == 4)
                                 .FirstOrDefault();

            if (veggie2 is Product)
            {
                context.Remove(veggie2);
            }

            if (deluxe2 is Product)
            {
                context.Remove(deluxe2);
            }

            Console.WriteLine("Successfuly Deleted");

        }
    }
}
