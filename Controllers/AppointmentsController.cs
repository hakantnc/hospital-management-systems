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
    public class AppointmentsController : Controller
    {
        HospitalContext db = new HospitalContext();
        // GET: Appointments
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int currentUserId = (int)Session["UserID"];

            var appointments = db.Appointments
                                 .Where(a => a.PatientID == currentUserId)
                                 .Include(a => a.Doctor)
                                 .Include(a => a.Doctor.User)
                                 .Include(a => a.Doctor.Department)
                                 .OrderByDescending(a => a.AppointmentDateTime) //en yenisini en üste getirmek için
                                 .ToList();

            return View(appointments);
        }

        public ActionResult Create()
            {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
            return View();
        }

        public JsonResult GetDoctorByDepartment(int departmentId) { 
        
            var doctors = db.Doctors
                            .Where(d => d.DepartmentID == departmentId)
                            .Include("User")
                            .Select(d => new
                            {
                                Value = d.UserID,
                                Text = d.User.FirstName + " " + d.User.LastName
                            })
                            .ToList();
            return Json(doctors, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Appointment appointment)
        {
            if (Session["UserID"] == null) return RedirectToAction("Login", "Account");
            appointment.PatientID = (int)Session["UserID"];
            appointment.Status = "Aktif";

            if(appointment.AppointmentDateTime < DateTime.Now)
            {
                ModelState.AddModelError("", "Geçmiş Bir Tarihe Randevu Alamazsınız.");
            }
            bool isBusy = db.Appointments.Any(
                a => a.DoctorID == appointment.DoctorID
                &&
                a.AppointmentDateTime == appointment.AppointmentDateTime && a.Status != "İptal");
        
            if(isBusy)
            {
                ModelState.AddModelError("", "Seçtiğiniz Saatte Doktorun Başka Randevusu Var.");
            }
            if(ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
            return View(appointment);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancel(int id)
        {
            if (Session["UserID"] == null) return RedirectToAction("Login", "Account");
            int currentUserId = (int)Session["UserID"];
            var appointment = db.Appointments.Find(id);

            if (appointment != null && appointment.PatientID == currentUserId && appointment.AppointmentDateTime > DateTime.Now)
                {
                appointment.Status = "İptal";
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}