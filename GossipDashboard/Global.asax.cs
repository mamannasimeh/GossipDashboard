using AutoMapper;
using GossipDashboard.Repository;
using GossipDashboard.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GossipDashboard
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private LogErrorRepository repoErrorLog = new Repository.LogErrorRepository();
        protected void Application_Start()
        {
             LogRepository repoLog = new Repository.LogRepository();

        AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(cfg => cfg.ValidateInlineMaps = false);


            repoLog.Add(new VM_Log()
            {
                IP ="",
                ModifyDateTime = DateTime.Now,
                PostName = "Application_Start",
                PostID = -101,
                LogTypeID_fk = 59,
            });
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            if (Server != null)
            {
                Exception ex = Server.GetLastError();

                repoErrorLog.Add(new VM_LogError()
                {
                    ErrorDescription = ex.ToString(),
                    IP = Request.UserHostAddress,
                    ModifyDateTime = DateTime.Now,
                    PostName = "Application_Error",
                    PostID = -100
                });

            }


        }
    }
}
