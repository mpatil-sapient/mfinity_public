using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using StoreRegisterWeb.Models.Order;
using StoreRegisterWeb.Models.Product;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreRegisterWeb.Controllers
{
    public class OrderController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            OrderForm OrderForm = new OrderForm();
            OrderForm.ShoppingCounter = "1";
            OrderForm.Products = new List<ProductData>();
            OrderForm.Products.Add(new ProductData(1, "Bottle"));
            OrderForm.Products.Add(new ProductData(1, "Book"));
            return View(OrderForm);
        }

        public IActionResult ReactSample()
        {
            OrderForm OrderForm = new OrderForm();
            OrderForm.ShoppingCounter = "1";
            OrderForm.Products = new List<ProductData>();
            OrderForm.Products.Add(new ProductData(1, "Bottle"));
            OrderForm.Products.Add(new ProductData(1, "Book"));
            return View(OrderForm);
        }
    
        public IActionResult RaiseError()
        {
            throw new Exception("Error!");
        }
    }
}
