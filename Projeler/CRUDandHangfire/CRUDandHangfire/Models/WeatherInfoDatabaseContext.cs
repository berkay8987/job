using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUDandHangfire.Models;

public partial class WeatherInfoDatabaseContext : DbContext
{
    public WeatherInfoDatabaseContext()
    {

    }

    public WeatherInfoDatabaseContext(DbContextOptions options) : base(options)
    {

    }

    public virtual DbSet<WeatherInfo> WeatherInfos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WeatherInfo>(entity =>
        {
            entity.Property(e => e.FeelslikeC)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("Feelslike_c");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.TempC)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("Temp_c");
            entity.Property(e => e.WindKph)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("Wind_kph");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
