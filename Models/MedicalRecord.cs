using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalSystem.Models
{
    public class MedicalRecord
    {
        [Key]
        public int RecordID { get; set; } 
        public int AppointmentID { get; set; }
        [ForeignKey("AppointmentID")]
        public virtual Appointment Appointment { get; set; }

        public int PatientID { get; set; } 
        [ForeignKey("PatientID")]
        public virtual Patient Patient { get; set; }


        public int DoctorID { get; set; } 
        [ForeignKey("DoctorID")]
        public virtual Doctor Doctor { get; set; }

        public string Diagnosis { get; set; }
        public string Symptoms { get; set; }
        public string DoctorNotes { get; set; }

        [DataType(DataType.Date)]
        public DateTime VisitDate { get; set; } 
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}