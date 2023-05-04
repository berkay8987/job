using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusteriSiparisUygulamasi.Models;

namespace MusteriSiparisUygulamasi.Data
{
    public class ApplicationContext : DbContext
    {
        public string connectionString = "Server=NB320882;Database=MSU;TrustServerCertificate=True;User Id=sa;Password=5xgkW8RUZr;";

        public DbSet<Customer> Customers { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<Comment> Comments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
