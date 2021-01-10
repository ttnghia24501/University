using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using University.Common;
using PagedList;

namespace University.Areas.Admin.Controllers
{
    public class StudentSubjectsController : BaseController
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: Admin/StudentSubjects
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new StudentSubjectDAO();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            var studentSubjects = db.StudentSubjects.Include(s => s.Class1).Include(s => s.Department1).Include(s => s.Subject1);
            return View(model);
        }

        // GET: Admin/StudentSubjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentSubject studentSubject = db.StudentSubjects.Find(id);
            if (studentSubject == null)
            {
                return HttpNotFound();
            }
            return View(studentSubject);
        }

        // GET: Admin/StudentSubjects/Create
        //public ActionResult Create()
        //{
        //    ViewBag.Class = new SelectList(db.Classes, "Id", "Name");
        //    ViewBag.Department = new SelectList(db.Departments, "Id", "Name");
        //    ViewBag.Subject = new SelectList(db.Subjects, "Id", "Name");
        //    return View();
        //}

        //// POST: Admin/StudentSubjects/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,StudentName,StudentEmail,Department,Class,Subject")] StudentSubject studentSubject)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.StudentSubjects.Add(studentSubject);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Class = new SelectList(db.Classes, "Id", "Name", studentSubject.Class);
        //    ViewBag.Department = new SelectList(db.Departments, "Id", "Name", studentSubject.Department);
        //    ViewBag.Subject = new SelectList(db.Subjects, "Id", "Name", studentSubject.Subject);
        //    return View(studentSubject);
        //}

        // GET: Admin/StudentSubjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentSubject studentSubject = db.StudentSubjects.Find(id);
            if (studentSubject == null)
            {
                return HttpNotFound();
            }
            ViewBag.Class = new SelectList(db.Classes, "Id", "Name", studentSubject.Class);
            ViewBag.Department = new SelectList(db.Departments, "Id", "Name", studentSubject.Department);
            ViewBag.Subject = new SelectList(db.Subjects, "Id", "Name", studentSubject.Subject);
            return View(studentSubject);
        }

        // POST: Admin/StudentSubjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentName,StudentEmail,Department,Class,Subject")] StudentSubject studentSubject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentSubject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Class = new SelectList(db.Classes, "Id", "Name", studentSubject.Class);
            ViewBag.Department = new SelectList(db.Departments, "Id", "Name", studentSubject.Department);
            ViewBag.Subject = new SelectList(db.Subjects, "Id", "Name", studentSubject.Subject);
            return View(studentSubject);
        }

        // GET: Admin/StudentSubjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentSubject studentSubject = db.StudentSubjects.Find(id);
            if (studentSubject == null)
            {
                return HttpNotFound();
            }
            return View(studentSubject);
        }

        // POST: Admin/StudentSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentSubject studentSubject = db.StudentSubjects.Find(id);
            db.StudentSubjects.Remove(studentSubject);
            db.SaveChanges();
            return RedirectToAction("Index");
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
