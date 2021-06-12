using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XandaPOS.Models
{
    public class ProductMasterData
    {
        public int product_id { get; set; }
        public string product_name { get; set; }

        //Linked with helper_master
        public string product_type_name { get; set; }
        
        //Linked with product_group_master
        public string product_group_name { get; set; }
        
        //Linked with company_master
        public string product_company_name { get; set; }
        public string product_details { get; set; }
        public string product_image_link { get; set; }
        public string product_code { get; set; }
        public decimal product_default_cost { get; set; }
    }

    public class ProductMasterVM
    {
        public List<ProductMasterData> mainProductData { get; set; }
        public List<CompanyMasterData> companyDetails { get; set; }
        public List<ProductGroupMasterVM> prodGrpDetails { get; set; }
        public List<MasterTableHelperMasterVM> helperDetails { get; set; }

    }
}