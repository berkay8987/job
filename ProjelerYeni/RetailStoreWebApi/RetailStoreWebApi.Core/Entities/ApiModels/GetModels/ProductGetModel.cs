using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreWebApi.Core.Entities.ApiModels.GetModels
{
    public class ProductGetModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal PriceUsd { get; set; }

        public decimal PriceTry { get; set; }
    }
}
