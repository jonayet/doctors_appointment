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

        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Display(Name = "Zone")]
        public string Zone { get; set; }
        
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}