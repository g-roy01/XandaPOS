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

        #region BrandMaster
        public ActionResult BrandMaster()
        {
            MasterDataBL _masterDataBL = new MasterDataBL();
            return View(_masterDataBL.LoadBrandMasterGrid(0));
        }

        [HttpPost]
        public JsonResult GetReloadBrandMaster()
        {
            MasterDataBL _brandMaster = new MasterDataBL();
            List<BrandMasterVM> brandMasterList = _brandMaster.LoadBrandMasterGrid(0);
            return Json(new { BrandMasterList = brandMasterList, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult AddBrand(POS_BRAND_MASTER brandData)
        {
            MasterDataBL brandMaster = new MasterDataBL();
            string message = brandMaster.AddBrandMaster(brandData);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult GetBrandDataForEdit(int brandID)
        {
            MasterDataBL _brandMaster = new MasterDataBL();
            List<BrandMasterVM> brandMasterList = _brandMaster.LoadBrandMasterGrid(brandID);
            return Json(new { BrandMasterList = brandMasterList, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult EditBrand(POS_BRAND_MASTER brandData)
        {
            MasterDataBL brandMaster = new MasterDataBL();
            string message = brandMaster.UpdateBrandMaster(brandData);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult DeleteBrand(int brandId)
        {
            MasterDataBL brandMaster = new MasterDataBL();
            string message = brandMaster.DeleteBrandMaster(brandId);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        #endregion

        #region CompanyMaster
        public ActionResult CompanyMaster()
        {
            MasterDataBL _masterDataBL = new MasterDataBL();
            return View(_masterDataBL.LoadCompanyMasterGrid("ALL"));
        }
        #endregion

        #region CompanyVendorMaster
        public ActionResult CompanyVendorMaster()
        {
            MasterDataBL _masterDataBL = new MasterDataBL();
            return View(_masterDataBL.LoadCompanyMasterGrid("VENDOR"));
        }

        #endregion

        #region CompanySupplierMaster
        public ActionResult CompanySupplierMaster()
        {
            MasterDataBL _masterDataBL = new MasterDataBL();
            return View(_masterDataBL.LoadCompanyMasterGrid("SUPPLIER"));
        }

        #endregion

        #region CustomerMaster
        public ActionResult CustomerMaster()
        {
            //This will show the data layout for Customer Master
            MasterDataBL _masterDataBL = new MasterDataBL();
            return View(_masterDataBL.LoadCustomerMasterGrid(0));
        }

        [HttpPost]
        public JsonResult GetReloadCustomerMaster()
        {
            MasterDataBL _custMaster = new MasterDataBL();
            List<CustomerMasterVM> custMasterList = _custMaster.LoadCustomerMasterGrid(0);
            return Json(new { CustMasterList = custMasterList, JsonRequestBehavior.AllowGet });
            //return Json(new { Customer = "ABC", JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult AddCustomer(POS_CUSTOMER_MASTER custData)
        {
            MasterDataBL custMaster = new MasterDataBL();
            string message = custMaster.AddCustomerMaster(custData);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult GetCustomerDataForEdit(int custID)
        {
            MasterDataBL _custMaster = new MasterDataBL();
            List<CustomerMasterVM> custMasterList = _custMaster.LoadCustomerMasterGrid(custID);
            return Json(new { CustMasterList = custMasterList, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult EditCustomer(POS_CUSTOMER_MASTER custData)
        {
            MasterDataBL custMaster = new MasterDataBL();
            string message = custMaster.UpdateCustomerMaster(custData);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult DeleteCustomer(int custId)
        {
            MasterDataBL custMaster = new MasterDataBL();
            string message = custMaster.DeleteCustomerMaster(custId);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        #endregion

        #region EmployeeMaster
        public ActionResult EmployeeMaster()
        {
            MasterDataBL _masterDataBL = new MasterDataBL();
            return View(_masterDataBL.LoadEmployeeMasterGrid());
        }
        #endregion

        #region MasterTableHelperMaster
        public ActionResult MasterTableHelperMaster()
        {
            MasterDataBL _masterDataBL = new MasterDataBL();
            return View(_masterDataBL.LoadMasterTableHelperMasterGrid());
        }
        #endregion

        #region ProductGroupMaster
        public ActionResult ProductGroupMaster()
        {
            MasterDataBL _masterDataBL = new MasterDataBL();
            return View(_masterDataBL.LoadProductGroupMasterGrid(0));
        }

        [HttpPost]
        public JsonResult GetReloadProductGroupMaster()
        {
            MasterDataBL _prodGroupMaster = new MasterDataBL();
            List<ProductGroupMasterVM> prodGrpMasterList = _prodGroupMaster.LoadProductGroupMasterGrid(0);
            return Json(new { ProdGrpMasterList = prodGrpMasterList, JsonRequestBehavior.AllowGet });
            //return Json(new { Customer = "ABC", JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult AddProdGrp(POS_PRODUCT_GROUP_MASTER prodGrpData)
        {
            MasterDataBL prodGrpMaster = new MasterDataBL();
            string message = prodGrpMaster.AddProductGroupMaster(prodGrpData);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult GetProdGrpDataForEdit(int prodGrpID)
        {
            MasterDataBL _prodGrpMaster = new MasterDataBL();
            List<ProductGroupMasterVM> prodGrpMasterList = _prodGrpMaster.LoadProductGroupMasterGrid(prodGrpID);
            return Json(new { ProdGrpMasterList = prodGrpMasterList, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult EditProdGrp(POS_PRODUCT_GROUP_MASTER prodGrpData)
        {
            MasterDataBL prodGrpMaster = new MasterDataBL();
            string message = prodGrpMaster.UpdateProductGroupMaster(prodGrpData);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult DeleteProdGrp(int prodGrpId)
        {
            MasterDataBL prodGrpMaster = new MasterDataBL();
            string message = prodGrpMaster.DeleteProductGroupMaster(prodGrpId);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        #endregion

        #region ProductMaster
        public ActionResult ProductMaster()
        {
            MasterDataBL _masterDataBL = new MasterDataBL();
            return View(_masterDataBL.LoadProductMasterGrid());
        }
        #endregion

        #region WarehouseMaster
        public ActionResult WarehouseMaster()
        {
            MasterDataBL _masterDataBL = new MasterDataBL();
            return View(_masterDataBL.LoadWarehouseMasterGrid());
        }
        #endregion


        //public JsonResult GetCustomer(string custId)
        //{
        //    List<CustomerMasterVM> lstCustomerData = new List<CustomerMasterVM>();
        //    lstCustomerData = custDBContext.CustomerData.ToList();
        //    return Json(lstCustomerData, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult LoadCustomerGrid()
        //{
        //    //var datasource = OrderRepository.GetAllRecords().ToList();

        //    return Json("s", JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult ProductGroupMaster()
        //{
        //    return View();
        //}
    }
}