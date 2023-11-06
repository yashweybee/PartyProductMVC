using PartyProductMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace PartyProductMVC.Controllers
{
    public class PartyController : Controller
    {

        private ApplicationDbContext _context;

        public PartyController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Party
        public ActionResult Index()
        {
            var party = _context.Party;
            return View(party);
        }

        public ActionResult Add()
        {
            var party = new Party();
            return View(party);
        }


        [HttpPost]
        public ActionResult Save(Party party)
        {
            Party p = new Party()
            {
                PartyName = party.PartyName
            };
            _context.Party.Add(p);
            _context.SaveChanges();

            return RedirectToAction("Index", "Party");
        }

        public ActionResult SaveEdit(Party party)
        {
            Party p = new Party()
            {
                PartyName = party.PartyName
            };

            var partyContextDb = _context.Party.SingleOrDefault(pr => pr.Id == pr.Id);
            partyContextDb.PartyName = party.PartyName;

            _context.SaveChanges();
            return RedirectToAction("Index", "Party");
        }

        public ActionResult Edit(int id)
        {
            var party = _context.Party.SingleOrDefault(p => p.Id == id);
            return View("Edit", party);

        }
    }
}