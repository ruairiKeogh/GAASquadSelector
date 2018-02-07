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
    public class SelectorsController : Controller
    {
        private SquadContext db = new SquadContext();

        // GET: Selectors
        public ActionResult Index()
        {
            var selections = db.Selections.Include(s => s.Players).Include(s => s.Squad);
            return View(selections.ToList());
        }

        // GET: Selectors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Selector selector = db.Selections.Find(id);
            if (selector == null)
            {
                return HttpNotFound();
            }
            return View(selector);
        }

        // GET: Selectors/Create
        public ActionResult Create()
        {
            ViewBag.PlayerID = new SelectList(db.Players, "ID", "FirstName");
            ViewBag.SquadID = new SelectList(db.Squads, "SquadID", "Name");
            return View();
        }

        // POST: Selectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SelectionID,SquadID,PlayerID,Position")] Selector selector)
        {
            if (ModelState.IsValid)
            {
                db.Selections.Add(selector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerID = new SelectList(db.Players, "ID", "FirstName", selector.PlayerID);
            ViewBag.SquadID = new SelectList(db.Squads, "SquadID", "Name", selector.SquadID);
            return View(selector);
        }

        // GET: Selectors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Selector selector = db.Selections.Find(id);
            if (selector == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerID = new SelectList(db.Players, "ID", "FirstName", selector.PlayerID);
            ViewBag.SquadID = new SelectList(db.Squads, "SquadID", "Name", selector.SquadID);
            return View(selector);
        }

        // POST: Selectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SelectionID,SquadID,PlayerID,Position")] Selector selector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(selector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerID = new SelectList(db.Players, "ID", "FirstName", selector.PlayerID);
            ViewBag.SquadID = new SelectList(db.Squads, "SquadID", "Name", selector.SquadID);
            return View(selector);
        }

        // GET: Selectors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Selector selector = db.Selections.Find(id);
            if (selector == null)
            {
                return HttpNotFound();
            }
            return View(selector);
        }

        // POST: Selectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Selector selector = db.Selections.Find(id);
            db.Selections.Remove(selector);
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
