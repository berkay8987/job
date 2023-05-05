using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriSiparisUygulamasi.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string Name { get; set; } = null!;

        public string? Phone { get; set; }

        public int Balance { get; set; }

        public ICollection<Order> Orders { get; set; } = null!;
    }
}
