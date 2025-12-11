using HospitalSystem.Data;
using HospitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalSystem.Controllers
{
    public class DepartmentsController : Controller
    {
        HospitalContext db = new HospitalContext();
        // GET: Departments
        public ActionResult Index()
        {
            if (Session["UserRole"]?.ToString() != "Admin") return RedirectToAction("Login", "Account");

            var departments = db.Departments.ToList();
            return View(departments);
        }
        public ActionResult Create()
        {
            if (Session["UserRole"]?.ToString() != "Admin") return RedirectToAction("Login", "Account");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            if (Session["UserRole"]?.ToString() != "Admin") return RedirectToAction("Login", "Account");
            if (ModelState.IsValid)
            {
                if (db.Departments.Any(d => d.DepartmentName.ToLower() == department.DepartmentName.ToLower()))
                {
                    ViewBag.Error = "Bu isimde bir departman var.";
                    return View(department);
                }

                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (Session["UserRole"]?.ToString() != "Admin") return RedirectToAction("Login", "Account");

            var dept = db.Departments.Find(id);
            if (dept != null)
            {
                if (dept.Doctors.Any())
                {
                    TempData["Error"] = "Bu bölümde çalışan doktorlar var. Önce doktorları çıkarın!";
                    return RedirectToAction("Index");
                }

                db.Departments.Remove(dept);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}