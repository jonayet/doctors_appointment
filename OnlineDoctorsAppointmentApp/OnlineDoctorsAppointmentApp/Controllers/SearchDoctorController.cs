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
    public class SearchDoctorController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: /SearchDoctor/
        public ActionResult Index()
        {
            ViewBag.ChamberId = new SelectList(db.Chambers, "ChamberId", "Name");
            ViewBag.ChamberZone = new SelectList(db.Chambers, "ChamberId", "Zone");
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName");
            ViewBag.Specialization = new SelectList(db.Doctors, "DoctorId", "Specialization");
            var doctors = db.VisitingSessions.Include(v => v.Chambers).Include(v => v.Doctors);
            return View(doctors.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int? DoctorId, string Specialization, int? ChamberId, string ChamberZone, string dateSearchTextbox, string searchTextbox)
        {
            ViewBag.ChamberId = new SelectList(db.Chambers, "ChamberId", "Name");
            ViewBag.ChamberZone = new SelectList(db.Chambers, "ChamberId", "Zone");
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName");
            ViewBag.Specialization = new SelectList(db.Doctors, "DoctorId", "Specialization");

            List<VisitingSession> adoctorList = new List<VisitingSession>();
            if (ModelState.IsValid)
            {
                if (DoctorId != null)
                {
                    adoctorList = db.VisitingSessions.Where(c => c.DoctorId == DoctorId).ToList();
                }
                else if (Specialization != null)
                {
                    adoctorList = db.VisitingSessions.Where(c => c.Doctors.Specialization.Contains(Specialization)).ToList();
                }
                else if (ChamberId != null)
                {
                    adoctorList = db.VisitingSessions.Where(c => c.ChamberId == ChamberId).ToList();
                }
                else if (ChamberZone != null)
                {
                    adoctorList = db.VisitingSessions.Where(c => c.Chambers.Zone.Contains(ChamberZone)).ToList();
                }
                else if (dateSearchTextbox != null)
                {
                    // adoctorList = db.VisitingSessions.Where(c => c.StartTime == ((DateTime)dateSearchTextbox)).ToList();
                }
                else if (searchTextbox != null)
                {
                    adoctorList = db.VisitingSessions.Where(c => c.Chambers.Name.Contains(searchTextbox)).ToList();
                }
            }
            return View(adoctorList);
        }

    }
}