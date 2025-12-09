using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalSystem.Models
{
    public class Patient
    {
        [Key, ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        public string Address { get; set; } 
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}