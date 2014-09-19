using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        public ActionResult Create(int? DoctorId, int? ChamberId, int? VisitingSessionId)
        {
            aDoctor = db.Doctors.Find(DoctorId);
            aChamber = db.Chambers.Find(ChamberId);
            aVisitingSession = db.VisitingSessions.Find(VisitingSessionId);
            ViewBag.SelectedDoctor = aDoctor;
            ViewBag.SelectedChamber = aChamber;
            ViewBag.SelectedVisitingSession = aVisitingSession;

            TimeSpan timeDiff = aVisitingSession.EndTime - aVisitingSession.StartTime;
            int servingTime = (int)timeDiff.TotalMinutes;
            int totalNoOfAppointments =
                db.Appointments.Count(a => a.VisitingSessionId == aVisitingSession.VisitingSessionId);
            int timeSlotPerPatient = servingTime/aVisitingSession.MaxNoOfAppointments;

            ViewBag.AppointmentTime = aVisitingSession.StartTime.AddMinutes(totalNoOfAppointments * timeSlotPerPatient);
            ViewBag.SerialNo = "SN" + totalNoOfAppointments.ToString("000");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Appointment anAppointment)
        {
            db.Appointments.Add(anAppointment);
            db.SaveChanges();
            var drName = db.Doctors.Find(anAppointment.DoctorId);
            var chamber = db.Chambers.Find(anAppointment.ChamberId);
            string appointmentConfirmationMessage = "Your Appointment with " + drName.Name + " has been confirmed at " +
                                                    anAppointment.AppointmentTime + " at " + chamber.Name + ". Please be there at time.";
            SendMail(anAppointment.PatientEmail, "Appointment Confirmation", appointmentConfirmationMessage);
            return RedirectToAction("Index");
        }

        public void SendMail(string address, string subject, string body)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("tomalinfotech.bd@gmail.com");
            msg.To.Add(address);
            msg.Body = body;
            msg.IsBodyHtml = false;
            msg.Subject = subject;
            SmtpClient smt = new SmtpClient("smtp.gmail.com");
            smt.Port = 587;
            smt.Credentials = new NetworkCredential("tomalinfotech.bd@gmail.com", "tomalinfo");
            smt.EnableSsl = true;
            smt.Send(msg);
            //string script = "<script>alert('Mail Sent Successfully');self.close();</script>";
            //this.ClientScript.RegisterClientScriptBlock(this.GetType(), "sendMail", script);
        }

    }
}