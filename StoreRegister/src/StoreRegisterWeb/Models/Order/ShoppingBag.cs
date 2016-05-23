using StoreRegisterWeb.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreRegisterWeb.Models.Order
{
    public class ShoppingBag
    {
        IList<ShoppingItem> _items = new List<ShoppingItem>();
        public IList<ShoppingItem> Items { get {return _items;}}

        public void AddItem(ShoppingItem item) 
        {
            _items.Add(item);
        }

    }


}
