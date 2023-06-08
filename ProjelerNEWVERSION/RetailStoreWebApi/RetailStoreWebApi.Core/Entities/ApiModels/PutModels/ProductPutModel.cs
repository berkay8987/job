using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreWebApi.Core.Entities.ApiModels.PutModels
{
    public class ProductPutModel
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal PriceUsd { get; set; }
    }
}
