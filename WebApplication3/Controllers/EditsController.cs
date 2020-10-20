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
    public class EditsController : Controller
    {
        private EditDbContext db = new EditDbContext();

        // GET: Edits
        public ActionResult Index()
        {
            return View(db.Edits.ToList());
        }

        // GET: Edits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Edit edit = db.Edits.Find(id);
            if (edit == null)
            {
                return HttpNotFound();
            }
            return View(edit);
        }

        // GET: Edits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Edits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AddBalance,AddMeal")] Edit edit)
        {
            if (ModelState.IsValid)
            {
                db.Edits.Add(edit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(edit);
        }

        // GET: Edits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Edit edit = db.Edits.Find(id);
            if (edit == null)
            {
                return HttpNotFound();
            }
            return View(edit);
        }

        // POST: Edits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AddBalance,AddMeal")] Edit edit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(edit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(edit);
        }

        // GET: Edits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Edit edit = db.Edits.Find(id);
            if (edit == null)
            {
                return HttpNotFound();
            }
            return View(edit);
        }

        // POST: Edits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Edit edit = db.Edits.Find(id);
            db.Edits.Remove(edit);
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
