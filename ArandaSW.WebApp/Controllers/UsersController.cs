using ArandaSW.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArandaSW.WebApp.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Users()
        {
            var User = (a_user)Session["User"];

            if (User != null)
            {
                TempData["rol"] = User.role_fk;
            }

            using (Models.ArandaDBEntities db = new Models.ArandaDBEntities())
            {
                var GetUsers = (from usr in db.a_user
                               select usr);

                return View(GetUsers.ToList());
            }
                
            
        }
    }
}