﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication1.App_Start;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //public static DataStore Database = new DataStore();
        public static DbService Database = new DbService();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}