using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineDoctorsAppointmentApp.Models
{
    public class SearchDoctor
    {
        public int   SearchDoctorId { get; set; }
        public int VisitingSessionId { get; set; }
        public virtual VisitingSession VisitingSessions { get; set; }
    }
}