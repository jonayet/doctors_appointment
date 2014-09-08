using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineDoctorsAppointmentApp.Models;

namespace OnlineDoctorsAppointmentApp.Controllers
{
    public class AppointmentController : Controller
    {
        AppDbContext db = new AppDbContext();
        private Doctor aDoctor;
        private Chamber aChamber;
        private VisitingSession aVisitingSession;

        public ActionResult Index()
        {
            var appointments = db.Appointments.ToList();
            return View(appointments);
        }

        public ActionResult Index1(int? doctorId)
        {
            List<Appointment> appointments = new List<Appointment>();
            appointments = db.Appointments.Where(a => a.DoctorId == doctorId).ToList();
            //return View(appointments);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            aDoctor = db.Doctors.Find(1);
            aChamber = db.Chambers.Find(1);
            aVisitingSession = db.VisitingSessions.Find(2);
            ViewBag.SelectedDoctor = aDoctor;
            ViewBag.SelectedChamber = aChamber;
            ViewBag.SelectedVisitingSession = aVisitingSession;
            ViewBag.AppointmentTime = "02/09/2014 10:00 AM";
            ViewBag.SerialNo = "SN001";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Appointment anAppointment)
        {
            db.Appointments.Add(anAppointment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}