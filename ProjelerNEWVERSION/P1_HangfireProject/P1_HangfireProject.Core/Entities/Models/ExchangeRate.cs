/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace P1_HangfireProject.Core.Entities.Models
{
    public class ExchangeRate
    {
        public int ExchangeRateId { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal EUR { get; set; }

        [JsonPropertyName("rates.TRY")]
        [Column(TypeName = "decimal(6,2)")]
        public decimal TRY { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
    }
}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace P1_HangfireProject.Core.Entities.Models
{
    public class ExchangeRate
    {
        public int ExchangeRateId { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal EUR { get; set; }

        [JsonPropertyName("rates")]
        public Rates Rates { get; set; } = null!;

        public int RatesId { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
    }

    public class Rates
    {
        public int RatesId { get; set; }

        [JsonPropertyName("TRY")]
        [Column(TypeName = "decimal(6,2)")]
        public decimal TRY { get; set; }
    }
}
