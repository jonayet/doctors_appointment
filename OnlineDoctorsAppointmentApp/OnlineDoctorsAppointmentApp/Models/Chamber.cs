using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Razor.Text;

namespace OnlineDoctorsAppointmentApp.Models
{
    public class Chamber
    {
        public int ChamberId { get; set; }
        public string Location { get; set; }
        public int DocotrId { get; set; }
        public string VisitingTime { get; set; }

    }
}