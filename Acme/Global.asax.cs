using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Acme.BusinessLogic.DependencyInjection;
using Acme.DependencyInjection;

namespace Acme
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Acme.BusinessLogic.DependencyInjection.Container.Initialize();
            
            WindsorControllerFactory controllerFactory = new WindsorControllerFactory(Acme.BusinessLogic.DependencyInjection.Container.Instance.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
