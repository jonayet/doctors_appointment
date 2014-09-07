using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineDoctorsAppointmentApp.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        
        [Required]
        [Display (Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        public string Degree { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Specialization { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        [Required]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Fee")]
        public double Fee { get; set; }
    }
}