using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RetailStoreWebApi.Core.Entities.Models;

namespace RetailStoreWebApi.Core.Contexts.Data;

public partial class ProjectDatabaseContext : DbContext
{
    public ProjectDatabaseContext()
    {

    }

    public ProjectDatabaseContext(DbContextOptions<ProjectDatabaseContext> options) : base(options) { }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<ExchangeRate> ExchangeRates { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Rate> Rates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExchangeRate>(entity =>
        {
            entity.HasIndex(e => e.RatesId, "IX_ExchangeRates_RatesId");

            entity.Property(e => e.Date).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");
            entity.Property(e => e.Eur)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("EUR");

            entity.HasOne(d => d.Rates).WithMany(p => p.ExchangeRates).HasForeignKey(d => d.RatesId);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IX_Orders_CustomerId");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasIndex(e => e.OrderId, "IX_OrderDetails_OrderId");

            entity.Property(e => e.Price).HasColumnType("decimal(6, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails).HasForeignKey(d => d.OrderId);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.PriceTry)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("PriceTRY");
            entity.Property(e => e.PriceUsd)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("PriceUSD");
        });

        modelBuilder.Entity<Rate>(entity =>
        {
            entity.HasKey(e => e.RatesId);

            entity.Property(e => e.Try)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("TRY");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
