using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XandaPOS.Business;
using XandaPOS.Models;

namespace XandaPOS.Controllers
{
    public class MasterdataController : Controller
    {
        // GET: Masterdata
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CompanyMaster()
        {
            return View();
        }
        public ActionResult CustomerMaster()
        {
            //CustomerMasterVM _customerMastervm = new CustomerMasterVM();
            MasterDataBL _MasterDataBL = new MasterDataBL(); 
            return View(_MasterDataBL.LoadCustomerMasterGrid());
        }

        public ActionResult LoadCustomerGrid()
        {
            //var datasource = OrderRepository.GetAllRecords().ToList();

            return Json("s", JsonRequestBehavior.AllowGet);
        }


        //public ActionResult ProductGroupMaster()
        //{
        //    return View();
        //}
    }
}