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
        [Authorize]
        public ActionResult Index(String sortOrder)
        {
            SquadSelector model = new SquadSelector();
            model.Players = db.Players.ToList();
            model.Positions = RetrievePositions();
            return View(model);
        }

        public List<Player> ReturnPlayers(String sortOrder)
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

            return players.ToList();
        }
        
        public List<Positions> RetrievePositions()
        {
            return Enum.GetValues(typeof(Positions))
                    .Cast<Positions>()
                    .ToList();
        }
    }
}