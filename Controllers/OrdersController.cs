using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XandaPOS.Business;
using XandaPOS.Edmx;
using XandaPOS.Models.OrdersModel; 

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