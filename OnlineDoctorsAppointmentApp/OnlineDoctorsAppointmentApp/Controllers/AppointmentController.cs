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

        public ActionResult Index(int? doctorId)
        {
            List<Appointment> appointments = new List<Appointment>();
            appointments = db.Appointments.Where(a => a.DoctorId == doctorId).ToList();
            return View(appointments);
        }



        [HttpGet]
        public ActionResult Create()
        {
            aDoctor = new Doctor();
            aDoctor = db.Doctors.Find(1);
            aChamber = new Chamber();
            aChamber = db.Chambers.Find(1);
            ViewBag.SelDoctor = aDoctor;
            ViewBag.SelChamber = aChamber;
            ViewBag.SerialNo = 23;
            ViewBag.AppointmentTime = "02/09/2014 10:00 AM";

            Appointment anAppointment = new Appointment();
            return View(anAppointment);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Appointment anAppointment)
        {
            db.Appointments.Add(anAppointment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult Details(int appointmentid)
        //{
        //    // Details to be created
        //    return View();
        //}
    }
}