using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CarsInventory
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly log4net.ILog mologger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(Server.MapPath("~/Web.config")));

            ///Aplication Log
            mologger.Info("Application has been Started :: " + DateTime.Now.ToString("MM/DD/yyyy"));
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception loException = Server.GetLastError();
            String lsIssueSummry = Convert.ToString(loException.Message);
            String lsStackTrace = Convert.ToString(loException.StackTrace);
            String lsWebServer = HttpContext.Current.Request.ServerVariables["HTTP_HOST"];

            if (!lsIssueSummry.Contains("Server cannot set status after HTTP headers have been sent") && !lsIssueSummry.Contains("Cannot redirect after HTTP headers have been sent"))
            {
                if (!lsWebServer.Contains("localhost"))
                {
                    mologger.Info("Error error On:" + DateTime.Now.ToString("MM/DD/yyyy"), loException);
                    mologger.Warn(HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath.TrimEnd('/'), loException);
                    mologger.Warn(Request.Url.ToString(), loException);
                    mologger.Warn(Request.UrlReferrer.ToString(), loException);
                    mologger.Warn(Request.ServerVariables["HTTP_USER_AGENT"], loException);
                    mologger.Warn(Request.ServerVariables["Remote_ADDR"], loException);
                    mologger.Warn(lsWebServer + Request.RawUrl, loException);
                    mologger.Warn(Request.ServerVariables["ALL_HTTP"], loException);
                    mologger.Error(lsStackTrace, loException);
                    mologger.Error(lsIssueSummry, loException);
                }
            }
            Server.ClearError();
            //Response.RedirectToRoute(
            //                    new RouteValueDictionary {
            //                        { "Controller", "Error" },
            //                        { "Action", "Index" }});
        }
    }
}
