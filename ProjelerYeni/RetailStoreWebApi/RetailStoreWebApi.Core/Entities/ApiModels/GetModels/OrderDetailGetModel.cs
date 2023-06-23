using RetailStoreWebApi.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreWebApi.Core.Entities.ApiModels.GetModels
{
    public class OrderDetailGetModel
    {
        public int OrderDetailId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int OrderId { get; set; }
    }
}
