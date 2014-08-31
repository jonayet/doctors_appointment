using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Razor.Text;

namespace OnlineDoctorsAppointmentApp.Models
{
    public class Chamber
    {
        public int ChamberId { get; set; }
        [Display(Name = "Chamber's Name")]
        public string Name { get; set; }
        [Display(Name = "Chamber's Zone")]
        public string Zone { get; set; }
        [Display(Name = "Chamber's Address")]
        public string Address { get; set; }
        public List<VisitingSession> VisitingSessions { get; set; }
    }
}