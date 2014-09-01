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

        public ActionResult Index(int? doctorId)
        {
            List<Appointment> appointments = new List<Appointment>();
            appointments = db.Appointments.Where(a => a.DoctorId == doctorId).ToList();
            return View(appointments);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(int chamberId, int doctorId, string patientName, string patientPhone, string patientEmail, DateTime appointmenTime, bool isNotificationSubscribed)
        {
            Appointment appointment = new Appointment()
            {
                AppointmentTime = appointmenTime,
                ChamberId = chamberId,
                DoctorId = doctorId,
                PatientName = patientName,
                PatientEmail = patientEmail,
                PatientPhone = patientPhone,
                IsNotificationSubscribed = isNotificationSubscribed,
                IsAppointmentComplete = false,
                IsAppointmentConfirm = false
            };

            db.Appointments.Add(appointment);
            return View();
        }

        public ActionResult Details(int appointmentid)
        {
            // Details to be created
        }
    }
}