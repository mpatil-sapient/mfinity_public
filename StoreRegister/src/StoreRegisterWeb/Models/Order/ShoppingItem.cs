using StoreRegisterWeb.Models.Enums;
using StoreRegisterWeb.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreRegisterWeb.Models.Order
{
    public class ShoppingItem
    {
        public ProductData Type { get; set; }
        public int Quantity { get; set; }
        public Status Status { get; set; }
    }
}
