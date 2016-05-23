using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreRegisterWeb.Models.Product
{
    public class ProductData
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ProductData(long id, string name)
        {
            Id = id; Name = name;
        }
    }
}
