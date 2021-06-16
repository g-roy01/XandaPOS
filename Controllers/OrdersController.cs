using System.Web.Mvc;
using XandaPOS.Business;

namespace XandaPOS.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PurchaseOrder()
        {
            OrdersDataBL _masterDataRepo = new OrdersDataBL();
            return View(_masterDataRepo.LoadPurchaseOrderMainGrid());
        }

        public ActionResult ReceiveOrder()
        {
            return View();
        }

        public ActionResult SellOrder()
        {
            return View();
        }
    }
}