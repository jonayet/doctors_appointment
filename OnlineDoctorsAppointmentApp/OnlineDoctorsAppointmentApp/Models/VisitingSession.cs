using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineDoctorsAppointmentApp.Models
{
    public class VisitingSession
    {
        public int VisitingSessionId { get; set; }
        [Display(Name="Start Time")]
        public DateTime StartTime { get; set; }
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
        [Display(Name = "Chamber")]
        public int ChamberId { get; set; }
        [Display(Name = "Doctor's Name")]
        public int DoctorId { get; set; }
        [Display(Name = "Maximum No Of Appointment")]
        public int MaxNoOfAppointments { get; set; }

        public virtual Doctor Doctors { get; set; }
        public virtual Chamber Chambers { get; set; }

        public List<Appointment> AppointmentList { get; set; } 
    }
}