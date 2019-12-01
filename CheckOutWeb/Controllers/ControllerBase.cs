using System.Web.Mvc;
using ActiveRecord.CheckOutWeb.Models;

namespace ActiveRecord.CheckOutWeb.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private const string MainLayoutViewModelName = "MainLayoutViewModel";

        // Based on: https://stackoverflow.com/questions/4154407/asp-net-mvc-razor-pass-model-to-layout
        protected ControllerBase()
        {
            ViewData[MainLayoutViewModelName] = new AppInfo();
        }
    }
}