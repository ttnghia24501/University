using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using System.Configuration;
using System.Net.Mail;
using System.IO;
using Common;

namespace University.Controllers
{
    public class StudentsController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string name, string email,[Bind(Include = "Id,Name,Image,FatherName,MotherName,Birthday,Gender,ResidentialAddress,PermanentAddress,SportDetails,Email,Password,Status")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();

                student.Name = name;
                student.Email = email;

                string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/client/template/newRegistration.html"));
                content = content.Replace("{{Name}}",name);
                content = content.Replace("{{Email}}", email);

                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
                new MailHelper().SendMail(email, "New Registration at ITM College", content);
                new MailHelper().SendMail(toEmail, "New Registration at ITM College", content);

                return RedirectToAction("Index","Home");
            }
            

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //public ActionResult Login(LoginModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dao = new ManagerDAO();
        //        var result = dao.Login(model.Email, Encryptor.MD5Hash(model.Password));
        //        if (result == 1)
        //        {
        //            var manager = dao.GetById(model.Email);
        //            var managerSession = new ManagerLogin();
        //            managerSession.Email = manager.Email;
        //            managerSession.ID = manager.ID;

        //            Session.Add(Common_Constants.MANAGER_SESSION, managerSession);
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else if (result == 0)
        //        {
        //            ModelState.AddModelError("", "Account is invalid");
        //        }
        //        else if (result == -1)
        //        {
        //            ModelState.AddModelError("", "Account was locked");
        //        }
        //        else if (result == -2)
        //        {
        //            ModelState.AddModelError("", "Email or Password is incorrect");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Login false.");
        //        }
        //    }
        //    return View(model);
        //}
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
