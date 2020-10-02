using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArandaSW.WebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string user, string pass)
        {
            try
            {
                using (Models.ArandaDBEntities db = new Models.ArandaDBEntities())
                {
                    var GetUser = (from usr in db.a_user
                                   where usr.usr_name == user.Trim() &&
                                         usr.usr_password == pass.Trim()
                                   select usr).FirstOrDefault();

                    if(GetUser == null)
                    {
                        ViewBag.Error = "Credenciales Incorrectas";
                        return View();
                    }

                    Session["User"] = GetUser;
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}