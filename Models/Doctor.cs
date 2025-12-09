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
        [Key, ForeignKey("User")]
        public int UserID { get; set; }
  
        public virtual User User { get; set; }
        public int DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }


        public string Specialization { get; set; } 
        public string LicenseNumber { get; set; } 
        public string Biography { get; set; } 

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}