//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XandaPOS.Edmx
{
    using System;
    using System.Collections.Generic;
    
    public partial class pos_PurchaseOrder_Main
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
        public System.DateTime purchase_timestamp { get; set; }
    }
}
