using System;
using System.Collections.Generic;

namespace RetailStoreWebApp.Core.Entities.Models;

public partial class CustomersNew
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int IsActive { get; set; }

    public int IsDeleted { get; set; }
}
