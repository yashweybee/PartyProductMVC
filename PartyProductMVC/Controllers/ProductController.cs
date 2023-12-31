﻿using PartyProductMVC.Models;
using System.Linq;
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

        [Authorize(Roles = "Admin")]
        public ActionResult Add()
        {
            var products = new Product();
            return View(products);
        }


        [HttpPost]
        public ActionResult Save(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");

            }
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
            if (!ModelState.IsValid)
            {
                return View("Edit");

            }
            Product p = new Product()
            {
                ProductName = product.ProductName
            };

            var productContextDb = _context.Product.SingleOrDefault(pr => pr.ProductId == product.ProductId);
            productContextDb.ProductName = product.ProductName;

            _context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }


        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var product = _context.Product.SingleOrDefault(p => p.ProductId == id);
            return View("Edit", product);
        }

        public ActionResult Delete(int id)
        {
            var product = _context.Product.SingleOrDefault(p => p.ProductId == id);
            _context.Product.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}