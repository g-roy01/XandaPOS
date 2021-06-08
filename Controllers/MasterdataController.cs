using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XandaPOS.Business;
using XandaPOS.Models;
using XandaPOS.BusinessData;

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
            return View(_masterDataBL.LoadCompanyMasterGrid("ALL"));
        }

        public ActionResult CompanyVendorMaster()
        {
            MasterDataBL _masterDataBL = new MasterDataBL();
            return View(_masterDataBL.LoadCompanyMasterGrid("VENDOR"));
        }

        public ActionResult CompanySupplierMaster()
        {
            MasterDataBL _masterDataBL = new MasterDataBL();
            return View(_masterDataBL.LoadCompanyMasterGrid("SUPPLIER"));
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

        public ActionResult MasterTableHelperMaster()
        {
            MasterDataBL _masterDataBL = new MasterDataBL();
            return View(_masterDataBL.LoadMasterTableHelperMasterGrid());
        }

        public ActionResult ProductGroupMaster()
        {
            MasterDataBL _masterDataBL = new MasterDataBL();
            return View(_masterDataBL.LoadProductGroupMasterGrid());
        }

        public ActionResult ProductMaster()
        {
            MasterDataBL _masterDataBL = new MasterDataBL();
            return View(_masterDataBL.LoadProductMasterGrid());
        }


        public ActionResult WarehouseMaster()
        {
            MasterDataBL _masterDataBL = new MasterDataBL();
            return View(_masterDataBL.LoadWarehouseMasterGrid());
        }


        //CustomerMasterDbContextVM custMasterDbContext = new CustomerMasterDbContextVM();

        [HttpPost]
        public ActionResult AddCustomer(CustomerMasterVM custData)
        {
            //BusinessData bdAddCustomer = new BusinessData();
            //BusinessData businessData
            //custMasterDbContext.CustomerData.Add(custData);
            //custMasterDbContext.SaveChanges();
            string message = "SUCCESS";
            return Json(new {Message = message, JsonRequestBehavior.AllowGet });
        }


        public JsonResult GetCustomer(string custId)
        {
            List<CustomerMasterVM> lstCustomerData = new List<CustomerMasterVM>();
            //lstCustomerData = custMasterDbContext.CustomerData.ToList();
            return Json(lstCustomerData, JsonRequestBehavior.AllowGet);
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