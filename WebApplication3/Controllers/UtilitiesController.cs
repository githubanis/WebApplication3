using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class UtilitiesController : Controller
    {
        private UtilityDbContext db = new UtilityDbContext();

        // GET: Utilities
        public ActionResult Index()
        {
            return View(db.Utilities.ToList());
        }

        // GET: Utilities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utility utility = db.Utilities.Find(id);
            if (utility == null)
            {
                return HttpNotFound();
            }
            return View(utility);
        }

        // GET: Utilities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Name,Amount")] Utility utility)
        {
            if (ModelState.IsValid)
            {
                db.Utilities.Add(utility);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(utility);
        }

        // GET: Utilities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utility utility = db.Utilities.Find(id);
            if (utility == null)
            {
                return HttpNotFound();
            }
            return View(utility);
        }

        // POST: Utilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Name,Amount")] Utility utility)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utility).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(utility);
        }

        // GET: Utilities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utility utility = db.Utilities.Find(id);
            if (utility == null)
            {
                return HttpNotFound();
            }
            return View(utility);
        }

        // POST: Utilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utility utility = db.Utilities.Find(id);
            db.Utilities.Remove(utility);
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
