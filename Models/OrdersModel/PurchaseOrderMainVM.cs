using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XandaPOS.Models.MasterdataModel;

namespace XandaPOS.Models.OrdersModel
{
    public class PurchaseOrderMainData
    {
        public int purchase_id { get; set; }
        public Nullable<int> warehouse_id { get; set; }
        public Nullable<int> supplier_id { get; set; }
        public Nullable<int> purchase_status { get; set; }
        public decimal shipping_cost { get; set; }
        public Nullable<int> purchase_prod_sheet_id { get; set; }
        public decimal discount { get; set; }
        public decimal tax { get; set; }
        public string notes { get; set; }
    }

    public class PurchaseOrderMainVM
    {
        public List<PurchaseOrderMainData> mainPurchaseOrderData { get; set; }
        public List<WarehouseMasterVM> warehouseList { get; set; }
        public List<CompanyMasterData> supplierList { get; set; }
        public List<PurchaseOrderSheetVM> purchaseOrderSheetDetails { get; set; }
        public List<TaxMasterVM> taxList { get; set; }
        public List<ProductMasterData> mainProductList { get; set; }
    }
}