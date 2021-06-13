using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XandaPOS.Models.OrdersModel
{
    public class PurchaseOrderSheetVM
    {
        public int purchase_prod_sheet_id { get; set; }
        public int purchase_order_main_id { get; set; }
        public Nullable<int> product_id { get; set; }
        public Nullable<decimal> product_order_qty { get; set; }
        public Nullable<decimal> product_receive_qty { get; set; }
        public Nullable<decimal> product_cost_actual { get; set; }
        public Nullable<int> tax_id { get; set; }
        public Nullable<decimal> tax_percent { get; set; }
        public Nullable<decimal> subtotal { get; set; }
    }
}