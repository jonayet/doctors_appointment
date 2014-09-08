using System.Collections.Generic;
using OnlineDoctorsAppointmentApp.Models;

namespace OnlineDoctorsAppointmentApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineDoctorsAppointmentApp.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "OnlineDoctorsAppointmentApp.Models.AppDbContext";
        }

        protected override void Seed(OnlineDoctorsAppointmentApp.Models.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Doctors.AddRange(new List<Doctor>()
            {
                new Doctor()
                {
                    Name = "Dr. Faisal",
                    Degree = "FRCS",
                    Specialization = "Child",
                    Email = "faisal.nstu@ymail.com",
                    Phone = "01520082621",
                    UserName = "faisal",
                    Password = "123456",
                    Fee = 500
                },
                new Doctor()
                {
                    Name = "Dr. Munna vai",
                    Degree = "MBBS",
                    Specialization = "All",
                    Email = "munna.vai@ymail.com",
                    Phone = "0172561002525",
                    UserName = "munna",
                    Password = "vai123",
                    Fee = 300
                },
                new Doctor()
                {
                    Name = "Dr. Azad",
                    Degree = "Haturi",
                    Specialization = "AllInOne",
                    Email = "azad.pms@gmail.com",
                    Phone = "0000000000",
                    UserName = "azaidda",
                    Password = "wellll",
                    Fee = 800
                },
            });

            context.Chambers.AddRange(new List<Chamber>()
            {
                new Chamber()
                {
                    Name = "Appolow",
                    Zone = "Dhanmondi",
                    Address = "Dhanmondi-5"
                },
                new Chamber()
                {
                    Name = "Popular",
                    Zone = "Mirpur",
                    Address = "Mirpur, original-10"
                },
                new Chamber()
                {
                    Name = "Lab Aid",
                    Zone = "Dhanmondi",
                    Address = "Dhanmondi-27"
                },
            });

            context.VisitingSessions.AddRange(new List<VisitingSession>()
            {
                new VisitingSession()
                {
                    StartTime = Convert.ToDateTime("10/9/2014 5:00 PM"),
                    EndTime = Convert.ToDateTime("10/9/2014 7:00 PM"),
                    DoctorId = 1,
                    ChamberId = 1,
                    MaxNoOfAppointments = 20,
                    TotalNoOfAppointments = 0,
                },
                new VisitingSession()
                {
                    StartTime = Convert.ToDateTime("11/9/2014 10:00 AM"),
                    EndTime = Convert.ToDateTime("11/9/2014 12:00 PM"),
                    DoctorId = 2,
                    ChamberId = 2,
                    MaxNoOfAppointments = 15,
                    TotalNoOfAppointments = 0,
                },
                new VisitingSession()
                {
                    StartTime = Convert.ToDateTime("12/9/2014 2:00 PM"),
                    EndTime = Convert.ToDateTime("12/9/2014 4:00 PM"),
                    DoctorId = 3,
                    ChamberId = 3,
                    MaxNoOfAppointments = 25,
                    TotalNoOfAppointments = 0,
                },
            });

            context.Appointments.AddRange(new List<Appointment>()
            {
                new Appointment()
                {
                    ChamberId = 1,
                    DoctorId = 2,
                    VisitingSessionId = 2,
                    PatientName = "Esmo Tar",
                    Problems = "hum",
                    PatientPhone = "01226645636",
                    PatientEmail = "esmo.ice@gmail.com",
                    PatientAddress = "Mirpur-1",
                    AppointmentTime = Convert.ToDateTime("10/9/2014 5:00 pm")
                },
                new Appointment()
                {
                    ChamberId = 2,
                    DoctorId = 3,
                    VisitingSessionId = 1,
                    PatientName = "Rumi",
                    Problems = "Migrane",
                    PatientPhone = "01226645636",
                    PatientEmail = "rumy@gmail.com",
                    PatientAddress = "Dhaka",
                    AppointmentTime = Convert.ToDateTime("11/9/2014 5:00 pm")
                },
                new Appointment()
                {
                    ChamberId = 3,
                    DoctorId = 1,
                    VisitingSessionId = 2,
                    PatientName = "Khalid",
                    Problems = "Fever",
                    PatientPhone = "01226645636",
                    PatientEmail = "khalid@gmail.com",
                    PatientAddress = "Badda",
                    AppointmentTime = Convert.ToDateTime("12/9/2014 5:00 pm")
                }
            });

            context.SaveChanges();
        }
    }
}
