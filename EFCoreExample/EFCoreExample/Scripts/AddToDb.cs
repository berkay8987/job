using EFCoreExample.Data;
using EFCoreExample.Models;

namespace EFCoreExample.Scripts
{
    public class AddToDb
    {
        //////// ADD TO DATABASE ////////
        public void AddToDatabase()
        {
            using ContosoPizzaContext context = new ContosoPizzaContext();

            Product veggieSpecial = new Product()
            {
                Name = "Veggie Special Pizza",
                Price = 9.99M
            };
            context.Products.Add(veggieSpecial);

            Product deluxeMeat = new Product()
            {
                Name = "Deluxe Meat Pizza",
                Price = 12.99M
            };
            context.Add(deluxeMeat);

            Product pepperoni = new Product()
            {
                Name = "Pepperoni Pizza",
                Price = 7.99M
            };
            context.Add(pepperoni);

            Product newYorkSpecial = new Product()
            {
                Name = "New York Special Pizza",
                Price = 15.99M
            };
            context.Add(newYorkSpecial);

            Product bostonSpecial = new Product()
            {
                Name = "Boston Special Pizza",
                Price = 12.99M
            };
            context.Add(bostonSpecial);

            context.SaveChanges();

            Console.WriteLine("Added to Database");

        }
    }
}
