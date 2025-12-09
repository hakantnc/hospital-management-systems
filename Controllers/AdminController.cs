using HospitalSystem.Data;
using HospitalSystem.Helpers;
using HospitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data.Entity;

namespace HospitalSystem.Controllers
{
    public class AdminController : Controller
    {
        HospitalContext db = new HospitalContext();

        public ActionResult AddDoctor()
        {
            List<Department> departments = db.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(departments, "DepartmentID", "DepartmentName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDoctor(User user, Doctor doctor)
        {
            ModelState.Remove("user.Role");
            ModelState.Remove("doctor.User");
            ModelState.Remove("doctor.UserID");

            if(ModelState.IsValid)
            {
                if(db.Users.Any(u => u.Email == user.Email))
                {
                    ViewBag.Error = "Bu Email zaten kayıtlı.";
                    return View();
                }
                if(db.Users.Any(u => u.TCKN == user.TCKN))
                {
                    ViewBag.Error = "Bu TC Kimlik Numarası zaten kayıtlı.";
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
                        return View();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        ViewBag.Error = "Hata oluştu: " + ex.Message;
                    }
                }
                    ViewBag.DepartmentList = new SelectList("DepartmentID", "DepartmentName");
                
            }
            return View();
        }
        public ActionResult Index()
        {
            var doctors = db.Doctors.Include(d => d.User).ToList();
            return View(doctors);
        }
            
    }
}
