using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XandaPOS.Business;
using XandaPOS.Models.MasterdataModel;
using XandaPOS.ImageHelper;
using XandaPOS.Edmx;
using System.Data.Entity;
using System.IO;
using System.Web.Helpers;

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
            BrandMasterVM brandMasterList = _brandMaster.LoadBrandMasterGrid(0);
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
            BrandMasterVM brandMasterList = _brandMaster.LoadBrandMasterGrid(brandID,"EDIT");
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
            return View(_masterDataBL.LoadCompanyMasterGrid(0,"ALL"));
        }

        [HttpPost]
        public JsonResult GetReloadCompanyMaster()
        {
            MasterDataBL _companyMaster = new MasterDataBL();
            List<CompanyMasterData> companyMasterList = _companyMaster.LoadCompanyMasterGrid(0,"ALL").mainCompanyData;
            return Json(new { CompanyMasterList = companyMasterList, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult AddCompany(POS_COMPANY_MASTER companyData)
        {
            MasterDataBL helperMaster = new MasterDataBL();
            string message = helperMaster.AddCompanyMaster(companyData);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult GetCompanyDataForEdit(int companyID)
        {
            MasterDataBL _companyMaster = new MasterDataBL();
            List<CompanyMasterData> companyMasterList = _companyMaster.LoadCompanyMasterGrid(companyID,"ALL","EDIT").mainCompanyData;
            return Json(new { CompanyMasterList = companyMasterList, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult EditCompany(POS_COMPANY_MASTER companyData)
        {
            MasterDataBL companyMaster = new MasterDataBL();
            string message = companyMaster.UpdateCompanyMaster(companyData);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult DeleteCompany(int compId)
        {
            MasterDataBL companyMaster = new MasterDataBL();
            string message = companyMaster.DeleteCompanyMaster(compId);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        #endregion

        #region CompanyVendorMaster
        //public ActionResult CompanyVendorMaster()
        //{
        //    MasterDataBL _masterDataBL = new MasterDataBL();
        //    return View(_masterDataBL.LoadCompanyMasterGrid("VENDOR"));
        //}

        #endregion

        #region CompanySupplierMaster
        //public ActionResult CompanySupplierMaster()
        //{
        //    MasterDataBL _masterDataBL = new MasterDataBL();
        //    return View(_masterDataBL.LoadCompanyMasterGrid("SUPPLIER"));
        //}

        #endregion

        #region CustomerMaster
        public ActionResult CustomerMaster()
        {
            MasterDataBL _masterDataBL = new MasterDataBL();
            return View(_masterDataBL.LoadCustomerMasterGrid(0));
        }

        [HttpPost]
        public JsonResult GetReloadCustomerMaster()
        {
            MasterDataBL _custMaster = new MasterDataBL();
            List<CustomerMasterVM> custMasterList = _custMaster.LoadCustomerMasterGrid(0);
            return Json(new { CustMasterList = custMasterList, JsonRequestBehavior.AllowGet });
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
            return View(_masterDataBL.LoadEmployeeMasterGrid(0));
        }

        [HttpPost]
        public JsonResult GetReloadEmployeeMaster()
        {
            MasterDataBL _empMaster = new MasterDataBL();
            List<EmployeeMasterVM> empMasterList = _empMaster.LoadEmployeeMasterGrid(0);
            return Json(new { EmpMasterList = empMasterList, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult AddEmployee(POS_EMPLOYEE_MASTER empData)
        {
            MasterDataBL empMaster = new MasterDataBL();
            string message = empMaster.AddEmployeeMaster(empData);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult GetEmployeeDataForEdit(int empID)
        {
            MasterDataBL _empMaster = new MasterDataBL();
            List<EmployeeMasterVM> empMasterList = _empMaster.LoadEmployeeMasterGrid(empID);
            return Json(new { EmpMasterList = empMasterList, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult EditEmployee(POS_EMPLOYEE_MASTER empData)
        {
            MasterDataBL empMaster = new MasterDataBL();
            string message = empMaster.UpdateEmployeeMaster(empData);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult DeleteEmployee(int empId)
        {
            MasterDataBL empMaster = new MasterDataBL();
            string message = empMaster.DeleteEmployeeMaster(empId);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        #endregion

        #region MasterTableHelperMaster
        public ActionResult MasterTableHelperMaster()
        {
            MasterDataBL _masterDataBL = new MasterDataBL();
            return View(_masterDataBL.LoadMasterTableHelperMasterGrid(0));
        }

        [HttpPost]
        public JsonResult GetReloadHelperMaster()
        {
            MasterDataBL _helperMaster = new MasterDataBL();
            List<MasterTableHelperMasterVM> helperMasterList = _helperMaster.LoadMasterTableHelperMasterGrid(0);
            return Json(new { HelperMasterList = helperMasterList, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult AddHelper(POS_MASTER_TABLE_HELPER helperData)
        {
            MasterDataBL helperMaster = new MasterDataBL();
            string message = helperMaster.AddMasterTableHelperMaster(helperData);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult GetHelperDataForEdit(int helperID)
        {
            MasterDataBL _helperMaster = new MasterDataBL();
            List<MasterTableHelperMasterVM> helperMasterList = _helperMaster.LoadMasterTableHelperMasterGrid(helperID,"EDIT");
            return Json(new { HelperMasterList = helperMasterList, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult EditHelper(POS_MASTER_TABLE_HELPER helperData)
        {
            MasterDataBL helperMaster = new MasterDataBL();
            string message = helperMaster.UpdateMasterTableHelperMaster(helperData);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult DeleteHelper(int helperId)
        {
            MasterDataBL helperMaster = new MasterDataBL();
            string message = helperMaster.DeleteMasterTableHelperMaster(helperId);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
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

        #region PRODUCT MAIN METHODS
        public ActionResult ProductMaster()
        {
            MasterDataBL _masterDataBL = new MasterDataBL();
            return View(_masterDataBL.LoadProductMasterGrid(0));
        }

        [HttpPost]
        public JsonResult GetReloadProductMaster()
        {
            MasterDataBL _productMaster = new MasterDataBL();
            ProductMasterVM productMasterList = _productMaster.LoadProductMasterGrid(0);
            return Json(new { ProductMasterList = productMasterList, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult AddProduct(POS_PRODUCT_MASTER productData)
        {
            MasterDataBL productMaster = new MasterDataBL();
            string message = productMaster.AddProductMaster(productData);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult GetProductDataForEdit(int productID)
        {
            MasterDataBL _productMaster = new MasterDataBL();
            List<ProductMasterData> prodMasterList = _productMaster.LoadProductMasterGrid(productID,"EDIT").mainProductData;
            return Json(new { ProdMasterList = prodMasterList, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult EditProduct(POS_PRODUCT_MASTER productData)
        {
            MasterDataBL productMaster = new MasterDataBL();
            string message = productMaster.UpdateProductMaster(productData);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult DeleteProduct(int productId)
        {
            MasterDataBL productMaster = new MasterDataBL();
            string message = productMaster.DeleteProductMaster(productId);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        #endregion

        #region PRODUCT IMAGE MANAGEMENT

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _Upload()
        {
            return PartialView();
        }

        [ValidateAntiForgeryToken]
        public ActionResult _Upload(IEnumerable<HttpPostedFileBase> files)
        {
            if (files == null || !files.Any())
                return Json(new { success = false, errorMessage = "No file uploaded." });

            var file = files.FirstOrDefault();  // get ONE only
            if (file == null || !IsImage(file))
                return Json(new { success = false, errorMessage = "File is of wrong format." });

            if (file.ContentLength <= 0)
                return Json(new { success = false, errorMessage = "File cannot be zero length." });

            var webPath = GetTempSavedFilePath(file);

            return Json(new { success = true, fileName = webPath.Replace("\\", "/") }); // success
        }

        [HttpPost]
        public ActionResult Save(string t, string l, string h, string w, string fileName)
        {
            try
            {
                ImageHelperMain _imageHelper = new ImageHelperMain();
                // Get file from temporary folder, ...
                var fn = Path.Combine(Server.MapPath(_imageHelper.MapTempFolder), Path.GetFileName(fileName));

                // ... get the image, ...
                var img = new WebImage(fn);

                // ... calculate its new dimensions, ...
                var height = Convert.ToInt32(h.Replace("-", "").Replace("px", ""));
                var width = Convert.ToInt32(w.Replace("-", "").Replace("px", ""));

                // ... scale it, ...
                img.Resize(width, height);

                // ... crop the part the user selected, ...
                var top = Convert.ToInt32(t.Replace("-", "").Replace("px", ""));
                var left = Convert.ToInt32(l.Replace("-", "").Replace("px", ""));
                var bottom = img.Height - top - _imageHelper.AvatarHeight;
                var right = img.Width - left - _imageHelper.AvatarWidth;

                // ... check for validity of calculations, ...
                if (bottom < 0 || right < 0)
                {
                    // If you reach this point, your avatar sizes in here and in the CSS file are different.
                    // Check _avatarHeight and _avatarWidth in this file
                    // and height and width for #preview-pane .preview-container in site.avatar.css
                    throw new ArgumentException("Definitions of dimensions of the cropping window do not match. Talk to the developer who customized the sample code :)");
                }

                img.Crop(top, left, bottom, right);

                // ... delete the temporary file,...
                System.IO.File.Delete(fn);

                // ... and save the new one.
                var newFileName = Path.Combine(_imageHelper.AvatarPath, Path.GetFileName(fn));
                var newFileLocation = HttpContext.Server.MapPath(newFileName);
                if (Directory.Exists(Path.GetDirectoryName(newFileLocation)) == false)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(newFileLocation));
                }

                img.Save(newFileLocation);
                return Json(new { success = true, avatarFileLocation = newFileName });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = "Unable to upload file.\nERRORINFO: " + ex.Message });
            }
        }

        private bool IsImage(HttpPostedFileBase file)
        {
            ImageHelperMain _imageHelper = new ImageHelperMain();
            if (file == null) return false;
            return file.ContentType.Contains("image") ||
                _imageHelper.ImageFileExtensions.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
        }

        private string GetTempSavedFilePath(HttpPostedFileBase file)
        {
            ImageHelperMain _imageHelper = new ImageHelperMain();
            // Define destination
            var serverPath = HttpContext.Server.MapPath(_imageHelper.TempFolder);
            if (Directory.Exists(serverPath) == false)
            {
                Directory.CreateDirectory(serverPath);
            }

            // Generate unique file name
            var fileName = Path.GetFileName(file.FileName);
            fileName = SaveTemporaryAvatarFileImage(file, serverPath, fileName);

            // Clean up old files after every save
            CleanUpTempFolder(1);
            return Path.Combine(_imageHelper.TempFolder, fileName);
        }

        private static string SaveTemporaryAvatarFileImage(HttpPostedFileBase file, string serverPath, string fileName)
        {
            ImageHelperMain _imageHelper = new ImageHelperMain();
            var img = new WebImage(file.InputStream);
            var ratio = img.Height / (double)img.Width;
            img.Resize(_imageHelper.AvatarScreenWidth, (int)(_imageHelper.AvatarScreenWidth * ratio));

            var fullFileName = Path.Combine(serverPath, fileName);
            if (System.IO.File.Exists(fullFileName))
            {
                System.IO.File.Delete(fullFileName);
            }

            img.Save(fullFileName);
            return Path.GetFileName(img.FileName);
        }

        private void CleanUpTempFolder(int hoursOld)
        {
            try
            {
                var currentUtcNow = DateTime.UtcNow;
                var serverPath = HttpContext.Server.MapPath("/Temp");
                if (!Directory.Exists(serverPath)) return;
                var fileEntries = Directory.GetFiles(serverPath);
                foreach (var fileEntry in fileEntries)
                {
                    var fileCreationTime = System.IO.File.GetCreationTimeUtc(fileEntry);
                    var res = currentUtcNow - fileCreationTime;
                    if (res.TotalHours > hoursOld)
                    {
                        System.IO.File.Delete(fileEntry);
                    }
                }
            }
            catch
            {
                // Deliberately empty.
            }
        }





        #endregion


        #endregion

        #region WarehouseMaster
        public ActionResult WarehouseMaster()
        {
            MasterDataBL _masterDataBL = new MasterDataBL();
            return View(_masterDataBL.LoadWarehouseMasterGrid(0));
        }

        [HttpPost]
        public JsonResult GetReloadWarehouseMaster()
        {
            MasterDataBL _warehouseMaster = new MasterDataBL();
            List<WarehouseMasterVM> warehouseMasterList = _warehouseMaster.LoadWarehouseMasterGrid(0);
            return Json(new { WarehouseMasterList = warehouseMasterList, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult AddWarehouse(POS_WAREHOUSE_MASTER warehouseData)
        {
            MasterDataBL warehouseMaster = new MasterDataBL();
            string message = warehouseMaster.AddWarehouseMaster(warehouseData);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult GetWarehouseDataForEdit(int warehouseID)
        {
            MasterDataBL _warehouseMaster = new MasterDataBL();
            List<WarehouseMasterVM> warehouseMasterList = _warehouseMaster.LoadWarehouseMasterGrid(warehouseID);
            return Json(new { WarehouseMasterList = warehouseMasterList, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult EditWarehouse(POS_WAREHOUSE_MASTER warehouseData)
        {
            MasterDataBL warehouseMaster = new MasterDataBL();
            string message = warehouseMaster.UpdateWarehouseMaster(warehouseData);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult DeleteWarehouse(int warehouseId)
        {
            MasterDataBL warehouseMaster = new MasterDataBL();
            string message = warehouseMaster.DeleteWarehouseMaster(warehouseId);
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        #endregion



    }
}