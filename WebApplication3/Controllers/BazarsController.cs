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
    public class BazarsController : Controller
    {
        private BazarDbContext db = new BazarDbContext();

        // GET: Bazars
        public ActionResult Index()
        {
            return View(db.Bazars.ToList());
        }

        // GET: Bazars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bazar bazar = db.Bazars.Find(id);
            if (bazar == null)
            {
                return HttpNotFound();
            }
            return View(bazar);
        }

        // GET: Bazars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bazars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Name,Amount")] Bazar bazar)
        {
            if (ModelState.IsValid)
            {
                db.Bazars.Add(bazar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bazar);
        }

        // GET: Bazars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bazar bazar = db.Bazars.Find(id);
            if (bazar == null)
            {
                return HttpNotFound();
            }
            return View(bazar);
        }

        // POST: Bazars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Name,Amount")] Bazar bazar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bazar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bazar);
        }

        // GET: Bazars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bazar bazar = db.Bazars.Find(id);
            if (bazar == null)
            {
                return HttpNotFound();
            }
            return View(bazar);
        }

        // POST: Bazars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bazar bazar = db.Bazars.Find(id);
            db.Bazars.Remove(bazar);
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
