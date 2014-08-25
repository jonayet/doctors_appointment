﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineDoctorsAppointmentApp.Models
{
    public class Doctors
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Degree { get; set; }
        public string Specialization { get; set; }
        public string DoctorEmail { get; set; }
        public string DoctorPhone { get; set; }
        public string ChamberLocation { get; set; }
        public DateTime VisitingTime { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ImagePath { get; set; }
        public double DoctorFee { get; set; }

        public List<Appointments> Appointments { get; set; }

    }
}