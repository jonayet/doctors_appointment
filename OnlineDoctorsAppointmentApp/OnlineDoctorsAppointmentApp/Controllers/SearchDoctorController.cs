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
        VisitingSession aSession = new VisitingSession();
        // GET: /SearchDoctor/
        public ActionResult Index()
        {
            ViewBag.ChamberId = new SelectList(db.Chambers, "ChamberId", "Name");
            ViewBag.ChamberZone = new SelectList(db.Chambers, "ChamberId", "Zone");
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name");
            ViewBag.SpecializationId = new SelectList(db.Doctors, "DoctorId", "Specialization");
            var visitingSessions = db.VisitingSessions.Include(v => v.Chamber).Include(v => v.Doctor);

            // get all no of seat avilable
            foreach (VisitingSession visitingSession in visitingSessions)
            {
                visitingSession.TotalNoOfAppointments = db.Appointments.Count(a => a.VisitingSessionId == visitingSession.VisitingSessionId);
            }

            ViewBag.doctorList = visitingSessions.ToList();
            return View(new VisitingSession());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int? DoctorId, int? SpecializationId, int? ChamberId, int? ChamberZone, DateTime? dateSearchTextbox, string searchTextbox)
        {
            ViewBag.ChamberId = new SelectList(db.Chambers, "ChamberId", "Name");
            ViewBag.ChamberZone = new SelectList(db.Chambers, "ChamberId", "Zone");
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name");
            ViewBag.SpecializationId = new SelectList(db.Doctors, "DoctorId", "Specialization");

            List<VisitingSession> visitingSessions = new List<VisitingSession>();
            if (ModelState.IsValid)
            {
                if (DoctorId != null)
                {
                    visitingSessions = db.VisitingSessions.Where(c => c.Doctor.DoctorId == DoctorId).ToList();
                }
                else if (SpecializationId != null)
                {
                    string specialization = db.Doctors.Find(SpecializationId).Specialization;
                    visitingSessions = db.VisitingSessions.Where(c => c.Doctor.Specialization.Contains(specialization)).ToList();
                }
                else if (ChamberId != null)
                {
                    visitingSessions = db.VisitingSessions.Where(c => c.Chamber.ChamberId == ChamberId).ToList();
                }
                else if (ChamberZone != null)
                {
                    string area = db.Chambers.Find(ChamberZone).Zone;
                    visitingSessions = db.VisitingSessions.Where(c => c.Chamber.Zone.Contains(area)).ToList();
                }
                else if(dateSearchTextbox != null)
                {
                    visitingSessions = db.VisitingSessions.Where(c => c.StartTime == dateSearchTextbox).ToList();
                }
                else if (searchTextbox != null)
                {
                    visitingSessions = db.VisitingSessions.Where(
                        vs =>
                            vs.Doctor.Name.Contains(searchTextbox) ||
                            vs.Doctor.Specialization.Contains(searchTextbox)
                            || vs.Chamber.Name.Contains(searchTextbox) || vs.Chamber.Zone.Contains(searchTextbox))
                        .ToList();
                }

                // get all no of seat avilable
                foreach (VisitingSession visitingSession in visitingSessions)
                {
                    visitingSession.TotalNoOfAppointments = db.Appointments.Count(a => a.VisitingSessionId == visitingSession.VisitingSessionId);
                }

                ViewBag.doctorList = visitingSessions;
            }
            return View();
        }

    }
}