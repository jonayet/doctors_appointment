using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineDoctorsAppointmentApp.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; private set; }
        public string ChamberOfAppointment { get; set; }
        public int DoctorId { get;private set; }
        public DateTime AppointmentTime { get; set; }
    }
}