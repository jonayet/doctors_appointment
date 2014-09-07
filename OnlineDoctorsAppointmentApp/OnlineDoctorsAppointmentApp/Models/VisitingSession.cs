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

        [Display(Name = "Doctor's Name")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        [Display(Name = "Chamber")]
        public int ChamberId { get; set; }
        public virtual Chamber Chamber { get; set; }

        public int AppointmentId { get; set; }

        [Display(Name = "Maximum No Of Appointment")]
        public int MaxNoOfAppointments { get; set; }

        public int TotalNoOfAppointments { get; set; }
    }
}