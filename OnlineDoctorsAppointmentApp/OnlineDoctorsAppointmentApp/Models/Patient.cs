using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineDoctorsAppointmentApp.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientPhone { get; set; }
        public string PatientEmail { get; set; }
    }
}