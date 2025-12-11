using HospitalSystem.Data;
using HospitalSystem.Helpers;
using HospitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.Win32;

namespace HospitalSystem.Controllers
{
    public class AdminController : Controller
    {
        HospitalContext db = new HospitalContext();

        private void LoadDepartments()
        {
            List<Department> departments = db.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(departments, "DepartmentID", "DepartmentName");
        }
        public ActionResult AddDoctor()
        {
            if (Session["UserRole"]?.ToString() != "Admin") return RedirectToAction("Login", "Account");
            LoadDepartments();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDoctor(User user, Doctor doctor)
        {
            if (Session["UserRole"]?.ToString() != "Admin") return RedirectToAction("Login", "Account");

            ModelState.Remove("user.Role");
            ModelState.Remove("doctor.User");
            ModelState.Remove("doctor.UserID");

            if (ModelState.IsValid)
            {
                if (db.Users.Any(u => u.Email == user.Email))
                {
                    ViewBag.Error = "Bu Email zaten kayıtlı.";
                    LoadDepartments();
                    return View();
                }


                if (db.Users.Any(u => u.TCKN == user.TCKN))
                {
                    ViewBag.Error = "Bu TC Kimlik Numarası zaten kayıtlı.";
                    LoadDepartments();
                    return View();
                }

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        user.Role = "Doctor";
                        user.CreatedAt = DateTime.Now;
                        user.PasswordHash = PasswordHelper.ComputeSha256Hash(user.PasswordHash);

                        db.Users.Add(user);
                        db.SaveChanges();

                        doctor.UserID = user.UserID;
                        db.Doctors.Add(doctor);
                        db.SaveChanges();

                        transaction.Commit();

                        ViewBag.Success = "Doktor başarıyla sisteme eklendi.";
                        ModelState.Clear();

                        LoadDepartments();
                        return View();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        ViewBag.Error = "Hata oluştu: " + ex.Message;
                    }
                }
            }
            LoadDepartments();
            return View();
        }

        public ActionResult Index()
        {
            if (Session["UserRole"]?.ToString() != "Admin") return RedirectToAction("Login", "Account");

            ViewBag.TotalDoctors = db.Doctors.Count();
            ViewBag.TotalPatients = db.Patients.Count();
            ViewBag.TotalAppointments = db.Appointments.Count();
            ViewBag.ActiveAppointments = db.Appointments.Count(a => a.Status == "Aktif");

            var recentDoctors = db.Doctors.Include(d => d.User).OrderByDescending(d => d.UserID).Take(5).ToList();

            return View(recentDoctors);
        }
        
        public ActionResult DeleteDoctor(int id)
        {
            if (Session["UserRole"]?.ToString() != "Admin") return RedirectToAction("Login", "Account");
            var doctor = db.Doctors.Find(id);
            if (doctor != null)
            {
                var user = db.Users.Find(doctor.UserID);
                db.Doctors.Remove(doctor);
                if (user != null) db.Users.Remove(user);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        
    }
}