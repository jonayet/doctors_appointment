using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineDoctorsAppointmentApp.Models;

namespace OnlineDoctorsAppointmentApp.Controllers
{
    [Authorize]
    public class ChamberController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: /Chamber/
        public ActionResult Index()
        {
            return View(db.Chambers.ToList());
        }

        // GET: /Chamber/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamber chamber = db.Chambers.Find(id);
            if (chamber == null)
            {
                return HttpNotFound();
            }
            return View(chamber);
        }

        // GET: /Chamber/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Chamber/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ChamberId,Name,Zone,Address")] Chamber chamber)
        {
            if (ModelState.IsValid)
            {
                db.Chambers.Add(chamber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chamber);
        }

        // GET: /Chamber/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamber chamber = db.Chambers.Find(id);
            if (chamber == null)
            {
                return HttpNotFound();
            }
            return View(chamber);
        }

        // POST: /Chamber/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ChamberId,Name,Zone,Address")] Chamber chamber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chamber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chamber);
        }

        // GET: /Chamber/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamber chamber = db.Chambers.Find(id);
            if (chamber == null)
            {
                return HttpNotFound();
            }
            return View(chamber);
        }

        // POST: /Chamber/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chamber chamber = db.Chambers.Find(id);
            db.Chambers.Remove(chamber);
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
