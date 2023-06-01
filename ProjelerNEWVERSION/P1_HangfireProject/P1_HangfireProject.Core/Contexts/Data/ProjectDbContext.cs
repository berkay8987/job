using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P1_HangfireProject.Core.Entities.Models;

namespace P1_HangfireProject.Core.Contexts.Data
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne<Customer>(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Customer>().HasData(
                new Customer 
                { 
                    CustomerId = 11,
                    FirstName = "Berkay",
                    LastName  = "Ates",
                    Email = "rastgele@rastgele.com",
                    Balance = 2000.00M,
                    IsActive = 1,
                    IsDeleted = 0
                }
            );
        }
    }
}
