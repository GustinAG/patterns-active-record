using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ActiveRecord.CheckOutWeb.Controllers;

namespace ActiveRecord.CheckOutWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Based on: https://stackoverflow.com/questions/20043306/how-to-impelment-a-custom-controller-factory-asp-net-mvc
            ControllerBuilder.Current.SetControllerFactory(new InjectingControllerFactory());
        }
    }
}
