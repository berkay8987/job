using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_HangfireProject.Core.Entities.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        public int IsActive { get; set; }

        public int IsDeleted { get; set; }

        public Order Order { get; set; } = null!;
    }
}
