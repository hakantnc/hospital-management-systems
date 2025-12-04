using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalSystem.Models
{
    public class Prescription
    {
        [Key]
        public int PrescriptionID { get; set; } 
        public int RecordID { get; set; } 
        [ForeignKey("RecordID")]
        public virtual MedicalRecord MedicalRecord { get; set; }

        public string MedicationName { get; set; } 
        public string Dosage { get; set; }
        public string Instructions { get; set; } 
    }
}