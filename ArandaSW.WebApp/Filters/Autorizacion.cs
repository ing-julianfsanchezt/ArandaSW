using ArandaSW.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArandaSW.WebApp.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class Autorizacion : AuthorizeAttribute
    {
        private a_user User;
        private ArandaDBEntities db = new ArandaDBEntities();
        private int privilege;

        public Autorizacion(int idPrivilege = 0)
        {
            this.privilege = idPrivilege;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string privilegeName = "";
            string sectionName = "";

            try
            {
                User = (a_user)HttpContext.Current.Session["User"];
                var lstPrivileges = from p in db.a_role_privileges
                                    where p.role_fk == User.role_fk
                                    select p.privilege_fk;

                lstPrivileges.ToList();

                if (lstPrivileges.ToList().Count == 0)
                {
                    var GetPrivilege = db.a_privilege.Find(privilege);
                    int? idSection = GetPrivilege.id;
                    filterContext.Result = new RedirectResult("~/Error/NoAutorizacion");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}