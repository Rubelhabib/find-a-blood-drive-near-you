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
    public class RequisitionsController : Controller
    {
        private Blood_PageEntitiesNew db = new Blood_PageEntitiesNew();

        // GET: Requisitions
        public ActionResult Index()
        {
            var requisitions = db.Requisitions.Include(r => r.District).Include(r => r.Group).Include(r => r.Thana);
            return View(requisitions.ToList());
        }

        // GET: Requisitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisition requisition = db.Requisitions.Find(id);
            if (requisition == null)
            {
                return HttpNotFound();
            }
            return View(requisition);
        }

        // GET: Requisitions/Create
        public ActionResult Create()
        {
            ViewBag.District_ID = new SelectList(db.Districts, "ID", "Name");
            ViewBag.Group_ID = new SelectList(db.Groups, "ID", "Name");
            ViewBag.Thana_ID = new SelectList(db.Thanas, "ID", "Name");
            return View();
        }

        // POST: Requisitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Group_ID,District_ID,Thana_ID,Message,Required_Date,Status")] Requisition requisition)
        {
            if (ModelState.IsValid)
            {
                db.Requisitions.Add(requisition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.District_ID = new SelectList(db.Districts, "ID", "Name", requisition.District_ID);
            ViewBag.Group_ID = new SelectList(db.Groups, "ID", "Name", requisition.Group_ID);
            ViewBag.Thana_ID = new SelectList(db.Thanas, "ID", "Name", requisition.Thana_ID);
            return View(requisition);
        }

        // GET: Requisitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisition requisition = db.Requisitions.Find(id);
            if (requisition == null)
            {
                return HttpNotFound();
            }
            ViewBag.District_ID = new SelectList(db.Districts, "ID", "Name", requisition.District_ID);
            ViewBag.Group_ID = new SelectList(db.Groups, "ID", "Name", requisition.Group_ID);
            ViewBag.Thana_ID = new SelectList(db.Thanas, "ID", "Name", requisition.Thana_ID);
            return View(requisition);
        }

        // POST: Requisitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Group_ID,District_ID,Thana_ID,Message,Required_Date,Status")] Requisition requisition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requisition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.District_ID = new SelectList(db.Districts, "ID", "Name", requisition.District_ID);
            ViewBag.Group_ID = new SelectList(db.Groups, "ID", "Name", requisition.Group_ID);
            ViewBag.Thana_ID = new SelectList(db.Thanas, "ID", "Name", requisition.Thana_ID);
            return View(requisition);
        }

        // GET: Requisitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisition requisition = db.Requisitions.Find(id);
            if (requisition == null)
            {
                return HttpNotFound();
            }
            return View(requisition);
        }

        // POST: Requisitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Requisition requisition = db.Requisitions.Find(id);
            db.Requisitions.Remove(requisition);
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
