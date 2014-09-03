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
        public int VisitingSessionId { get; set; }

        [Required]
        [Display(Name="Patient Name")]
        public string PatientName { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PatientPhone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string PatientEmail { get; set; }

        [Display(Name = "Address")]
        public string PatientAddress { get; set; }

        [Display(Name = "Appointment Time")]
        public DateTime AppointmentTime { get; set; }
        public bool IsAppointmentComplete { get; set; }
        public bool IsAppointmentConfirm { get; set; }
        public bool IsNotificationSubscribed { get; set; }
    }
}