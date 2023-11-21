using PartyProductMVC.Models;
using System.Linq;
using System.Web.Mvc;

namespace PartyProductMVC.Controllers
{
    public class InvoiceController : Controller
    {
        private ApplicationDbContext _context;

        public InvoiceController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        [Authorize(Roles = "Admin")]
        // GET: Invoice
        public ActionResult Index()
        {
            ViewBag.PartyName = (from AssignParty in _context.AssignParty
                                 join Party in _context.Party
                                 on AssignParty.PartyId equals Party.PartyId
                                 select new
                                 {
                                     partyName = Party.PartyName
                                 }).Distinct();
            return View();
        }

        public ActionResult GetProduct(string partyName)
        {
            var products = (
                from assignParty in _context.AssignParty
                join product in _context.Product on assignParty.ProductId equals product.ProductId
                join party in _context.Party on assignParty.PartyId equals party.PartyId
                join productRate in _context.ProductRate on assignParty.ProductId equals productRate.ProductId
                where party.PartyName == partyName
                select new SelectListItem()
                {
                    Value = product.ProductName,
                    Text = product.ProductName
                }
            ).ToList();

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProductRate(string productName)
        {
            var Rate = (
                from productRate in _context.ProductRate
                join product in _context.Product on productRate.ProductId equals product.ProductId
                where product.ProductName == productName
                orderby productRate.DateOfRate
                select new
                {
                    Rate = productRate.Rate
                }
                ).SingleOrDefault();

            return Json(Rate, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddInvoice(Invoice invoice)
        {
            _context.Invoice.Add(invoice);
            _context.SaveChanges();
            return Json(new { });
        }
    }
}