using GAASquadSelector.DAL;
using GAASquadSelector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GAASquadSelector.Controllers
{
    public class SquadSelectorController : Controller
    {
        SquadContext db = new SquadContext();
        

        // GET: SquadSelector
        public ActionResult Index()
        {
            var players = from s in db.Players
                          select s;
            ViewBag.data = players;
            return View();
        }

        public ActionResult ReturnPlayers(string sortOrder)
        {
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "first_name_desc" : "";
            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "last_name_desc" : "";
            ViewBag.PositionSortParm = String.IsNullOrEmpty(sortOrder) ? "Position" : "Position";
            var players = from s in db.Players
                          select s;
            switch (sortOrder)
            {
                case "first_name_desc":
                    players = players.OrderByDescending(p => p.FirstName);
                    break;
                case "last_name_desc":
                    players = players.OrderByDescending(p => p.LastName);
                    break;
                case "Position":
                    players = players.OrderBy(p => p.Position);
                    break;
                default:
                    players = players.OrderBy(p => p.FirstName);
                    break;
            }

            return View(players.ToList());
        }
        
        public ActionResult SelectPosition(Selector selection)
        {
            if (ModelState.IsValid)
            {
                db.Selections.Add(selection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(selection);
        }
    }
}