using EFCoreExample.Models;

using Microsoft.EntityFrameworkCore;

namespace EFCoreExample.Data
{
    public class ContosoPizzaContext : DbContext
    {
        // NOT SAFE!!!
        public string connectionString = "CONNECTIONSTRINGNOTSAFETOJUSTPUTITRIGHT?:)";

        public DbSet<Customer> Customers { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
