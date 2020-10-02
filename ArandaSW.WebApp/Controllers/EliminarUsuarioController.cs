using ArandaSW.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArandaSW.WebApp.Controllers
{
    public class EliminarUsuarioController : Controller
    {
        // GET: EliminarUsuario
        public ActionResult Eliminar(int? id)
        {
            var User = (a_user)Session["User"];

            if (User != null)
            {
                TempData["rol"] = User.role_fk;
            }

            using (Models.ArandaDBEntities db = new Models.ArandaDBEntities())
            {

                if (id > 0)
                {
                    var usuarioId = db.a_user.Where(x => x.id == id).FirstOrDefault();
                    if (usuarioId != null)
                    {
                        db.Entry(usuarioId).State = EntityState.Deleted;
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("../Users/Users");
        }

       
    }
}
