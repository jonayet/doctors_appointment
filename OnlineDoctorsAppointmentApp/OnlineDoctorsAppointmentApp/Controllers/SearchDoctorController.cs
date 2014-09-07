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
            ViewBag.SpecializationId = new SelectList(db.Doctors, "DoctorId", "Specialization");
            var doctors = db.VisitingSessions.Include(v => v.Chambers).Include(v => v.Doctors);
            ViewBag.doctorList = doctors.ToList();
            return View(new VisitingSession());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int? DoctorId, int? SpecializationId, int? ChamberId, int? ChamberZone, DateTime? dateSearchTextbox, string searchTextbox)
        {
            ViewBag.ChamberId = new SelectList(db.Chambers, "ChamberId", "Name");
            ViewBag.ChamberZone = new SelectList(db.Chambers, "ChamberId", "Zone");
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName");
            ViewBag.SpecializationId = new SelectList(db.Doctors, "DoctorId", "Specialization");

            List<VisitingSession> adoctorList = new List<VisitingSession>();
            if (ModelState.IsValid)
            {
                if (DoctorId != null)
                {
                    adoctorList = db.VisitingSessions.Where(c => c.Doctors.DoctorId == DoctorId).ToList();
                }
                else if (SpecializationId != null)
                {
                    string specialization = db.Doctors.Find(SpecializationId).Specialization;
                    adoctorList = db.VisitingSessions.Where(c => c.Doctors.Specialization.Contains(specialization)).ToList();
                }
                else if (ChamberId != null)
                {
                    adoctorList = db.VisitingSessions.Where(c => c.Chambers.ChamberId == ChamberId).ToList();
                }
                else if (ChamberZone != null)
                {
                    string area = db.Chambers.Find(ChamberZone).Zone;
                    adoctorList = db.VisitingSessions.Where(c => c.Chambers.Zone.Contains(area)).ToList();
                }
                else if(dateSearchTextbox != null)
                {
                    adoctorList = db.VisitingSessions.Where(c => c.StartTime == dateSearchTextbox).ToList();
                }
                else if (searchTextbox != null)
                {

                    adoctorList = db.VisitingSessions.Where(
                        vs =>
                            vs.Doctors.DoctorName.Contains(searchTextbox) ||
                            vs.Doctors.Specialization.Contains(searchTextbox)
                            || vs.Chambers.Name.Contains(searchTextbox) || vs.Chambers.Zone.Contains(searchTextbox))
                        .ToList();
                }
                //ViewBag.NoOfAppoinments = adoctorList[0].AppointmentList.Count;
                ViewBag.doctorList = adoctorList;
            }
            return View();
        }

    }
}