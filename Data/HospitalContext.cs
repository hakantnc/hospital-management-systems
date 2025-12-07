using HospitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalSystem.Data
{
    public class HospitalContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasRequired(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Appointment>()
                .HasRequired(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MedicalRecord>()
                .HasRequired(m => m.Patient)
                .WithMany() 
                .HasForeignKey(m => m.PatientID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MedicalRecord>()
                .HasRequired(m => m.Doctor)
                .WithMany()
                .HasForeignKey(m => m.DoctorID)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }



        public HospitalContext() : base("name=HospitalDBConnection")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
    }
}