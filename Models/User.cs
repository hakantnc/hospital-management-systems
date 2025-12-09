using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalSystem.Models
{
    public class User
    {
        [Required(ErrorMessage = "İsim alanı zorunludur.")]
        [StringLength(100, ErrorMessage ="İsim en fazla 100 karakter olabilir.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyisim alanı zorunludur.")]
        [StringLength(100, ErrorMessage = "Soyisim en fazla 100 karakter olabilir.")]
        public string LastName{ get; set; }

        [Phone(ErrorMessage = "Lütfen geçerli bir telfon numarası giriniz.")]

        [StringLength(11)]

        public string Phone {  get; set; }

        [Required(ErrorMessage = "TC Kimlik No zorunludur.")]

        [StringLength(12)]

        public string TCKN { get; set; }
        public DateTime? DateOfBirth {  get; set; }
        public string Gender { get; set; }

        [Key]
        public int UserID { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual Doctor DoctorProfile { get; set; }
        public virtual Patient PatientProfile { get; set; }
        /*User üzerinden doktor veya hasta profiline erişmek için sanal class oluşturuldu.*/
    }
}