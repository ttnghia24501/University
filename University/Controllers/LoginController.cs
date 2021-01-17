using University.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using University.Common;
using Xamarin.Essentials;
using System.Web.Security;


namespace University.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new StudentDAO();
                var result = dao.Login(model.Email, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var student = dao.GetById(model.Email);
                    var studentSession = new StudentLogin();
                    studentSession.Email = student.Email;
                    studentSession.ID = student.Id;

                    Session.Add(Common_Constants.STUDENT_SESSION, studentSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Account is invalid");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Account was locked");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Email or Password is incorrect");
                }
                else
                {
                    ModelState.AddModelError("", "Login false.");
                }
            }
            return View("Index");

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Login");
        }
    }
}