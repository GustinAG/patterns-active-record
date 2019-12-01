using System.Web.Mvc;
using ActiveRecord.CheckOutWeb.Models;

namespace ActiveRecord.CheckOutWeb.Controllers
{
    public class HomeController : ControllerBase
    {
        public ViewResult Index() => View(new AppInfo());

        public ViewResult About() => View(new AppInfo());

        public ViewResult Contact() => View(new ContactInfo());
    }
}