using System;
using System.Collections.Generic;

namespace RetailStoreWebApi.Core.Entities.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public int OrderId { get; set; }

    public int IsActive { get; set; }

    public int IsDeleted { get; set; }

    public virtual Order Order { get; set; } = null!;
}
