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
    [AllowAnonymous]
    public class SearchDoctorController : Controller
    {
        private AppDbContext db = new AppDbContext();
        VisitingSession aSession = new VisitingSession();
        // GET: /SearchDoctor/
        [AllowAnonymous]
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

        public PartialViewResult Search(int? DoctorId, int? SpecializationId, int? ChamberId, int? ChamberZone, DateTime? SearchDate, string SearchText)
        {
            ViewBag.ChamberId = new SelectList(db.Chambers, "ChamberId", "Name");
            ViewBag.ChamberZone = new SelectList(db.Chambers, "ChamberId", "Zone");
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "Name");
            ViewBag.SpecializationId = new SelectList(db.Doctors, "DoctorId", "Specialization");

            List<VisitingSession> visitingSessions = new List<VisitingSession>();
            if (ModelState.IsValid)
            {
                if (SearchText != null && SearchText != "")
                {
                    visitingSessions = db.VisitingSessions.Where(
                        vs =>
                            vs.Doctor.Name.Contains(SearchText) ||
                            vs.Doctor.Specialization.Contains(SearchText)
                            || vs.Chamber.Name.Contains(SearchText) || vs.Chamber.Zone.Contains(SearchText))
                        .ToList();
                }
                else
                {
                    bool IsMultiSearch = false;
                    if (DoctorId != null)
                    {
                        if (visitingSessions.Count > 0)
                        {
                            visitingSessions = visitingSessions.Where(c => c.Doctor.DoctorId == DoctorId).ToList();
                        }
                        else
                        {
                            visitingSessions = db.VisitingSessions.Where(c => c.Doctor.DoctorId == DoctorId).ToList();
                        }
                    }

                    if (SpecializationId != null)
                    {
                        IsMultiSearch = DoctorId != null || ChamberId != null || ChamberZone != null || SearchDate != null;
                        string specialization = db.Doctors.Find(SpecializationId).Specialization;
                        if (visitingSessions.Count > 0)
                        {
                            visitingSessions = visitingSessions.Where(c => c.Doctor.Specialization == specialization).ToList();
                        }
                        else
                        {
                            if (!IsMultiSearch)
                                visitingSessions = db.VisitingSessions.Where(c => c.Doctor.Specialization == specialization).ToList();
                        }
                    }

                    if (ChamberId != null)
                    {
                        IsMultiSearch = DoctorId != null || SpecializationId != null || ChamberZone != null || SearchDate != null;
                        if (visitingSessions.Count > 0)
                        {
                            visitingSessions = visitingSessions.Where(c => c.Chamber.ChamberId == ChamberId).ToList();
                        }
                        else
                        {
                            if (!IsMultiSearch)
                                visitingSessions = db.VisitingSessions.Where(c => c.Chamber.ChamberId == ChamberId).ToList();
                        }
                    }

                    if (ChamberZone != null)
                    {
                        IsMultiSearch = DoctorId != null || SpecializationId != null || ChamberId != null || SearchDate != null;
                        string area = db.Chambers.Find(ChamberZone).Zone;
                        if (visitingSessions.Count > 0)
                        {
                            visitingSessions = visitingSessions.Where(c => c.Chamber.Zone == area).ToList();
                        }
                        else
                        {
                            if (!IsMultiSearch)
                                visitingSessions = db.VisitingSessions.Where(c => c.Chamber.Zone == area).ToList();
                        }
                    }

                    if (SearchDate != null)
                    {
                        IsMultiSearch = DoctorId != null || SpecializationId != null || ChamberId != null || ChamberZone != null;
                        if (visitingSessions.Count > 0)
                        {

                            visitingSessions = visitingSessions.Where(c => c.StartTime == SearchDate).ToList();
                        }
                        else
                        {
                            if (!IsMultiSearch)
                                visitingSessions = db.VisitingSessions.Where(c => c.StartTime == SearchDate).ToList();
                        }
                    } 
                }

                // get all no of seat avilable
                foreach (VisitingSession visitingSession in visitingSessions)
                {
                    visitingSession.TotalNoOfAppointments = db.Appointments.Count(a => a.VisitingSessionId == visitingSession.VisitingSessionId);
                }

                ViewBag.doctorList = visitingSessions;
            }
            //return PartialView(visitingSessions);
            return PartialView("~/Views/SearchDoctor/_DoctorListPartial.cshtml", visitingSessions);
        }
    }
}