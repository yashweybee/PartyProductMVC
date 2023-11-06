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
        private ApplicationDbContext _context;
        public ProductController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Product
        public ActionResult Index()
        {
            var products = _context.Product;

            return View(products);
        }
        public ActionResult Add()
        {
            var products = new Product();
            return View(products);
        }


        [HttpPost]
        public ActionResult Save(Product product)
        {
            Product p = new Product()
            {
                ProductName = product.ProductName
            };
            _context.Product.Add(p);
            _context.SaveChanges();

            return RedirectToAction("Index", "Product");
        }
    }
}