using System.Web.Mvc;
using ActiveRecord.CheckOut.Contracts;

namespace ActiveRecord.CheckOutWeb.Controllers
{
    public class CheckOutController : ControllerBase
    {
        private readonly ICheckOutService _service;

        public CheckOutController(ICheckOutService service)
        {
            _service = service;
        }

        // GET: CheckOut
        public ViewResult Index(int id = 0)
        {
            _service.Resume(id);
            return View(new Models.CheckOut(_service.CurrentBill));
        }

        // POST: Scan
        [HttpPost]
        public ViewResult Index(Models.CheckOut checkOut)
        {
            _service.Resume(checkOut.BillId);
            _service.Scan(checkOut.ScannedCode);

            return View(new Models.CheckOut(_service.CurrentBill));
        }
    }
}