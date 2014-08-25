using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineDoctorsAppointmentApp.Models
{
    public class Appointments
    {
        public int AppointmentId { get; set; }
        public string PatientPhone { get; set; }
        public string PatientEmail { get; set; }
        public string ChamberOfAppointment { get; set; }
        public DateTime AppointmentTime { get; set; }
    }
}