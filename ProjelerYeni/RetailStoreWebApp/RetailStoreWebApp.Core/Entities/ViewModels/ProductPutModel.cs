using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreWebApp.Core.Entities.ViewModels
{
    public class ProductPutModel
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName="decimal(6,2)")]
        public decimal PriceUsd { get; set; }
    }
}
