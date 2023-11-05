using PartyProductMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyProductMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = new List<Product>()
        {
            new Product { Id = 1, ProductName = "Pen"},
            new Product { Id = 2,ProductName = "Pencil"},
            new Product { Id = 3,ProductName = "Paper"}
        };

            return View(products);
        }
    }
}