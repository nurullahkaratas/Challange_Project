using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Web.Mvc;


namespace WebApplication3
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);    
            
        }
    }
}