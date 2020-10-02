using ArandaSW.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArandaSW.WebApp.Controllers
{
    public class EditarUsuarioController : Controller
    {
        // GET: EditarUsuario
        public ActionResult Editar(int? id)
        {
            var User = (a_user)Session["User"];

            if (User != null)
            {
                TempData["rol"] = User.role_fk;
            }

            using (Models.ArandaDBEntities db = new Models.ArandaDBEntities())
            {
                var GetUser = db.a_user.Where(x => x.id == id).FirstOrDefault();

                if (GetUser != null)
                {
                    TempData["UserID"] = id;
                    TempData.Keep();
                    return View(GetUser);
                }
                return View();
            }

        }

        [HttpPost]
        public ActionResult Editar(a_user usuario)
        {
            using (Models.ArandaDBEntities db = new Models.ArandaDBEntities())
            {
                int id = (int)TempData["UserID"];
                var GetUser = db.a_user.Where(x => x.id == id).FirstOrDefault();
                if (GetUser != null)
                {
                    GetUser.fname = usuario.fname;
                    GetUser.lname = usuario.lname;
                    GetUser.usr_name = usuario.usr_name;
                    GetUser.usr_password = usuario.usr_password;
                    GetUser.address = usuario.address;
                    GetUser.phone = usuario.phone;
                    GetUser.email = usuario.email;
                    db.Entry(GetUser).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                }
                return RedirectToAction("../Users/Users");
            }

        }
    }
}