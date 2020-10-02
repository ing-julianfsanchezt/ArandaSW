using ArandaSW.WebApp.Filters;
using ArandaSW.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArandaSW.WebApp.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            var User = (a_user)Session["User"];

            if (User != null)
            {
                TempData["rol"] = User.role_fk;
                TempData["nombre"] = User.fname;
                TempData["apellido"] = User.lname;
                TempData["direccion"] = User.address;
                TempData["email"] = User.email;
            }
            
            return View();
        }

        public ActionResult LogOut()
        {
            Session["User"] = null;
            return RedirectToAction("Login", "Login"); ;
        }
        public ActionResult Users()
        {
            return View();
        }
    }
}