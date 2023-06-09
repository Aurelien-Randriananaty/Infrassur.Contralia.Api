using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using Infrassur.Contralia.Api.Controllers;
using Newtonsoft.Json.Linq;
using Ninject.Web.WebApi;
using Ninject;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Reflection;
using System.Web.UI.WebControls;

namespace Infrassur.Contralia.Api
{
	public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code qui s’exécute au démarrage de l’application
            AreaRegistration.RegisterAllAreas();
			UnityConfig.RegisterComponents();
			GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //RegisterDependencies(GlobalConfiguration.Configuration);


        }
    }
}