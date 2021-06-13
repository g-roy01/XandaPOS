using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XandaPOS.Models.MasterdataModel;
using XandaPOS.Models.OrdersModel;
using XandaPOS.Edmx;

namespace XandaPOS.Business
{
    public class OrdersDataBL
    {
        #region GLOBAL DECLARATIONS
        MasterDataBL _masterDataRepo = new MasterDataBL();

        #endregion

        #region PURCHASE ORDER MAIN
        public PurchaseOrderMainVM LoadPurchaseOrderMainGrid()
        {
            PurchaseOrderMainVM _purchaseOrderMainVM = new PurchaseOrderMainVM();
            using (var db = new xandaposEntities())
            {

            }
            _purchaseOrderMainVM.warehouseList = _masterDataRepo.LoadWarehouseMasterGrid();
            _purchaseOrderMainVM.supplierList = _masterDataRepo.FetchCompanyTypeList("SUPPLIER");
            //_purchaseOrderMainVM.taxList = _masterDataRepo.LoadTaxMasterList();
            _purchaseOrderMainVM.mainProductList = _masterDataRepo.LoadProductMasterGrid().mainProductData;

            return _purchaseOrderMainVM; 
        }

        #endregion
    }
}