using Infrassur.Contralia.Api.Contracts.Service;
using Infrassur.Contralia.Api.Service;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Infrassur.Contralia.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IServiceManager, ServiceManager>();
            container.RegisterType<IIdentitiesService, IdentitiesService>();

			// e.g. container.RegisterType<ITestService, TestService>();

			GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}