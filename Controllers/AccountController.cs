using HospitalSystem.Data;
using HospitalSystem.Helpers;
using HospitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalSystem.Controllers
{
    public class AccountController : Controller
    {
        HospitalContext db = new HospitalContext();

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user, Patient patient)
        {
            ModelState.Remove("user.Role");
            ModelState.Remove("patient.User");
            ModelState.Remove("patient.UserID");

            if (ModelState.IsValid)
            {
                if (db.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("user.Email", "Bu mail adresi zaten kullanımda. Lütfen başka bir mail deneyin veya giriş yapın.");
                    return View();
                }
                using (var transaction = db.Database.BeginTransaction())
                { 
                    try
                    {
                        user.Role = "Patient";
                        user.CreatedAt = DateTime.Now;
                        user.PasswordHash = PasswordHelper.ComputeSha256Hash(user.PasswordHash);
                        db.Users.Add(user);
                        db.SaveChanges();


                        patient.UserID = user.UserID;
                        db.Patients.Add(patient);
                        db.SaveChanges();
                        transaction.Commit();
                        return RedirectToAction("Login");
                    }
                    catch
                    {
                        transaction.Rollback();
                        ViewBag.ErrorMessage = "Registration failed. Please try again.";
                    }
    
                
                }

            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}