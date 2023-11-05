using PartyProductMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyProductMVC.Controllers
{
    public class PartyController : Controller
    {
        // GET: Party
        public ActionResult Index()
        {
            var party = new List<Party>()
            {
                new Party(){Id=1, PartyName = "Party1"},
                new Party(){Id=2, PartyName = "Party2"},
                new Party(){Id=3, PartyName = "Part31"}

            };
            return View(party);
        }
    }
}