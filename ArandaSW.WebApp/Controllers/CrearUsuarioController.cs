using ArandaSW.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArandaSW.WebApp.Controllers
{
    public class CrearUsuarioController : Controller
    {
        // GET: CrearUsuario
        public ActionResult Crear()
        {
            var User = (a_user)Session["User"];

            if (User != null)
            {
                TempData["rol"] = User.role_fk;
            }

            using (Models.ArandaDBEntities db = new Models.ArandaDBEntities())
            {
                var GetRoles = (from rol in db.a_role
                                select rol);
                ViewBag.listaRoles = GetRoles.ToList();
                return View();
            }
        }

        [HttpPost]
        public ActionResult GuardarNuevo(a_user usuario)
        {
            using (Models.ArandaDBEntities db = new Models.ArandaDBEntities())
            {
                if(usuario != null)
                {
                    db.a_user.Add(usuario);
                    db.SaveChanges();
                    return RedirectToAction("../Users/Users");
                }
                return View();
            }

        }
    }
}