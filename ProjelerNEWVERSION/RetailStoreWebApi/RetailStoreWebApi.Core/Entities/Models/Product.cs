using System;
using System.Collections.Generic;

namespace RetailStoreWebApi.Core.Entities.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal PriceUsd { get; set; }

    public int IsActive { get; set; }

    public int IsDeleted { get; set; }

    public decimal PriceTry { get; set; }
}
