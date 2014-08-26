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
        [Display (Name = "Doctor's Name")]
        public string DoctorName { get; set; }
        public string Degree { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        
        public string Specialization { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Doctor's Email")]
        
        public string DoctorEmail { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Doctor's phone")]
        [Required]
        public string DoctorPhone { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Display(Name = "Image")]
        public string ImageName { get; set; }
        [Display(Name = "Doctor's Fee")]
        [Required]
        public double DoctorFee { get; set; }
        public int ChamberId { get; set; }
        public virtual Chamber Chamber{ get; set; }

    }
}