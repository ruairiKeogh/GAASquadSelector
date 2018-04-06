using GAASquadSelector.DAL;
using GAASquadSelector.Models;
using Microsoft.AspNet.Identity;
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
            model.Players = ReturnPlayers(sortOrder);
            model.Squads = ReturnSquads();
            return View(model);
        }

        public List<Squad> ReturnSquads()
        {
            var squads = from s in db.Squads select s;
            squads = squads.OrderBy(p => p.Date);
            return squads.ToList();
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
                    players = players.OrderBy(p => p.Position == "Goalkeeper" ? 1 :
                                                    p.Position == "Defender" ? 2 :
                                                    p.Position == "Midfielder" ? 3 : 4);
                    break;
                default:
                    players = players.OrderBy(p => p.FirstName);
                    break;
            }
            string userId = User.Identity.GetUserId();

            return players.Where(u => u.UserID == userId).ToList();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SquadSelector squad)
        {
            if (ModelState.IsValid)
            {
                Squad newSquad = new Squad
                {
                    Date = DateTime.Now,
                    Name = squad.Name
                };

                List<Selector> selections = new List<Selector>();
                squad.Players = ReturnPlayers("Position");
                foreach (var player in squad.Players)
                {
                    //int num=db.Selections.Count();
                    //num++;
                    if (squad.Checked == true)
                    {
                        Selector selector = new Selector
                        {
                            
                            PlayerID = player.ID,
                            SquadID = newSquad.SquadID,
                            Position = squad.positions
                        };
                        selections.Add(selector);
                        db.Selections.Add(selector);
                    }
                }

                newSquad.Selections = selections;
                
                db.Squads.Add(newSquad);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(squad);
        }
    }
}