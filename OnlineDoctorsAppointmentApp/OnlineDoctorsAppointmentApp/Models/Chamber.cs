using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Razor.Text;

namespace OnlineDoctorsAppointmentApp.Models
{
    public class Chamber
    {
        public int ChamberId { get; set; }
        public string Name { get; set; }
        public string Zone { get; set; }
        public string Address { get; set; }
        public List<VisitingSession> VisitingSessions { get; set; }
    }
}