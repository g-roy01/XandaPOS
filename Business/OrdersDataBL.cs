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
            _purchaseOrderMainVM.warehouseList = _masterDataRepo.LoadWarehouseMasterGrid(0).OrderBy(m => m.warehouse_name).ToList();
            _purchaseOrderMainVM.supplierList = _masterDataRepo.FetchCompanyTypeList("SUPPLIER").OrderBy(m => m.comp_name).ToList();
            return _purchaseOrderMainVM; 
        }

        #endregion
    }
}