﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Tshirt.Models
{
    public class ProductToTransfer
    {
        public long quantity { get; set; }
        public long quantityAvailable { get; set; }
        public string productCode { get; set; }
        public string productDescription { get; set; }
    }
}
