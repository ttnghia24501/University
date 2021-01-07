using University.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using University.Common;

namespace University.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ManagerDAO();
                    var result = dao.Login(model.Email,Encryptor.MD5Hash(model.Password));
                if (result ==1)
                {
                    var manager = dao.GetById(model.Email);
                    var managerSession = new ManagerLogin();
                    managerSession.Email = manager.Email;
                    managerSession.ID = manager.ID;

                    Session.Add(Common_Constants.MANAGER_SESSION, managerSession);
                    return RedirectToAction("Index", "Home");
                }else if(result == 0)
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
    }
}