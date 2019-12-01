using System;
using System.Web.Mvc;
using System.Web.Routing;
using ActiveRecord.BusinessLogic;

namespace ActiveRecord.CheckOutWeb.Controllers
{
    // Based on: https://stackoverflow.com/questions/20043306/how-to-impelment-a-custom-controller-factory-asp-net-mvc
    public class InjectingControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType) =>
            controllerType == typeof(CheckOutController)
                ? new CheckOutController(new CheckOutServices())
                : base.GetControllerInstance(requestContext, controllerType);
    }
}