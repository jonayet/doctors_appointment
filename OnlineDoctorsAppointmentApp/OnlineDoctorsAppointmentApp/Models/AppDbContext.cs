using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineDoctorsAppointmentApp.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext() : base("AppDbConnectionString")
        {
            
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Chamber> Chambers { get; set; }
        public DbSet<VisitingSession> VisitingSessions { get; set; }

        public System.Data.Entity.DbSet<OnlineDoctorsAppointmentApp.Models.SearchDoctor> SearchDoctors { get; set; } 
      
    }
}