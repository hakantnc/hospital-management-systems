using HospitalSystem.Data;
using HospitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalSystem.Controllers
{
    public class DoctorController : Controller
    {
        HospitalContext db = new HospitalContext();
        // GET: Doctor
        public ActionResult Index()
        {
            if (Session["UserID"] == null || Session["UserRole"].ToString() != "Doctor")
            {
                return RedirectToAction("Login", "Account");
            }
            int currentUserId = (int)Session["UserID"];
            var doctor = db.Doctors.FirstOrDefault(d => d.UserID == currentUserId);

            if (doctor == null)
            {
                ViewBag.Error = "Doktor profiliniz bulunamadı.";
                return View(new System.Collections.Generic.List<Appointment>());
            }
            var today = DateTime.Today;
            ViewBag.TodayCount = db.Appointments
                                   .Count(a => a.DoctorID == doctor.UserID &&
                                               DbFunctions.TruncateTime(a.AppointmentDateTime) == today &&
                                               a.Status == "Aktif");

            var appointments = db.Appointments
                                 .Where(a => a.DoctorID == doctor.UserID)
                                 .Include(a => a.Patient)
                                 .Include(a => a.Patient.User)
                                 .OrderByDescending(a => a.AppointmentDateTime)
                                 .ToList();

            return View(appointments);

        }
    }
}