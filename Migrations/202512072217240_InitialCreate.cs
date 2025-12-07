namespace HospitalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentID = c.Int(nullable: false, identity: true),
                        PatientID = c.Int(nullable: false),
                        DoctorID = c.Int(nullable: false),
                        AppointmentDateTime = c.DateTime(nullable: false),
                        Status = c.String(),
                        Reason = c.String(),
                    })
                .PrimaryKey(t => t.AppointmentID)
                .ForeignKey("dbo.Doctors", t => t.DoctorID)
                .ForeignKey("dbo.Patients", t => t.PatientID)
                .Index(t => t.PatientID)
                .Index(t => t.DoctorID);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Specialization = c.String(),
                        LicenseNumber = c.String(),
                        PhoneNumber = c.String(),
                        Biography = c.String(),
                    })
                .PrimaryKey(t => t.DoctorID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 100),
                        PasswordHash = c.String(nullable: false),
                        Role = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.PatientID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.MedicalRecords",
                c => new
                    {
                        RecordID = c.Int(nullable: false, identity: true),
                        AppointmentID = c.Int(nullable: false),
                        PatientID = c.Int(nullable: false),
                        DoctorID = c.Int(nullable: false),
                        Diagnosis = c.String(),
                        Symptoms = c.String(),
                        DoctorNotes = c.String(),
                        VisitDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecordID)
                .ForeignKey("dbo.Appointments", t => t.AppointmentID, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorID)
                .ForeignKey("dbo.Patients", t => t.PatientID)
                .Index(t => t.AppointmentID)
                .Index(t => t.PatientID)
                .Index(t => t.DoctorID);
            
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        PrescriptionID = c.Int(nullable: false, identity: true),
                        RecordID = c.Int(nullable: false),
                        MedicationName = c.String(),
                        Dosage = c.String(),
                        Instructions = c.String(),
                    })
                .PrimaryKey(t => t.PrescriptionID)
                .ForeignKey("dbo.MedicalRecords", t => t.RecordID, cascadeDelete: true)
                .Index(t => t.RecordID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prescriptions", "RecordID", "dbo.MedicalRecords");
            DropForeignKey("dbo.MedicalRecords", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.MedicalRecords", "DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.MedicalRecords", "AppointmentID", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.Patients", "UserID", "dbo.Users");
            DropForeignKey("dbo.Appointments", "DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "UserID", "dbo.Users");
            DropForeignKey("dbo.Doctors", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.Prescriptions", new[] { "RecordID" });
            DropIndex("dbo.MedicalRecords", new[] { "DoctorID" });
            DropIndex("dbo.MedicalRecords", new[] { "PatientID" });
            DropIndex("dbo.MedicalRecords", new[] { "AppointmentID" });
            DropIndex("dbo.Patients", new[] { "UserID" });
            DropIndex("dbo.Doctors", new[] { "DepartmentID" });
            DropIndex("dbo.Doctors", new[] { "UserID" });
            DropIndex("dbo.Appointments", new[] { "DoctorID" });
            DropIndex("dbo.Appointments", new[] { "PatientID" });
            DropTable("dbo.Prescriptions");
            DropTable("dbo.MedicalRecords");
            DropTable("dbo.Patients");
            DropTable("dbo.Users");
            DropTable("dbo.Departments");
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
        }
    }
}
