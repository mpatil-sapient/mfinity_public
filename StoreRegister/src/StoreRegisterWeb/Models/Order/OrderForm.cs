using StoreRegisterWeb.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreRegisterWeb.Models.Order
{
    public class OrderForm
    {
        public string ShoppingCounter { get; set; }
        public IList<ProductData> Products { get; set; }
    }
}
