using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace University.Controllers
{
    public class StudentSubjectsController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: StudentSubjects
        // GET: StudentSubjects/Create
        public ActionResult Create()
        {
            ViewBag.Class = new SelectList(db.Classes, "Id", "Name");
            ViewBag.Department = new SelectList(db.Departments, "Id", "Name");
            ViewBag.Subject = new SelectList(db.Subjects, "Id", "Name");
            return View();
        }

        // POST: StudentSubjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentName,StudentEmail,Department,Class,Subject")] StudentSubject studentSubject)
        {
            if (ModelState.IsValid)
            {
                db.StudentSubjects.Add(studentSubject);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            ViewBag.Class = new SelectList(db.Classes, "Id", "Name", studentSubject.Class);
            ViewBag.Department = new SelectList(db.Departments, "Id", "Name", studentSubject.Department);
            ViewBag.Subject = new SelectList(db.Subjects, "Id", "Name", studentSubject.Subject);
            return View(studentSubject);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
