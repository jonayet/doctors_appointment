using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OnlineDoctorsAppointmentApp.Models
{
    public class VisitingSessions
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ChamberId { get; set; }
        public int DoctorId { get; set; }
        public int MaxNoOfAppointments { get; set; }

        public virtual Doctor Doctors { get; set; }
        public virtual Chamber Chambers { get; set; }

        public List<Appointment> AppointmentList { get; set; } 
    }
}