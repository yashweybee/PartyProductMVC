using PartyProductMVC.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace PartyProductMVC.Controllers
{
    public class ProductRateController : Controller
    {
        private ApplicationDbContext _context;
        public ProductRateController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: ProductRate
        public ActionResult Index()
        {
            var ProductRate = _context.ProductRate.Include(pr => pr.Product).ToList();

            return View(ProductRate);
        }
        public ActionResult Add()
        {
            var Products = _context.Product;
            ViewBag.products = Products;
            return View("Add");
        }

        [HttpPost]
        public ActionResult Save(ProductRate Product_Rate)
        {
            ProductRate pr = new ProductRate()
            {
                ProductId = Product_Rate.Product.ProductId,
                Rate = Product_Rate.Rate,
                DateOfRate = Product_Rate.DateOfRate,
            };
            _context.ProductRate.Add(pr);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var productRate = _context.ProductRate.Include(p => p.Product).SingleOrDefault(pr => pr.ProductRateId == id);
            return View("Edit", productRate);
        }


        public ActionResult SaveEdit(ProductRate Product_Rate)
        {
            ProductRate ProRate = new ProductRate()
            {
                Rate = Product_Rate.Rate,
                DateOfRate = Product_Rate.DateOfRate
            };
            var ProductRateDbContext = _context.ProductRate.SingleOrDefault(pr => pr.ProductRateId == Product_Rate.ProductRateId);
            ProductRateDbContext.Rate = ProRate.Rate;
            ProductRateDbContext.DateOfRate = ProRate.DateOfRate;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var productRateDbContext = _context.ProductRate.SingleOrDefault(pr => pr.ProductRateId == id);
            _context.ProductRate.Remove(productRateDbContext);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}