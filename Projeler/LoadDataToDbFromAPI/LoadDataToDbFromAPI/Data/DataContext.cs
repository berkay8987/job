using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoadDataToDbFromAPI.Models;

namespace LoadDataToDbFromAPI.Data
{
    public class DataContext : DbContext
    {
        string connectionString = "Server=NB320882;Database=WeatherInfoDatabase;TrustServerCertificate=True;User Id=sa;Password=5xgkW8RUZr;";

        public DbSet<WeatherInfo> WeatherInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
