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
    public class TestsController : BaseController
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: Admin/Tests
        public ActionResult Index(int page =1,int pageSize =10)
        {
            var dao = new TestDAO();
            var model = dao.ListAllPaging(page, pageSize);
            var tests = db.Tests.Include(t => t.Student).Include(t => t.Subject);
            return View(model);
        }

        // GET: Admin/Tests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: Admin/Tests/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name");
            return View();
        }

        // POST: Admin/Tests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentId,SubjectId,Mark,Status,Attendance,Note")] Test test)
        {
            if (ModelState.IsValid)
            {
                db.Tests.Add(test);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", test.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", test.SubjectId);
            return View(test);
        }

        // GET: Admin/Tests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", test.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", test.SubjectId);
            return View(test);
        }

        // POST: Admin/Tests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentId,SubjectId,Mark,Status,Attendance,Note")] Test test)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", test.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", test.SubjectId);
            return View(test);
        }

        // GET: Admin/Tests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: Admin/Tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test test = db.Tests.Find(id);
            db.Tests.Remove(test);
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
