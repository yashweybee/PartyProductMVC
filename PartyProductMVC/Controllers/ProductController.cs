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



        [HttpPost]
        public ActionResult SaveEdit(Product product)
        {
            Product p = new Product()
            {
                ProductName = product.ProductName
            };

            var productContextDb = _context.Product.SingleOrDefault(pr => pr.Id == product.Id);
            productContextDb.ProductName = product.ProductName;

            _context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        public ActionResult Edit(int id)
        {
            var product = _context.Product.SingleOrDefault(p => p.Id == id);
            return View("Edit", product);
        }
    }
}