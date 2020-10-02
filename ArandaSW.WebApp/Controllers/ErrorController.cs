using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ArandaSW.WebApp.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NoAutorizacion()
        {
            //ViewBag.privilege = privilege;
            //ViewBag.section = section;
            //ViewBag.msgError = msgError;
            return View();
        }
    }
}