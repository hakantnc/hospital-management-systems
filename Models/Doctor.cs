using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalSystem.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }


        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
        public int DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; } 

        public string Specialization { get; set; } 
        public string LicenseNumber { get; set; } 
        public string PhoneNumber { get; set; }
        public string Biography { get; set; } 

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}