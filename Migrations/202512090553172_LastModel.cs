namespace HospitalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "UserID", "dbo.Users");
            DropForeignKey("dbo.Patients", "UserID", "dbo.Users");
            DropForeignKey("dbo.Appointments", "DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.MedicalRecords", "DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.Appointments", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.MedicalRecords", "PatientID", "dbo.Patients");
            DropPrimaryKey("dbo.Doctors");
            DropPrimaryKey("dbo.Patients");
            AddColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Users", "Phone", c => c.String());
            AddColumn("dbo.Users", "TCKN", c => c.String(nullable: false));
            AddColumn("dbo.Users", "DateOfBirth", c => c.DateTime());
            AddColumn("dbo.Users", "Gender", c => c.String());
            AddPrimaryKey("dbo.Doctors", "UserID");
            AddPrimaryKey("dbo.Patients", "UserID");
            AddForeignKey("dbo.Doctors", "UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.Patients", "UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.Appointments", "DoctorID", "dbo.Doctors", "UserID");
            AddForeignKey("dbo.MedicalRecords", "DoctorID", "dbo.Doctors", "UserID");
            AddForeignKey("dbo.Appointments", "PatientID", "dbo.Patients", "UserID");
            AddForeignKey("dbo.MedicalRecords", "PatientID", "dbo.Patients", "UserID");
            DropColumn("dbo.Doctors", "DoctorID");
            DropColumn("dbo.Doctors", "FirstName");
            DropColumn("dbo.Doctors", "LastName");
            DropColumn("dbo.Doctors", "PhoneNumber");
            DropColumn("dbo.Patients", "PatientID");
            DropColumn("dbo.Patients", "FirstName");
            DropColumn("dbo.Patients", "LastName");
            DropColumn("dbo.Patients", "DateOfBirth");
            DropColumn("dbo.Patients", "Gender");
            DropColumn("dbo.Patients", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "PhoneNumber", c => c.String());
            AddColumn("dbo.Patients", "Gender", c => c.String());
            AddColumn("dbo.Patients", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Patients", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Patients", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Patients", "PatientID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Doctors", "PhoneNumber", c => c.String());
            AddColumn("dbo.Doctors", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Doctors", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Doctors", "DoctorID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.MedicalRecords", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.MedicalRecords", "DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.Appointments", "DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.Patients", "UserID", "dbo.Users");
            DropForeignKey("dbo.Doctors", "UserID", "dbo.Users");
            DropPrimaryKey("dbo.Patients");
            DropPrimaryKey("dbo.Doctors");
            DropColumn("dbo.Users", "Gender");
            DropColumn("dbo.Users", "DateOfBirth");
            DropColumn("dbo.Users", "TCKN");
            DropColumn("dbo.Users", "Phone");
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "FirstName");
            AddPrimaryKey("dbo.Patients", "PatientID");
            AddPrimaryKey("dbo.Doctors", "DoctorID");
            AddForeignKey("dbo.MedicalRecords", "PatientID", "dbo.Patients", "PatientID");
            AddForeignKey("dbo.Appointments", "PatientID", "dbo.Patients", "PatientID");
            AddForeignKey("dbo.MedicalRecords", "DoctorID", "dbo.Doctors", "DoctorID");
            AddForeignKey("dbo.Appointments", "DoctorID", "dbo.Doctors", "DoctorID");
            AddForeignKey("dbo.Patients", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.Doctors", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
    }
}
