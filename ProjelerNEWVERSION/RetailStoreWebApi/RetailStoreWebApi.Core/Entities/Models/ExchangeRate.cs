using System;
using System.Collections.Generic;

namespace RetailStoreWebApi.Core.Entities.Models;

public partial class ExchangeRate
{
    public int ExchangeRateId { get; set; }

    public decimal Eur { get; set; }

    public DateTime Date { get; set; }

    public int RatesId { get; set; }

    public virtual Rate Rates { get; set; } = null!;
}
