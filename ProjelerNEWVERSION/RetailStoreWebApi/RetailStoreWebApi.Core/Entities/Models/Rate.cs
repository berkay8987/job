using System;
using System.Collections.Generic;

namespace RetailStoreWebApi.Core.Entities.Models;

public partial class Rate
{
    public int RatesId { get; set; }

    public decimal Try { get; set; }

    public virtual ICollection<ExchangeRate> ExchangeRates { get; set; } = new List<ExchangeRate>();
}
