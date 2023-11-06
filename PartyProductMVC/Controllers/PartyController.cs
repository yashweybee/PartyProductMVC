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
    }
}