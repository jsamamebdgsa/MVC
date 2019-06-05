using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFWebApp.App_Start
{
    public class MyErrorFilterAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Log(filterContext);
            base.OnException(filterContext);
        }

        private void Log(ExceptionContext filterContext)
        {
            Debug.WriteLine("Log");
            Debug.WriteLine(filterContext.Exception.ToString());
            Console.WriteLine(((Controller)filterContext.Controller).Request.RawUrl);
        }
    }
}