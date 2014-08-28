using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineDoctorsAppointmentApp.Models
{
    public class VisitingSession
    {
        public int VisitingSessionId { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public int MaxNoOfAppointments { get; set; }
        public int DoctorId { get; set; }
        public int ChamberId { get; set; }
        
        public List<Appointment> Appointments { get; set; }
    }
}