using HospitalSystem.Data;
using HospitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalSystem.Controllers
{
    public class MedicalController : Controller
    {
        HospitalContext db = new HospitalContext();
        // GET: Medical
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int appointmentId)
        {
            if (Session["UserRole"]?.ToString() != "Doctor") return RedirectToAction("Login", "Account");

            var appointment = db.Appointments.Include("Patient").Include("Patient.User").FirstOrDefault(a => a.AppointmentID == appointmentId);

            if (appointment == null) return HttpNotFound();

            var existingRecord = db.MedicalRecords.FirstOrDefault(m => m.AppointmentID == appointmentId);
            if (existingRecord != null)
            {
                return RedirectToAction("Details", new { id = existingRecord.RecordID });
            }

            var model = new MedicalRecord
            {
                AppointmentID = appointment.AppointmentID,
                PatientID = appointment.PatientID,
                DoctorID = appointment.DoctorID,
                VisitDate = DateTime.Now
            };
            ViewBag.PatientName = appointment.Patient.User.FirstName + " " + appointment.Patient.User.LastName;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedicalRecord model)
        {
            if (ModelState.IsValid)
            { 
                db.MedicalRecords.Add(model);
                var apt= db.Appointments.Find(model.AppointmentID);
                apt.Status = "Tamamlandı";
                db.SaveChanges();
                return RedirectToAction("Details", new { id = model.RecordID });
            }
            return View(model);

        }

        public ActionResult Details(int id)
        {
            var record = db.MedicalRecords
                .Include("Patient")
                .Include("Patient.User")
                .Include("Doctor")
                .Include("Doctor.User")
                .Include("Prescriptions")
                .FirstOrDefault(m => m.RecordID == id);
            if (record == null) return HttpNotFound();

            int currentUserId = (int)Session["UserID"];

            return View(record);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPrescription(int RecordID, string MedicationName, string Dosage, string Instructions)
        {
            if(Session["UserRole"]?.ToString() != "Doctor") return HttpNotFound();

            var pres = new Prescription
            {
                RecordID = RecordID,
                MedicationName = MedicationName,
                Dosage = Dosage,
                Instructions = Instructions
            };
            db.Prescriptions.Add(pres);
            db.SaveChanges();
            return RedirectToAction("Details", new { id = RecordID });
        }

        public ActionResult History()
        {
            if (Session["UserRole"] == null || Session["UserRole"].ToString() != "Patient")
                return RedirectToAction("Login", "Account");

            int userId = (int)Session["UserID"];
            var patient = db.Patients.FirstOrDefault(p => p.UserID == userId);
            if (patient == null)
          
            {
                ViewBag.Error = "Hasta profiliniz bulunamadı.";
                return View(new List<MedicalRecord>());
            }

            var list = db.MedicalRecords
                         .Include("Doctor")
                         .Include("Doctor.User")
                         .Include("Doctor.Department")
                         .Where(m => m.PatientID == patient.User.UserID)
                         .OrderByDescending(m => m.VisitDate)
                         .ToList();

            return View(list);
        }
    }

    }
