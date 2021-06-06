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

        public ActionResult BrandMaster()
        {
            MasterDataBL _masterDataBL = new MasterDataBL();
            return View(_masterDataBL.LoadBrandMasterGrid());
        }

        public ActionResult CompanyMaster()
        {
            MasterDataBL _masterDataBL = new MasterDataBL();
            return View(_masterDataBL.LoadCompanyMasterGrid());
        }

        public ActionResult CustomerMaster()
        {
            //CustomerMasterVM _customerMastervm = new CustomerMasterVM();

            //This will show the data layout for Customer Master
            MasterDataBL _masterDataBL = new MasterDataBL(); 
            return View(_masterDataBL.LoadCustomerMasterGrid());
        }

        public ActionResult EmployeeMaster()
        {
            MasterDataBL _masterDataBL = new MasterDataBL();
            return View(_masterDataBL.LoadEmployeeMasterGrid());
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