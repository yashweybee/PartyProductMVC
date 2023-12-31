﻿using PartyProductMVC.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

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


        [Authorize(Roles = "Admin")]
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


        [Authorize(Roles = "Admin")]


        public ActionResult Edit(int? Id)
        {
            ViewBag.ListParty = _context.Party;
            ViewBag.ListProduct = _context.Product;
            var assignEdit = _context.AssignParty.Include(p => p.Party).Include(pr => pr.Product).First(a => a.AsId == Id);
            return View("Edit", assignEdit);
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