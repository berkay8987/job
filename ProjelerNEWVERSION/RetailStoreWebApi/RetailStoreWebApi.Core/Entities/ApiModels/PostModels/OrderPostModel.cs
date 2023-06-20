using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreWebApi.Core.Entities.ApiModels.PostModels
{
    public class OrderPostModel
    {
        public int CustomerId { get; set; }

        public int ProductId { get; set; }
    }
}
