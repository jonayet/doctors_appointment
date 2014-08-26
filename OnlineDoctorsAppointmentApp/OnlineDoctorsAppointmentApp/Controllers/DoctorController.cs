using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineDoctorsAppointmentApp.Models;

namespace OnlineDoctorsAppointmentApp.Controllers
{
    public class DoctorController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: /Doctor/
        public ActionResult Index()
        {
            var doctors = db.Doctors.Include(d => d.Chamber);
            return View(doctors.ToList());
        }

        // GET: /Doctor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: /Doctor/Create
        public ActionResult Create()
        {
            //ViewBag.ChamberId = new SelectList(db.Chambers, "ChamberId", "Location");
            return View();
        }

        // POST: /Doctor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="DoctorId,DoctorName,Degree,Specialization,DoctorEmail,DoctorPhone,UserName,Password,ImageName,DoctorFee")] Doctor doctor, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    imageFile.SaveAs(Path.Combine(Server.MapPath("~/Images/"), imageFile.FileName));
                    doctor.ImageName = imageFile.FileName;
                }
                doctor.Chamber= new Chamber();
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.ChamberId = new SelectList(db.Chambers, "ChamberId", "Location", doctor.ChamberId);
            return View(doctor);
        }

        // GET: /Doctor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChamberId = new SelectList(db.Chambers, "ChamberId", "Location", doctor.ChamberId);
            return View(doctor);
        }

        // POST: /Doctor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DoctorId,DoctorName,Degree,Specialization,DoctorEmail,DoctorPhone,UserName,Password,ImageName,DoctorFee,ChamberId")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChamberId = new SelectList(db.Chambers, "ChamberId", "Location", doctor.ChamberId);
            return View(doctor);
        }

        // GET: /Doctor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: /Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
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
