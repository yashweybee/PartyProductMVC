﻿using PartyProductMVC.Models;
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

        public ActionResult Save(AssignParty assignParty)
        {
            return View();
        }
    }
}