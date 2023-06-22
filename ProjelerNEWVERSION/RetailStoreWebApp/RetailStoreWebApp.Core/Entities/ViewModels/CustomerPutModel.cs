using RetailStoreWebApp.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreWebApp.Core.Entities.ViewModels
{
    public class CustomerPutModel
    {
        public int CustomerId { get; set; }

        public string Email { get; set; } = null!;
    }
}
