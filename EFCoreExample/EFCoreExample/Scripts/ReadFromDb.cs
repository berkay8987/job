using EFCoreExample.Data;
using EFCoreExample.Models;

namespace EFCoreExample.Scripts
{

    public class ReadFromDb
    {
        //////// Reading from database using FLUENT API ////////
        public void ReadFromDatabaseUsingFluentAPI()
        {
            using ContosoPizzaContext context = new ContosoPizzaContext();

            var products = context.Products
                      .Where(p => p.Price > 10.00M)
                      .OrderBy(p => p.Name);

            var products2 = context.Products;

            foreach (Product p in products2)
            {
                Console.WriteLine($"Id:    {p.Id}");
                Console.WriteLine($"Name:  {p.Name}");
                Console.WriteLine($"Price: {p.Price}");
                Console.WriteLine(new string('-', 20));

            }

            Console.WriteLine("Read From Database Using Fluent API");
        }

        //////// Reading from database using LINQ ////////
        public void ReadFromDatabaseUsingLinq()
        {
            using ContosoPizzaContext context = new ContosoPizzaContext();

            var products = from product in context.Products
                           where product.Price > 10.00M
                           orderby product.Name
                           select product;

            var products2 = context.Products;


            foreach (Product p in products2)
            {
                Console.WriteLine($"Id:    {p.Id}");
                Console.WriteLine($"Name:  {p.Name}");
                Console.WriteLine($"Price: {p.Price}");
                Console.WriteLine(new string('-', 20));
            }

            Console.WriteLine("Read From Database Using Linq");
        }

    }
}
