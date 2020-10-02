using ArandaSW.WebApp.Controllers;
using ArandaSW.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArandaSW.WebApp.Filters
{
    public class VerificarSession : ActionFilterAttribute
    {
        private a_user User;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                User = (a_user)HttpContext.Current.Session["User"];

                if (User == null)
                {
                    if (filterContext.Controller is LoginController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Login/Login");
                    }

                }
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Login/Login");
            }
        }
    }
}