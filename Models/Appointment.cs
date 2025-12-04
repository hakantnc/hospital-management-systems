using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalSystem.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        [ForeignKey("PatientID")]
        public virtual Patient Patient { get; set; }

        public int DoctorID { get; set; } 
        [ForeignKey("DoctorID")]
        public virtual Doctor Doctor { get; set; }

        public DateTime AppointmentDateTime { get; set; } 
        public string Status { get; set; } 
        public string Reason { get; set; } 
    }
}