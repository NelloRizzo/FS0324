using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebFormsSample
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e) {
            // Codice eseguito all'avvio dell'applicazione
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Session_Start(object sender, EventArgs e) {
            int c = (int)(Application["counter"] ?? 0);
            c++;
            Application["counter"] = c;
        }
    }
}