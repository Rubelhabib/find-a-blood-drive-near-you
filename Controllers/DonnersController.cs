using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blood_Page.Models;

namespace Blood_Page.Controllers
{
    public class DonnersController : Controller
    {
        private Blood_PageEntitiesNew db = new Blood_PageEntitiesNew();

        // GET: Donners
        public ActionResult Index()
        {
            var donner = db.Donners.Include(d => d.Group);
            return View(donner.ToList());
        }

        // GET: Donners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donner donner = db.Donners.Find(id);
            if (donner == null)
            {
                return HttpNotFound();
            }
            return View(donner);
        }

        // GET: Donners/Create
        public ActionResult Create()
        {
            ViewBag.Group_ID = new SelectList(db.Groups, "ID", "Name");
            return View();
        }

        // POST: Donners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Contact,Group_ID,Email,District_ID,Thana_ID,Address,Last_Donated_On,Status,Date_Of_Brith")] Donner donner)
        {
            if (ModelState.IsValid)
            {
                db.Donners.Add(donner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Group_ID = new SelectList(db.Groups, "ID", "Name", donner.Group_ID);
            return View(donner);
        }

        // GET: Donners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donner donner = db.Donners.Find(id);
            if (donner == null)
            {
                return HttpNotFound();
            }
            ViewBag.Group_ID = new SelectList(db.Groups, "ID", "Name", donner.Group_ID);
            return View(donner);
        }

        // POST: Donners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Contact,Group_ID,Email,District_ID,Thana_ID,Address,Last_Donated_On,Status,Date_Of_Brith")] Donner donner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Group_ID = new SelectList(db.Groups, "ID", "Name", donner.Group_ID);
            return View(donner);
        }

        // GET: Donners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donner donner = db.Donners.Find(id);
            if (donner == null)
            {
                return HttpNotFound();
            }
            return View(donner);
        }

        // POST: Donners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donner donner = db.Donners.Find(id);
            db.Donners.Remove(donner);
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
