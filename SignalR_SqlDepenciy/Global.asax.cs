using NeCoin.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SignalR_SqlDepenciy
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseContext db = new DatabaseContext();
            db.Bitcoin.ToList();

            //Burada web.config içerisine gömdüğümüz “BaglantiProvider” isimli sağlayıcının ConnectionString özelliği ile direkt olarak providerı get ediyor ve SqlDependency ile bu bağlantı yolunun takibini başlatıyoruz
            SqlDependency.Start(ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_End()
        {
            SqlDependency.Stop(ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString);
        }



    }
}
