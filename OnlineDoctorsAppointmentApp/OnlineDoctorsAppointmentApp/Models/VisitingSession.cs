using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineDoctorsAppointmentApp.Models
{
    public class VisitingSession
    {
        public int VisitingSessionId { get; set; }
        public int DoctorId { get; set; }
        public int ChamberId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}