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
                if (db.Users.Any(u => u.TCKN == user.TCKN))
                {
                    ModelState.AddModelError("user.TCKN", "Bu TC Kimlik Numarası zaten kayıtlı.");
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
                        ViewBag.ErrorMessage = "Kayıt Hatalı. Lütfen Tekrar Deneyiniz.";
                    }


                }

            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Email, string Password)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                ViewBag.Error = "Lütfen email ve şifrenizi giriniz.";
                return View();
            }
            string hashedPassword = PasswordHelper.ComputeSha256Hash(Password);
            var user = db.Users.FirstOrDefault(u => u.Email == Email && u.PasswordHash == hashedPassword);

            if (user != null)
            {
                Session["UserID"] = user.UserID;
                Session["UserEmail"] = user.Email;
                Session["UserRole"] = user.Role;
                if (user.Role == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (user.Role == "Doctor")
                {
                    return RedirectToAction("Index", "Doctor");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Error = "Email adresi veya şifre hatalı.";
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}