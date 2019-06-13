using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFWebApp.App_Start
{
    public class MyAuthorization : AuthorizeAttribute, IAuthorizationFilter
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
            || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                //Anonimos
                return;
            }

            // Check for authorization
            if (HttpContext.Current.Session["Usuario"] == null)
            {
                //filterContext.Result = new HttpUnauthorizedResult();
                filterContext.Result = new RedirectResult("~/Login");
            }
        }
    }
}