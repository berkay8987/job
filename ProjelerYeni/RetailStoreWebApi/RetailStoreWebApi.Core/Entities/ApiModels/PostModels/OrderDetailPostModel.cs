﻿using RetailStoreWebApi.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreWebApi.Core.Entities.ApiModels.PostModels
{
    public class OrderDetailPostModel
    {
        public int Quantity { get; set; }

        public int OrderId { get; set; }
    }
}
