using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineDoctorsAppointmentApp.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int ChamberId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentTime { get; set; }
        public bool IsAppointmentComplete { get; set; }
        public bool IsAppointmentConfirm { get; set; }
        public bool IsNotificationSubscribed { get; set; }
    }
}