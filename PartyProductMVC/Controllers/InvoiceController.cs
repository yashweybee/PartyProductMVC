using PartyProductMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity

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
        // GET: Invoice
        public ActionResult Index()
        {
            //var InvoiceDbContext = _context.Invoice.Include(p => p.Party).
            return View();
        }
    }
}