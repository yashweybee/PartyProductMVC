using PartyProductMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PartyProductMVC.Controllers
{
    public class AssignPartyController : Controller
    {
        private ApplicationDbContext _context;
        public AssignPartyController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: AssignParty
        public ActionResult Index()
        {
            var AssignParties = _context.AssignParty.Include(p => p.Party).Include(p => p.Product).ToList();
            return View(AssignParties);
        }

        public ActionResult Delete(int id)
        {
            var AssignPartyDb = _context.AssignParty.SingleOrDefault(ap => ap.AsId == id);
            _context.AssignParty.Remove(AssignPartyDb);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Add()
        {
            var party = _context.Party;
            var product = _context.Product;

            ViewBag.list1 = party;
            ViewBag.list2 = product;
            return View("Add");
        }

        [HttpPost]
        public ActionResult Save(AssignParty assignParty)
        {
            AssignParty ap = new AssignParty()
            {
                PartyId = assignParty.Party.PartyId,
                ProductId = assignParty.Product.ProductId

            };
            _context.AssignParty.Add(ap);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var assignParty = _context.AssignParty.SingleOrDefault(ap => ap.AsId == id);
            ViewBag.listParty = _context.Party;
            ViewBag.listProduct = _context.Product;
            return View("Edit", assignParty);
        }

        public ActionResult SaveEdit(AssignParty assignParty)
        {
            AssignParty ap = new AssignParty()
            {
                PartyId = assignParty.Party.PartyId,
                ProductId = assignParty.Product.ProductId
            };
            var AssignPartyDbContext = _context.AssignParty.SingleOrDefault(apr => apr.AsId == assignParty.AsId);
            AssignPartyDbContext.PartyId = ap.PartyId;
            AssignPartyDbContext.ProductId = ap.ProductId;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}