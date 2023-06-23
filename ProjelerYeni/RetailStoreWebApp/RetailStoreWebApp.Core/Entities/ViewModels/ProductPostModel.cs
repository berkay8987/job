using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreWebApp.Core.Entities.ViewModels
{
    public class ProductPostModel
    {
        public string ProductName { get; set; } = null!;

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal PriceUsd { get; set; }
    }
}
