using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XandaPOS.Business;
using XandaPOS.Models;
using XandaPOS.BusinessData;
using XandaPOS.Edmx;
using System.Data.Entity;

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

        [HttpPost]
        public ActionResult AddCustomer(POS_CUSTOMER_MASTER custData)
        {
            string message = "";
            try
            {
                using (var db = new DBContextMaster())
                {
                    db.CustomerData.Add(custData); 
                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public ActionResult EditCustomer(POS_CUSTOMER_MASTER custData)
        {
            string message = "";
            try
            {
                using (var db = new DBContextMaster())
                {
                    var retVal = db.CustomerData.Where(x => x.cust_id == custData.cust_id).FirstOrDefault();
                    retVal.cust_name = custData.cust_name;
                    retVal.cust_addr = custData.cust_addr;
                    retVal.cust_pin = custData.cust_pin;
                    retVal.cust_phn = custData.cust_phn;
                    retVal.cust_email = custData.cust_email;
                    db.SaveChanges();
                }
                message = "SUCCESS";
            }
            catch (Exception ex)
            {
                message = "FAIL";
            }

            //string message = "";
            //try
            //{
            //    using (var db = new DBContextMaster())
            //    {
            //        db.Entry(custData).State = EntityState.Modified;
            //        db.SaveChanges();
            //    }
            //    message = "SUCCESS";
            //}
            //catch(Exception ex)
            //{
            //    message = "FAIL";
            //}
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        //public JsonResult GetCustomer(string custId)
        //{
        //    List<CustomerMasterVM> lstCustomerData = new List<CustomerMasterVM>();
        //    lstCustomerData = custDBContext.CustomerData.ToList();
        //    return Json(lstCustomerData, JsonRequestBehavior.AllowGet);
        //}







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