using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GAASquadSelector.DAL;
using GAASquadSelector.Models;

namespace GAASquadSelector.Controllers
{
    public class SquadsController : Controller
    {
        private SquadContext db = new SquadContext();

        // GET: Squads
        public ActionResult Index()
        {
            return View(db.Squads.ToList());
        }

        // GET: Squads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Squad squad = db.Squads.Find(id);
            if (squad == null)
            {
                return HttpNotFound();
            }
            return View(squad);
        }

        // GET: Squads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Squads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SquadID,Name,Date")] Squad squad)
        {
            if (ModelState.IsValid)
            {
                db.Squads.Add(squad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(squad);
        }

        // GET: Squads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Squad squad = db.Squads.Find(id);
            if (squad == null)
            {
                return HttpNotFound();
            }
            return View(squad);
        }

        // POST: Squads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SquadID,Name,Date")] Squad squad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(squad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(squad);
        }

        // GET: Squads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Squad squad = db.Squads.Find(id);
            if (squad == null)
            {
                return HttpNotFound();
            }
            return View(squad);
        }

        // POST: Squads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Squad squad = db.Squads.Find(id);
            db.Squads.Remove(squad);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
