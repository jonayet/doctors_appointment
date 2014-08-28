using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineDoctorsAppointmentApp.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int ChamberId { get; set; }
        public int DoctorId { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public string PatientPhone { get; set; }
        public string PatientEmail { get; set; }
        public DateTime AppointmentTime { get; set; }
        public bool IsAppointmentComplete { get; set; }
        public bool IsAppointmentConfirm { get; set; }
        public bool IsNotificationSubscribed { get; set; }
    }
}