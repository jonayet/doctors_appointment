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
    public class VisitingSessionController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: /VisitingSession/
        public ActionResult Index()
        {
            var visitingsessions = db.VisitingSessions.Include(v => v.Chamber).Include(v => v.Doctor);
            return View(visitingsessions.ToList());
        }

        // GET: /VisitingSession/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitingSession visitingsession = db.VisitingSessions.Find(id);
            if (visitingsession == null)
            {
                return HttpNotFound();
            }
            return View(visitingsession);
        }

        // GET: /VisitingSession/Create
        public ActionResult Create()
        {
            ViewBag.ChamberId = new SelectList(db.Chambers, "ChamberId", "Name");
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name");
            return View();
        }

        // POST: /VisitingSession/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="VisitingSessionId,StartTime,EndTime,ChamberId,DoctorId,MaxNoOfAppointments")] VisitingSession visitingsession)
        {
            if (ModelState.IsValid)
            {
                db.VisitingSessions.Add(visitingsession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChamberId = new SelectList(db.Chambers, "ChamberId", "Name", visitingsession.ChamberId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name", visitingsession.DoctorId);
            return View(visitingsession);
        }

        // GET: /VisitingSession/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitingSession visitingsession = db.VisitingSessions.Find(id);
            if (visitingsession == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChamberId = new SelectList(db.Chambers, "ChamberId", "Name", visitingsession.ChamberId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name", visitingsession.DoctorId);
            return View(visitingsession);
        }

        // POST: /VisitingSession/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="VisitingSessionId,StartTime,EndTime,ChamberId,DoctorId,MaxNoOfAppointments")] VisitingSession visitingsession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitingsession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChamberId = new SelectList(db.Chambers, "ChamberId", "Name", visitingsession.ChamberId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name", visitingsession.DoctorId);
            return View(visitingsession);
        }

        // GET: /VisitingSession/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitingSession visitingsession = db.VisitingSessions.Find(id);
            if (visitingsession == null)
            {
                return HttpNotFound();
            }
            return View(visitingsession);
        }

        // POST: /VisitingSession/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VisitingSession visitingsession = db.VisitingSessions.Find(id);
            db.VisitingSessions.Remove(visitingsession);
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
